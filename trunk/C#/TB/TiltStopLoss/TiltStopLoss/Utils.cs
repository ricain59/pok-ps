using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace TiltStopLoss
{
    class Utils
    {
        public String yearmonth()
        {
            return DateTime.Now.ToString("yyyyMM");
        }

        public void playsound()
        {
            String path = Directory.GetCurrentDirectory();
            String filepath = path + "/alarm.wav";
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(filepath);
            player.PlayLooping();         
        }

        public void onlynumeric(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar)
                    && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            // only allow one decimal point
            //if (e.KeyChar == '.'
            //    && (sender as TextBox).Text.IndexOf('.') > -1)
            //{
            //    e.Handled = true;
            //}
        }
        
    }
}
