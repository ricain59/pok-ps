using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using TiltStopLoss;

namespace TiltStopLoss
{
    delegate void SetTextCallback(string text);
    delegate void SetTextCallbacks(String text, Color cor);
    
    public partial class Stoploss : Form
    {
        private Main wmain;
        private Db dbase;
        private Thread startcrono;
        private Thread startbb;
        private Boolean continu = true;
        private Double stoploss;
        private Int64 handstop;
        private Int32 timestop;
        private Double stopwin;
        System.Media.SoundPlayer player;
        Boolean stop = false;
        private int tracker;
        List<Tuple<String, String>> playeridname;
        private String time;
        private Double bb;
        Int64 handnumber = 0;

        public Stoploss(Main wmain, List<Tuple<String,String>> playerid, Db db, String stoploss, String hand, String time, String win, int tracker)
        {
            InitializeComponent();
            this.wmain = wmain;
            playeridname = playerid;
            //this.playerid = playerid;
            //this.playername = playername;
            dbase = db;
            this.stoploss = new Utils().stringtoDouble(stoploss);
            handstop = new Utils().stringtoInt64(hand);
            timestop = new Utils().stringtoInt32(time);
            stopwin = new Utils().stringtoDouble(win);
            this.tracker = tracker;
            loadconfig();
            //cronometro
            startcrono = new Thread(new ThreadStart(this.stoptimer));
            startcrono.Start();
            //calculo dos BB e hands
            startbb = new Thread(new ThreadStart(this.calculateBB));
            startbb.Start();
            //calculateBB();
            //calculo de hands jogadas
            //starthand = new Thread(new ThreadStart(this.calculateHands));
            //starthand.Start();            
        }

        private void Stoploss_FormClosed(object sender, FormClosedEventArgs e)
        {
            continu = false;
            if (stop)
            {
                player.Stop();
            }
            String con = dbase.closeconDb();
            if (!con.Equals(""))
            {
                MessageBox.Show(con.ToString());
            }
            //guarda as config
            String location = this.Location.X.ToString() + ',' + this.Location.Y.ToString();
            String path = Directory.GetCurrentDirectory();
            StreamWriter w = new StreamWriter(path + "/config2.txt", false);
            w.Write("Location=" + location);
            w.WriteLine();
            w.Close();
            
            startbb.Abort();
            startcrono.Abort();
            
            wmain.setNewValue(handstop.ToString(), stoploss.ToString(), timestop.ToString(), stopwin.ToString());
            wmain.setValueSession(handnumber.ToString(), time, bb);
            wmain.Visible = true;            
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        /// <summary>
        /// Calcula os bb e hand para o stop
        /// </summary>
        private void calculateBB()
        {
            //DEPOIS de recuperar o ultimo id
            String yearmonth;
            Double bbinit = 0.0;
            Int64 lastidhand;
            if (tracker == 1 || tracker == 2)
            {
                yearmonth = new Utils().yearmonth();
                if (tracker == 2)//2 = hem2
                {
                    for (int i = 0; i < playeridname.Count; i++)
                    {
                        bbinit += dbase.getSumBB(playeridname[i].Item1, yearmonth);
                    }
                    lastidhand = dbase.getLastValue("handhistories", "handhistory_id") + 1;
                }
                else
                {
                    for (int i = 0; i < playeridname.Count; i++)
                    {
                        bbinit += dbase.getSumBBHem1(playeridname[i].Item1, yearmonth);
                    }
                    lastidhand = dbase.getLastValue("handhistories", "pokerhand_id") + 1;
                }
            }
            else //pt4
            {
                yearmonth = new Utils().yearweek();
                for (int i = 0; i < playeridname.Count; i++)
                {
                    bbinit += dbase.getSumBBPt4(playeridname[i].Item1, yearmonth);
                }
                lastidhand = dbase.getLastValue("cash_hand_histories", "id_hand") + 1;
            }

            
            try
            {
                while (continu)
                {
                    //bb
                    bb = 0.0;
                    if (tracker == 1 || tracker == 2)
                    {
                        if (tracker == 2)//2 = hem2
                        {
                            for (int i = 0; i < playeridname.Count; i++)
                            {
                                bb += dbase.getSumBB(playeridname[i].Item1, yearmonth);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < playeridname.Count; i++)
                            {
                                bb += dbase.getSumBBHem1(playeridname[i].Item1, yearmonth);
                            }
                        }
                    }
                    else //pt4
                    {
                        yearmonth = new Utils().yearweek();
                        for (int i = 0; i < playeridname.Count; i++)
                        {
                            bb += dbase.getSumBBPt4(playeridname[i].Item1, yearmonth);
                        }                       
                    }

                    bb = Math.Round((bb - bbinit), 2);
                    if (this.labelBb.InvokeRequired)
                    {
                        SetTextCallback d = new SetTextCallback(SetTextBb);
                        this.Invoke(d, new object[] { bb.ToString() });
                    }
                    else
                    {
                        // It's on the same thread, no need for Invoke
                        this.labelBb.Text = bb.ToString();
                    }
                    if (stoploss > 0.0)
                    {
                        if (bb <= (0 - stoploss))
                        {
                            if (!stop)
                            {
                                player = new Utils().playsound();
                                player.PlayLooping();
                            }
                            stop = true;
                            labelStopSet("!!!! StopLoss !!!!", Color.Red);
                        }
                    }
                    if (stopwin > 0.0)
                    {
                        if (bb >= stopwin)
                        {
                            if (!stop)
                            {
                                player = new Utils().playsound();
                                player.PlayLooping();
                            }
                            stop = true;
                            labelStopSet("!!!! StopWin !!!!", Color.Green);
                        }
                    }
                    //hand
                    String hand;
                    if (tracker == 1 || tracker == 2)
                    {
                        if (tracker == 2)//2 = hem2
                        {
                            hand = dbase.getHand(lastidhand, "handhistories", "handhistory_id", "handhistory");//hem2
                        }
                        else
                        {
                            hand = dbase.getHand(lastidhand, "handhistories", "pokerhand_id", "handhistory");//hem1
                        }
                    }
                    else
                    {
                        hand = dbase.getHand(lastidhand, "cash_hand_histories", "id_hand", "history");//pt4
                    }


                    if (!hand.Equals(""))
                    {
                        lastidhand++;
                        for (int i = 0; i < playeridname.Count; i++)
                        {
                            if (hand.Contains(playeridname[i].Item2) && !hand.Contains("Tournament"))
                            {
                                handnumber++;
                                if (this.labelBb.InvokeRequired)
                                {
                                    SetTextCallback d = new SetTextCallback(SetTextHands);
                                    this.Invoke(d, new object[] { handnumber.ToString() });
                                }
                                else
                                {
                                    // It's on the same thread, no need for Invoke
                                    this.labelHands.Text = handnumber.ToString();
                                }
                                if (handstop != 0)
                                {
                                    if (handstop <= handnumber)
                                    {
                                        if (!stop)
                                        {
                                            player = new Utils().playsound();
                                            player.PlayLooping();
                                        }
                                        stop = true;
                                        labelStopSet("!!!! StopHand !!!!", Color.Blue);
                                    }
                                }
                            }
                        }
                    }
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                new Debug().LogMessage(ex.ToString());
            }
        }        

        /// <summary>
        /// cronometro do tempo da sessão e para o stop time
        /// </summary>
        private void stoptimer()
        {
            int hour = 0;
            int minute = 0;
            int seconde = 0;
            int minutetostop = 0;
            
            while (continu)
            {
                Thread.Sleep(1000);
                seconde++;
                if (seconde == 60)
                {
                    seconde = 0;
                    minutetostop++;
                    minute++;
                    if (minute == 60)
                    {
                        minute = 0;
                        hour++;
                    }
                }
                String minutest;
                if (minute < 10)
                {
                    minutest = "0" + minute;
                }
                else
                {
                    minutest = "" + minute;
                }
                String secondest;
                if (seconde < 10)
                {
                    secondest = "0" + seconde;
                }
                else
                {
                    secondest = "" + seconde;
                }
                time = "0" + hour + ":" + minutest + ":" + secondest;
                if (this.labelTimer.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetTextTimer);
                    this.Invoke(d, new object[] { time });
                }
                else
                {
                    // It's on the same thread, no need for Invoke
                    this.labelTimer.Text = time;
                }
                if (timestop != 0)
                {
                    if (timestop <= minutetostop)
                    {
                        if (!stop)
                        {
                            player = new Utils().playsound();
                            player.PlayLooping();
                        }
                        stop = true;
                        labelStopSet("!!!! StopTime !!!!", Color.Black);                                               
                    }
                }
            }
        }

        private void SetTextTimer(string text)
        {
            this.labelTimer.Text = text;
        }
        private void SetTextBb(string text)
        {
            this.labelBb.Text = text;
        }
        private void SetTextHands(string text)
        {
            this.labelHands.Text = text;
        }
        private void setLabelStop(String text, Color cor)
        {
            this.labelStop.Text = text;
            this.labelStop.ForeColor = cor;
        }

        private void labelStopSet(String text, Color cor)
        {
            if (this.labelBb.InvokeRequired)
            {
                SetTextCallbacks d = new SetTextCallbacks(setLabelStop);
                this.Invoke(d, new object[] { text, cor });
            }
            else
            {
                // It's on the same thread, no need for Invoke
                this.labelStop.Text = text;
                this.labelStop.ForeColor = cor;
            }
        }

        /// <summary>
        /// mudar o texto das bb e po-lo visível ao passsar o rato por cima.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelBb_MouseHover(object sender, EventArgs e)
        {
            Double value = Convert.ToDouble(labelBb.Text.ToString());
            if (value > 0)
            {
                //labelBb.BackColor = Color.Green;
                labelBb.ForeColor = Color.Green;
            }
            else
            {
                //labelBb.BackColor = Color.Red;
                labelBb.ForeColor = Color.Red;
            }
            labelBb.Visible = true;
        }

        /// <summary>
        /// põe o label das BBs novmaente invisível.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelBb_MouseLeave(object sender, EventArgs e)
        {
            labelBb.ForeColor = Color.White;
        }

        /// <summary>
        /// carregas as configs
        /// </summary>
        private void loadconfig()
        {
            String path = Directory.GetCurrentDirectory();
            String filepath = path + "/config2.txt";
            if (File.Exists(filepath))
            {
                string line;
                // Read the file and display it line by line.
                System.IO.StreamReader file = new System.IO.StreamReader(filepath);
                while ((line = file.ReadLine()) != null)
                {
                    String[] array = line.Split('=');
                    configframe(array);
                }
                file.Close();
            }
        }

        private void configframe(String[] line)
        {
            switch (line[0])
            {
                case "Location":
                    String[] loc = line[1].Split(',');
                    this.StartPosition = FormStartPosition.Manual;
                    this.Location = new Point(int.Parse(loc[0]), int.Parse(loc[1]));
                    break;               
            }
        }

        /// <summary>
        /// Permite ajustar os valores depois de arrancar com o programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSet_Click(object sender, EventArgs e)
        {
            StopLoss.FormSet fs = new StopLoss.FormSet(this, stoploss, handstop, timestop, stopwin);
            fs.Show();
        }

        /// <summary>
        /// recebe os novos valores
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="loss"></param>
        /// <param name="time"></param>
        public void setNewValue(Int64 hand, Double loss, Int32 time, Double win)
        {
            this.timestop = time;
            this.handstop = hand;
            this.stoploss = loss;
            this.stopwin = win;
        }
    }
}
