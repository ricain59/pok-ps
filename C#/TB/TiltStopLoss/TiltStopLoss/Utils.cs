﻿using System;
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
        /// <summary>
        /// Devolve o ano e mês que serve para o pedido a DB sobre os BBs
        /// </summary>
        /// <returns></returns>
        public String yearmonth()
        {
            return DateTime.Now.ToString("yyyyMM");
        }

        /// <summary>
        /// Toca a musica chata do stop
        /// </summary>
        public void playsound()
        {
            String path = Directory.GetCurrentDirectory();
            String filepath = path + "/alarm.wav";
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(filepath);
            player.PlayLooping();         
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
        
    }
}
