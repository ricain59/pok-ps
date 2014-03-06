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
using System.Runtime.InteropServices;

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
        private Double bbpeak;
        private Double peakover;
        Int64 handnumber = 0;
        private String[] sounds;
        Double bbmax;
        private Boolean sitout = true;
        private Int32 blocklimit;

        public Stoploss(Main wmain, List<Tuple<String,String>> playerid, Db db, String[] data, Boolean hidebb, Boolean buttonset, Int32 limit, String[] sound, int tracker)
        {
            InitializeComponent();
            this.wmain = wmain;
            playeridname = playerid;
            dbase = db;
            this.stoploss = new Utils().stringtoDouble(data[0]);
            handstop = new Utils().stringtoInt64(data[1]);
            timestop = new Utils().stringtoInt32(data[2]);
            stopwin = new Utils().stringtoDouble(data[3]);
            bbpeak = new Utils().stringtoDouble(data[4]);
            this.peakover = new Utils().stringtoDouble(data[5]);
            this.tracker = tracker;
            sounds = sound;
            blocklimit = limit;
            if (hidebb)
            {
                labelBb.Enabled = false;
                labelBb.Visible = false;
            }
            buttonSet.Visible = buttonset;
            loadconfig();
            //cronometro
            startcrono = new Thread(new ThreadStart(this.stoptimer));
            startcrono.Start();
            //calculo dos BB e hands
            startbb = new Thread(new ThreadStart(this.calculateBB));
            startbb.Start();            
        }

        /// <summary>
        /// Quando fecho o form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            StreamWriter w = new StreamWriter(path + "/config/config_stoploss.txt", false);
            w.Write("Location=" + location);
            w.WriteLine();
            w.Close();
            
            startbb.Abort();
            startcrono.Abort();
            
            wmain.setNewValue(handstop.ToString(), stoploss.ToString(), timestop.ToString(), stopwin.ToString(), bbpeak.ToString());
            wmain.setValueSession(handnumber.ToString(), time, bb, bbmax);
            wmain.Visible = true;            
        }

        /// <summary>
        /// Para lançar o método do close form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStop_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        /// <summary>
        /// Calcula os bb e hand para o stop
        /// </summary>
        private void calculateBB()
        {
            String yearmonth;
            Double bbinit = 0.0;
            Int64 lastidhand = 0;
            Int64 lastidsessionpt4 = 0;
            //permite definir aqui os valores iniciais de bbinit e lastidhand
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
                lastidsessionpt4 = dbase.getLastValue("cash_table_session_summary", "id_session") + 1;
                //vou buscar o last idhand de pt4
                lastidhand = dbase.getLastValue("cash_hand_histories", "id_hand") + 1;
            }

            //aqui é feito o resto dos calculos e das diferenças
            try
            {
                bbmax = 0.0;
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

                    //stop
                    if (stoploss > 0.0)
                    {
                        if (bb <= (0 - stoploss))
                        {
                            if (!stop)
                            {
                                player = new Utils().playsound(sounds[0]);
                                player.PlayLooping();
                                stop = true;
                                //buttonSoundStop.Visible = true;
                                labelStopSet("!!!! StopLoss !!!!", Color.Red);
                            }                            
                        }
                    }
                    if (stopwin > 0.0)
                    {
                        if (bb >= stopwin)
                        {
                            if (!stop)
                            {
                                player = new Utils().playsound(sounds[2]);
                                player.PlayLooping();
                                stop = true;
                                //buttonSoundStop.Visible = true;
                                labelStopSet("!!!! StopWin !!!!", Color.Green);
                            }                            
                        }
                    }
                    if (bbpeak > 0.0)
                    {
                        if (bb > bbmax)
                        {
                            bbmax = bb;
                        }
                        else
                        {
                            if ((bbmax - bb) >= bbpeak && bbmax >= peakover)
                            {
                                if (!stop)
                                {
                                    player = new Utils().playsound(sounds[0]);
                                    player.PlayLooping();
                                    stop = true;
                                    //buttonSoundStop.Visible = true;
                                    labelStopSet("!!!! StopPeak !!!!", Color.Red);
                                }                                
                            }
                        }
                    }                    

                    //hand
                    String hand = "";
                    //aqui vou buscar a hand para depois ver os limites e contar as hands para hem1 e hem2
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


                    if (tracker == 1 || tracker == 2)
                    {
                        if (!hand.Equals(""))
                        {
                            lastidhand++;
                            for (int i = 0; i < playeridname.Count; i++)
                            {
                                if (hand.Contains(playeridname[i].Item2) && !hand.Contains("Tournament"))
                                {
                                    handnumber++;                                    
                                }
                            }
                        }
                    }
                    else
                    {
                        //pt4
                        handnumber = 0;
                        for (int i = 0; i < playeridname.Count; i++)
                        {
                            handnumber += dbase.getHandPt4(playeridname[i].Item1, lastidsessionpt4);
                        }
                    }
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
                                player = new Utils().playsound(sounds[3]);
                                player.PlayLooping();
                                stop = true;
                                //buttonSoundStop.Visible = true;
                                labelStopSet("!!!! StopHand !!!!", Color.Blue);
                            }                            
                        }
                    }
                    //stoplimit
                    if (blocklimit != 0)
                    {
                        stopLimit(hand);
                    }
                    Thread.Sleep(250);
                }
            }
            catch (Exception ex)
            {
                new Debug().LogMessage(ex.ToString());
            }
        }

        /// <summary>
        /// stoplimit for brm
        /// </summary>
        /// <param name="hand"></param>
        private void stopLimit(String hand)
        {
            Int16 nl = 0;
            for (int i = 0; i < playeridname.Count; i++)
            {
                if (hand.Contains(playeridname[i].Item2))
                {
                    if (hand.ToLower().Contains("pokerstars") && !hand.ToLower().Contains("tournament"))
                    {
                        nl = new Utils().getNlPs(hand);
                        if (nl.Equals(0))
                        {
                            new Debug().LogAlert("Problem limit not defined", "Problem_Limit");
                        }
                        else
                        {
                            //je vérifie si la limite rendu é supériru a la limite accepter
                            if (nl > blocklimit)
                            {
                                //aqui apita e change le text du label
                                if (!stop)
                                {
                                    player = new Utils().playsound(sounds[0]);
                                    player.PlayLooping();
                                }
                                stop = true;
                                //buttonSoundStop.Visible = true;
                                labelStopSet("!!!! StopLoss !!!!", Color.Red);
                                //close poker stars
                                new Utils().detectApps("PokerStars");
                            }
                        }
                    }
                }
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
                while (sitout)
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
                                player = new Utils().playsound(sounds[1]);
                                player.PlayLooping();
                                stop = true;
                                //buttonSoundStop.Visible = true;
                                labelStopSet("!!!! StopTime !!!!", Color.Black);
                            }                            
                        }
                    }
                }
            }
        }

        #region set label
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
        #endregion

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

        #region load config
        /// <summary>
        /// carregas as configs
        /// </summary>
        private void loadconfig()
        {
            String path = Directory.GetCurrentDirectory();
            String filepath = path + "/config/config_stoploss.txt";
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

        #endregion

        /// <summary>
        /// Permite ajustar os valores depois de arrancar com o programa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSet_Click(object sender, EventArgs e)
        {
            StopLoss.FormSet fs = new StopLoss.FormSet(this, stoploss, handstop, timestop, stopwin, bbpeak);
            fs.Show();
        }

        /// <summary>
        /// recebe os novos valores
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="loss"></param>
        /// <param name="time"></param>
        public void setNewValue(Int64 hand, Double loss, Int32 time, Double win, Double losspeak)
        {
            this.timestop = time;
            this.handstop = hand;
            this.stoploss = loss;
            this.stopwin = win;
            this.bbpeak = losspeak;
        }

        /// <summary>
        /// permite clicar e fazer um stop ao tempo em caso de sitout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelTimer_Click(object sender, EventArgs e)
        {
            if (sitout)
            {
                sitout = false;
                labelStopSet("!!!! Timer Stopped !!!!", Color.Blue);
            }
            else
            {
                sitout = true;
                labelStopSet("", Color.Blue);
            }
        }
    }
}
