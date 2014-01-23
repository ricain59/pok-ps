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
        private String player;
        private Db dbase;
        private HandPs hps;
        private Thread startcrono;
        private Thread startbb;

        public Stoploss(Form wmain, String player, Db db)
        {
            InitializeComponent();
            this.wmain = wmain;
            this.player = player;
            dbase = db;
            //cronometro
            startcrono = new Thread(new ThreadStart(this.stoptimer));
            startcrono.Start();
            //calculo dos BB
            startbb = new Thread(new ThreadStart(this.calculateBB));
            startbb.Start();
            //calculateBB();
        }

        private void Stoploss_Load(object sender, EventArgs e)
        {
        }

        private void Stoploss_FormClosed(object sender, FormClosedEventArgs e)
        {
            wmain.Visible = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            String con = dbase.closeconDb();
            startbb.Abort();
            startcrono.Abort();
            if (!con.Equals(""))
            {
                MessageBox.Show(con.ToString());                
            }
            this.Close();
            wmain.Visible = true;
        }

        private void calculateBB()
        {
            //DEPOIS de recuperar o ultimo id
            Int64 lastid = dbase.getLastValue("handhistories", "handhistory_id");
            //com esse ultimo id sei que tenho que ir daqui para frente para as mãos.
            //CRIO O MEU OBJECTO da class handps
            hps = new HandPs();
            //verifico se tem mais mãos importadas
            Int64 id = lastid;
            int numberhand = 0;
            while (true)
            {
                String hand = dbase.getHand(id);
                if (!hand.Equals(""))
                {
                    if (hand.Contains(player))
                    {
                        numberhand++;
                        id++;
                        //tratar a mão agora
                        hps.getBb(hand, player);
                    }
                }
            }                        
        }

        private void stoptimer()
        {
            int hour = 0;
            int minute = 0;
            int seconde = 0;

            while (true)
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
    }
}
