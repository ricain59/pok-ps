using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Threading;

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
        
    }
}
