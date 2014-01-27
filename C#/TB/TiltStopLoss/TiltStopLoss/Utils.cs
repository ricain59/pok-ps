using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;

namespace TiltStopLoss
{
    class Utils
    {
        public String yearmonth()
        {
            return DateTime.Now.ToString("yyyyMM");
        }
        
    }
}
