using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PS
{
    class AppendToFile
    {
        public int ndt = 0;
        public int fdt = 0;

        public void AppendToFileDT(String handcopy, String date, Boolean down)
        {
            String nl = getNL(handcopy);
            String path = "";
            if (down)
            {
                path = "E:/HH" + fdt + "_" + date + "_" + nl + "_up.txt";
            }
            else
            {
                path = "E:/HH" + fdt + "_" + date + "_" + nl + "_down.txt";
            }
            
            //File file = new File("E:/HH" + fdt + "_" + date + ".txt");
            ndt = ndt + 1;

            //true = append file
            StreamWriter w = new StreamWriter(path, true);
            w.Write(handcopy);
            w.WriteLine();
            w.WriteLine();
            w.Close();
            
            if (ndt == 500)
            {
                fdt = fdt + 1;
                ndt = 0;
            }
        }

        public String getNL(String hand)
        {
            if (hand.Contains("0.02/") && hand.Contains("0.05"))
            {
                return "nl5";
            }
            if(hand.Contains("0.05/") && hand.Contains("0.10"))
            {
                return "nl10";
            }             
            if (hand.Contains("0.08/") && hand.Contains("0.16"))
            {
                return "nl16";
            }
            if (hand.Contains("0.10/") && hand.Contains("0.25"))
            {
                return "nl25";
            }
            if (hand.Contains("0.25/") && hand.Contains("0.50"))
            {
                return "nl50";
            }
            if (hand.Contains("0.50/") && hand.Contains("1"))
            {
                return "nl100";
            }
            return "_";
        }

    }
}
