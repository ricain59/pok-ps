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
        Db db;
        
        public Main()
        {
            InitializeComponent();
            db = new Db();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonTestDb_Click(object sender, EventArgs e)
        {
            db.getData(textBoxUser.Text, textBoxServer.Text, textBoxPort.Text, textBoxPass.Text, textBoxDb.Text);
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

        private void button1_Click(object sender, EventArgs e)
        {
            HandPs ps = new HandPs();
            //ligo me a DB para ir buscar o ultimo id inserido
            String con = db.connectDb();
            if (!con.Equals(""))
            {
                MessageBox.Show(con.ToString());
            }

            //DEPOIS de recuperar o ultimo id pego na mão importado e tenho de verificar se 
            //o meu nome de jogador esta la

            //se sim tratou a mão

            //aqui vou tratar a mão e devolve me os BB perdido ou ganhos

            
        }


    }
}
