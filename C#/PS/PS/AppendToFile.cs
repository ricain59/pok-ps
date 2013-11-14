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

        public void AppendToFileDT(String handcopy, String date)
        {
            String path = "E:/HH" + fdt + "_" + date + ".txt";
            //File file = new File("E:/HH" + fdt + "_" + date + ".txt");
            ndt = ndt + 1;

            //true = append file
            StreamWriter w = new StreamWriter(path, true);
            w.Write(handcopy);
            w.WriteLine();
            w.WriteLine();
            w.Close();
            
            if (ndt == 1000)
            {
                fdt = fdt + 1;
                ndt = 0;
            }
        }

    }
}
