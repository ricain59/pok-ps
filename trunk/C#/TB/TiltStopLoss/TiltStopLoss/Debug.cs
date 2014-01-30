﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace TiltStopLoss
{
    class Debug
    {
        public String getFileName()
        {
            //var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            String startupPath = System.IO.Directory.GetCurrentDirectory();
            //string startupPath2 = Environment.CurrentDirectory;
            //var iconPath = Path.Combine(outPutDirectory, "");
            String icon_path = new Uri(startupPath).LocalPath;
            return icon_path + "\\error\\!!ERROR!!" + DateTime.Now.ToString("yyyy_M_d_HH_MM") + ".txt";            
        }

        public void LogMessage(String message)
        {
            StreamWriter w = new StreamWriter(getFileName(), true);
            w.Write(message);
            w.WriteLine();
            w.Close();
        }
    }
}
