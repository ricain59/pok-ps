using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TiltStopLoss
{
    public partial class Main : Form
    {
        private Db db = new Db();
        
        public Main()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void buttonTestDb_Click(object sender, EventArgs e)
        {
            db.getData(textBoxUser.Text, textBoxServer.Text, textBoxPort.Text, textBoxPass.Text, textBoxDb.Text, textBoxPlayer.Text);
            String testconnect = db.testconnectDb();
            if (testconnect.Equals(""))
            {
                MessageBox.Show("Test connection OK");
            }
            else
            {
                MessageBox.Show(testconnect);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Boolean stop = false;
            //ligo me a DB para ir buscar o ultimo id inserido
            String con = db.connectDb();
            if (!con.Equals(""))
            {
                MessageBox.Show(con.ToString());
                stop = true;
            }
            //se dá erro a me ligar a DB não faço mais nada
            //aqui tenho de abrir a outra janela que vai ficar a funcar em paralela dessa
            if (!stop)
            {
                this.Visible = false;
                Stoploss sl = new Stoploss(this, textBoxPlayer.Text, db);
                sl.Show();
                //sl.beginBB(this, textBoxPlayer.Text, db);
            }
        }

        
    }
}
