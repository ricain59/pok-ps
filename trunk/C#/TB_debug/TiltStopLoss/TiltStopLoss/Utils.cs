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
            //WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
            //wplayer.URL = filepath;
            //wplayer.settings.setMode("loop", true);
            //wplayer.controls.play(); 
            
            //mp3
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
            String pathfinal2 = pathfinal + "\\config";
            filepath = pathfinal + "\\config_main.txt";
            if (File.Exists(@filepath))
            {
                File.Move(@filepath, pathfinal2 + "\\config_main.txt");
                File.Delete(@filepath);
            }
            filepath = pathfinal + "\\config_stoploss.txt";
            if (File.Exists(@filepath))
            {
                File.Move(@filepath, pathfinal2 + "\\config_stoploss.txt");
                File.Delete(@filepath);
            }
            filepath = pathfinal + "\\config_setnewvalue.txt";
            if (File.Exists(@filepath))
            {
                File.Move(@filepath, pathfinal2 + "\\config_setnewvalue.txt");
                File.Delete(@filepath);
            }
        }

        /// <summary>
        /// close skype
        /// </summary>
        public void detectApps(String nameprocess)
        {
            // Is running
            try
            {
                foreach (Process proc in Process.GetProcessesByName(nameprocess))
                {
                    proc.Kill();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                new Debug().LogMessage(ex.ToString());
            }            
        }

        /// <summary>
        /// string to minute
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public Int32 stringTimeToMinute(String time)
        {
            if (String.IsNullOrEmpty(time))
            {
                return 0;
            }
            else
            {
                String[] timer = time.Split(':');
                return (Convert.ToInt32(timer[0]) * 60 + Convert.ToInt32(timer[1]));
            }
        }

        /// <summary>
        /// int to string 
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public String intToStringTimer(Int32 time)
        {
            if (time < 60)
            {
                if (time >= 10)
                {
                    return "00:" + time + ":00";
                }
                else
                {
                    return "00:0" + time + ":00";
                }
            }
            else
            {
                Int32 hours = 0;
                while (time >= 60)
                {
                    hours++;
                    time = time - 60;
                }
                if (hours >= 10)
                {
                    if (time >= 10)
                    {
                        return hours+":" + time + ":00";
                    }
                    else
                    {
                        return hours+":0" + time + ":00";
                    }                    
                }
                else
                {
                    if (time >= 10)
                    {
                        return "0"+hours + ":" + time + ":00";
                    }
                    else
                    {
                        return "0"+hours + ":0" + time + ":00";
                    }
                }
            }
        }

        /// <summary>
        /// get limit of hand PS
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public Int16 getNlPs(String hand)
        {
            //only nl200
            String[] temp = hand.Split('(');
            String[] temp2 = temp[1].ToString().Split(')');
            
            if (hand.Contains("0.01/") && hand.Contains("0.02"))
            {
                return 2;
            }
            if (hand.Contains("0.02/") && hand.Contains("0.05"))
            {
                return 5;
            }
            if (hand.Contains("0.05/") && hand.Contains("0.10"))
            {
                return 10;
            }
            if (hand.Contains("0.08/") && hand.Contains("0.16"))
            {
                return 16;
            }
            if (hand.Contains("0.10/") && hand.Contains("0.20"))
            {
                return 20;
            }
            if (hand.Contains("0.10/") && hand.Contains("0.25"))
            {
                return 25;
            }
            if (hand.Contains("0.15/") && hand.Contains("0.30"))
            {
                return 30;
            }
            if (hand.Contains("0.25/") && hand.Contains("0.50"))
            {
                return 50;
            }
            if (hand.Contains("0.50/") && hand.Contains("1.00"))
            {
                return 100;
            }
            if (temp2[0].Contains("1/") && temp2[0].Contains("2") && !temp2[0].Contains("."))
            {
                return 200;
            }
            if (temp2[0].Contains("2/") && temp2[0].Contains("4") && !temp2[0].Contains("."))
            {
                return 400;
            }
            if (hand.Contains("2.50/") && hand.Contains("5.00"))
            {
                return 500;
            }
            return 0;
        } 
    }
}
