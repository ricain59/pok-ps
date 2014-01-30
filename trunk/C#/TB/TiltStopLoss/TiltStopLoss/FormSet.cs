using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TiltStopLoss;
using System.IO;

namespace StopLoss
{
    public partial class FormSet : Form
    {
        private Stoploss sl;
        
        public FormSet(Stoploss formsl, Double loss, Int64 hand, Int32 time)
        {
            InitializeComponent();
            sl = formsl;
            textBoxStopHand.Text = hand.ToString();
            textBoxStopLoss.Text = loss.ToString();
            textBoxStopTime.Text = time.ToString();
            loadconfig();
        }

        private void textBoxStopLoss_KeyPress(object sender, KeyPressEventArgs e)
        {
            new Utils().onlynumeric(e);
        }

        private void textBoxStopHand_KeyPress(object sender, KeyPressEventArgs e)
        {
            new Utils().onlynumeric(e);
        }

        private void textBoxStopTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            new Utils().onlynumeric(e);
        }

        private void FormSet_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Ao clicar no botão ok mando a informação para o form stoploss
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            Int64 hand = new Utils().stringtoInt64(textBoxStopHand.Text);
            Double loss = new Utils().stringtoDouble(textBoxStopLoss.Text);
            Int32 time = new Utils().stringtoInt32(textBoxStopTime.Text);
            sl.setNewValue(hand, loss, time);
            this.Close();
        }

        /// <summary>
        /// Permite guardar as configurações da janela
        /// </summary>
        private void loadconfig()
        {
            String path = Directory.GetCurrentDirectory();
            String filepath = path + "/config3.txt";
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

        private void FormSet_FormClosed(object sender, FormClosedEventArgs e)
        {
            String location = this.Location.X.ToString() + ',' + this.Location.Y.ToString();
            String path = Directory.GetCurrentDirectory();
            StreamWriter w = new StreamWriter(path + "/config3.txt", false);
            w.Write("Location=" + location);
            w.WriteLine();
            w.Close();
        }
        
    }
}
