using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TiltStopLoss;

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

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Int64 hand;
            Double loss;
            Int32 time;
            if(textBoxStopHand.Text.Equals(""))
            {
                hand = 0;
            }
            else
            {
                hand = Convert.ToInt64(textBoxStopHand.Text.ToString());
            }
            if(textBoxStopLoss.Text.Equals(""))
            {
                loss = 0.0;
            }else{
                loss = Convert.ToDouble(textBoxStopLoss.Text.ToString());
            }
            if(textBoxStopTime.Text.Equals(""))
            {
                time = 0;
            }else{
                time = Convert.ToInt32(textBoxStopTime.Text.ToString());
            }
            sl.setNewValue(hand, loss, time);
            this.Close();
        }
        
    }
}
