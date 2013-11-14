using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PS
{
    class OperationWindow
    {
        List<Tuple<String, int>> list;
        int numbertable = 1;

        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImportAttribute("User32.dll")]
        private static extern int SetForegroundWindow(int hWnd);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);


        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_CLOSE = 0xF060;
        const UInt32 WM_CLOSE = 0x0010;
        const int VK_UP = 0x26; //key up
        const int VK_DOWN = 0x28; //key down
        public const int KEYEVENTF_KEYUP = 0x0002; //Key up flag
        const int VK_RETURN = 0x0D; //enter key
        const int VK_ENTER = 13;

        
        public void getAllWindow()
        {
            if (list.Count != 0)
            {
                list = new List<Tuple<String, int>>();
            }

            Process[] processlist = Process.GetProcesses();
            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    if (process.MainWindowTitle.Contains("No Limit Hold"))
                    {
                        //Console.WriteLine("Process: {0} ID: {1} Window title: {2}", process.ProcessName, process.Id, process.MainWindowTitle);
                        //Adria III - $0.05/$0.10 USD - No Limit Hold'em
                        //numbertable = numbertable + 1;
                        addToList(process.MainWindowTitle, true);
                    }
                }
            }
        }

        public void addToList(String table, Boolean origin)
        {
            if (origin)
            {
                list.Add(Tuple.Create(table, 0));
            }
            else
            {
                table = table.Replace('\'', '_');
                String[] tablearray = table.Split('_');
                
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Item1.Contains(tablearray[2]))
                    {
                        int j = list[i].Item2;
                        String nametable = list[i].Item1;
                        list.RemoveAll(item => item.Item1 == nametable);
                        list.Add(Tuple.Create(nametable, (j + 1)));
                    }
                }
                
            }  
        }

        public void closetable()
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Item2 == 0)
                {
                    IntPtr windowPtr = FindWindowByCaption(IntPtr.Zero, list[i].Item1);
                    SendMessage(windowPtr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                    numbertable = numbertable - 1;
                }                
            }
            selectLobby();
        }

        public void selectLobby()
        {
            //to activate an application
            list = new List<Tuple<String, int>>();
            
            Boolean first = true;
            for (numbertable = numbertable + 0; numbertable < 19; numbertable++)
            {
                int hWnd = FindWindow(null, "PokerStars Lobby - Logged in as tgt_59100");
                SetForegroundWindow(hWnd);
                if (first)
                {
                    for (int i = 0; i < 30; i++)
                    {
                        keybd_event(VK_UP, 0, 0, 0);
                        keybd_event(VK_UP, 0, KEYEVENTF_KEYUP, 0);
                    }
                    first = false;
                }
                keybd_event(VK_DOWN, 0, 0, 0);
                keybd_event(VK_DOWN, 0, KEYEVENTF_KEYUP, 0);
                keybd_event(VK_RETURN, 0, 0, 0);
                keybd_event(VK_RETURN, 0, KEYEVENTF_KEYUP, 0);
                System.Threading.Thread.Sleep(1000);
                //System.Windows.Forms.MessageBox.Show(""+numbertable);

            }
            numbertable = 19;
            getAllWindow();
            
            int hWndhh = FindWindow(null, "Instant Hand History");
            if (hWndhh > 0)
            {
                SetForegroundWindow(hWndhh);
            }
        }

    }
}
