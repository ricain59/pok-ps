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
using System.Globalization;
using System.Diagnostics;

namespace TiltStopLoss
{
    class Utils
    {
        /// <summary>
        /// Devolve o ano e mês que serve para o pedido a DB sobre os BBs
        /// </summary>
        /// <returns></returns>
        public String yearmonth()
        {
            return DateTime.Now.ToString("yyyyMM");
        }

        /// <summary>
        /// Devolve o ano e semana que serve para o pedido a DB sobre os BBs
        /// </summary>
        /// <returns></returns>
        public String yearweek()
        {
            DateTime date = DateTime.Now;
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                date = date.AddDays(3);
            }
            // Return the week of our adjusted day
            int week = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            String weekfin = "";
            if (week < 10)
            {
                weekfin = "0" + week.ToString();
            }
            else
            {
                weekfin = week.ToString();
            }
            return DateTime.Now.ToString("yyyy") + weekfin;
        }

        /// <summary>
        /// Toca a musica chata do stop
        /// </summary>
        public System.Media.SoundPlayer playsound(String sound)
        {
            String path = Directory.GetCurrentDirectory();
            String filepath = path + "\\sounds\\" +sound;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(filepath);
            //player.PlayLooping();            
            return player;
        }

        /// <summary>
        /// Serve para as textbox
        /// Só permite inserir numeros
        /// </summary>
        /// <param name="e"></param>
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

        /// <summary>
        /// String to int64
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Int64 stringtoInt64(String value)
        {
            if (value.Equals(""))
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(value);
            }
        }

        /// <summary>
        /// String to double
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Double stringtoDouble(String value)
        {
            if (value.Equals(""))
            {
                return 0.0;
            }
            else
            {
                return Convert.ToDouble(value);
            }
        }

        /// <summary>
        /// String to int32
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Int32 stringtoInt32(String value)
        {
            if (value.Equals(""))
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(value);
            }
        }

        /// <summary>
        /// copy file source to folder software
        /// </summary>
        /// <param name="path"></param>
        public void copyFile(String path)
        {
            String pathfinal = Directory.GetCurrentDirectory();
            String fileName = System.IO.Path.GetFileName(path);
            String destFile = System.IO.Path.Combine(pathfinal+"\\sounds", fileName);
            System.IO.File.Copy(path, destFile, true);
        }

        /// <summary>
        /// delete sound from original path because exist in new path
        /// </summary>
        public void deleteSound()
        {
            String pathfinal = Directory.GetCurrentDirectory();
            String filepath = pathfinal + "\\alarm.wav";
            if (File.Exists(@filepath))
            {
                File.Delete(@filepath);
            }
        }

        /// <summary>
        /// change name file config
        /// </summary>
        public void changeFileConfig()
        {
            String pathfinal = Directory.GetCurrentDirectory();
            String filepath = pathfinal + "\\config.txt";
            if (File.Exists(@filepath))
            {
                File.Move(@filepath, pathfinal+"\\config_main.txt");
                File.Delete(@filepath);
            }
            filepath = pathfinal + "\\config2.txt";
            if (File.Exists(@filepath))
            {
                File.Move(@filepath, pathfinal + "\\config_stoploss.txt");
                File.Delete(@filepath);
            }
            filepath = pathfinal + "\\config3.txt";
            if (File.Exists(@filepath))
            {
                File.Move(@filepath, pathfinal + "\\config_setnewvalue.txt");
                File.Delete(@filepath);
            }
        }

        /// <summary>
        /// close skype
        /// </summary>
        public void detectApps()
        {
            // Is running
            try
            {
                foreach (Process proc in Process.GetProcessesByName("Skype"))
                {
                    proc.Kill();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }            
        }
    }
}
