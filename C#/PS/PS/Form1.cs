﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PS
{
    public partial class FormInicial : Form
    {
        Boolean continueDt = false;
        public int initial_y = 354;
        public int initial_x = 159;
        public int hand_y = 518;
        public int hand_x = 187;
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;

        public FormInicial()
        {
            InitializeComponent();

        }

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public const int KEYEVENTF_EXTENDEDKEY = 0x0001; //Key down flag
        public const int KEYEVENTF_KEYUP = 0x0002; //Key up flag
        public const int VK_LCONTROL = 0xA2; //Left Control key code
        public const int A = 0x41; //A Control key code
        public const int C = 0x43; //A Control key code

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "")
            {
                textBoxLogin.Text = "Login here first";
            }
            else
            {
                Boolean contar = true;
                int n = 5;

                while (contar)
                {
                    if (n != 0)
                    {
                        System.Threading.Thread.Sleep(500);
                        n = n - 1;
                    }
                    else
                    {
                        contar = false;
                    }
                }

                continueDt = true;
                //méthode async
                MethodInvoker startdt = new MethodInvoker(Dt);
                startdt.BeginInvoke(null, null);
            }
        }

        public void Dt()
        {
            RecupClipboard handcopy = new RecupClipboard();
            OperationWindow ow = new OperationWindow();
            String loginsend = textBoxLogin.Text.ToString();
            ow.selectLobby(loginsend);            
            int cincominuto = 0;
            while (true)
            {
                while (continueDt)
                {

                    if (cincominuto == 600)
                    //if (cincominuto == 1)
                    {
                        //depois ao fim de 5 minutos fazer uma pausa fechar essas janelas e abrir outras
                        //aqui vou ver as mesas com 0 de contagem
                        ow.closetable();
                        cincominuto = 0;   
                    }

                    cincominuto = cincominuto + 1;

                    Cursor.Position = new Point(initial_x, initial_y);

                    mouse_event(MOUSEEVENTF_LEFTDOWN, initial_x, initial_y, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, initial_x, initial_y, 0, 0);

                    Cursor.Position = new Point(hand_x, hand_y);
                    mouse_event(MOUSEEVENTF_LEFTDOWN, hand_x, hand_y, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, hand_x, hand_y, 0, 0);

                    // Hold Control down and press A
                    keybd_event(VK_LCONTROL, 0, 0, 0);
                    keybd_event(A, 0, 0, 0);
                    keybd_event(A, 0, KEYEVENTF_KEYUP, 0);
                    keybd_event(VK_LCONTROL, 0, KEYEVENTF_KEYUP, 0);

                    // Hold Control down and press C
                    keybd_event(VK_LCONTROL, 0, 0, 0);
                    keybd_event(C, 0, 0, 0);
                    keybd_event(C, 0, KEYEVENTF_KEYUP, 0);
                    keybd_event(VK_LCONTROL, 0, KEYEVENTF_KEYUP, 0);

                    //coller
                    handcopy.getClipboard(ow);

                    System.Threading.Thread.Sleep(500);
                    //System.Threading.Thread.Sleep(1500);
                }
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            continueDt = false;
        }      

    }
}
