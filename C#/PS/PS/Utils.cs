using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace PS
{
    class Utils
    {
        public String getipinternet()
        {
            WebClient client = new WebClient();
            String[] ipsplit = client.DownloadString("http://icanhazip.com/").Split('\n');
            return ipsplit[0];
        }
    }
}
