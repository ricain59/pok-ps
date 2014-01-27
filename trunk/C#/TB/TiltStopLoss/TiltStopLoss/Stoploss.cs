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

namespace TiltStopLoss
{
    delegate void SetTextCallback(string text);
    
    public partial class Stoploss : Form
    {
        private Form wmain;
        private String playerid;
        private Db dbase;
        //private HandPs hps;
        private Thread startcrono;
        private Thread startbb;
        //private Thread starthand;
        private Boolean continu = true;
        private String playername;
        private String stoploss;

        public Stoploss(Form wmain, String playerid, Db db, String playername, String stoploss)
        {
            InitializeComponent();
            this.wmain = wmain;
            this.playerid = playerid;
            this.playername = playername;
            dbase = db;
            this.stoploss = stoploss;
            //cronometro
            startcrono = new Thread(new ThreadStart(this.stoptimer));
            startcrono.Start();
            //calculo dos BB
            startbb = new Thread(new ThreadStart(this.calculateBB));
            startbb.Start();
            //calculateBB();
            //calculo de hands jogadas
            //starthand = new Thread(new ThreadStart(this.calculateHands));
            //starthand.Start();
            
        }


        private void Stoploss_FormClosed(object sender, FormClosedEventArgs e)
        {
            String con = dbase.closeconDb();
            continu = false;
            //Thread.Sleep(2000);
            startbb.Abort();
            startcrono.Abort();
            //starthand.Abort();
            if (!con.Equals(""))
            {
                MessageBox.Show(con.ToString());
            }
            wmain.Visible = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void calculateBB()
        {
            //DEPOIS de recuperar o ultimo id
            String yearmonth = new Utils().yearmonth();
            Double lastid = dbase.getSumBB(playerid, yearmonth);
            Int64 lastidhand = dbase.getLastValue("handhistories", "handhistory_id") + 1;
            //Int64 lastidhand = 5063100;
            Int64 handnumber = 0;

            while (continu)
            {
                //bb
                Double bb = dbase.getSumBB(playerid, yearmonth);
                bb = Math.Round((bb - lastid), 2);
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
                if (bb > Convert.ToDouble(stoploss.ToString()))
                {
                    MessageBox.Show("!!!! Stoploss !!!!");

                }
                //hand
                String hand = dbase.getHand(lastidhand);
                if (!hand.Equals(""))
                {
                    if (hand.Contains(playername))
                    {
                        handnumber++;
                        lastidhand++;
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
                    }
                }
                Thread.Sleep(3000);
            }
        }

        private void calculateHands()
        {
            //pour calculer les hands
            Int64 lastidhand = dbase.getLastValue("handhistories", "handhistory_id") + 1;
            Int64 handnumber = 0;
            while (continu)
            {
                String hand = dbase.getHand(lastidhand);
                if (!hand.Equals(""))
                {
                    if (hand.Contains(playername))
                    {
                        handnumber++;
                        lastidhand++;
                        if (this.labelBb.InvokeRequired)
                        {
                            SetTextCallback d = new SetTextCallback(SetTextBb);
                            this.Invoke(d, new object[] { handnumber.ToString() });
                        }
                        else
                        {
                            // It's on the same thread, no need for Invoke
                            this.labelHands.Text = handnumber.ToString();
                        }
                     }
                }
                Thread.Sleep(3000);
            }
        }

        private void stoptimer()
        {
            int hour = 0;
            int minute = 0;
            int seconde = 0;

            while (continu)
            {
                Thread.Sleep(1000);
                seconde++;
                if (seconde == 60)
                {
                    seconde = 0;
                    minute++;
                    if (minute == 60)
                    {
                        minute = 0;
                        hour++;
                    }
                }
                String minutes;
                if (minute < 10)
                {
                    minutes = "0" + minute;
                }
                else
                {
                    minutes = "" + minute;
                }
                String secondes;
                if (seconde < 10)
                {
                    secondes = "0" + seconde;
                }
                else
                {
                    secondes = "" + seconde;
                }
                String time = "0" + hour + ":" + minutes + ":" + secondes;
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

        private void labelBb_MouseLeave(object sender, EventArgs e)
        {
            labelBb.ForeColor = Color.White;
        }
    }
}
