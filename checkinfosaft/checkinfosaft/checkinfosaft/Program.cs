using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.IO;

namespace checkinfosaft
{
    class Program
    {
        static void Main(string[] args)
        {
            String folder = "C:\\ProgramData\\InfoSAFT\\FTP\\BACKUP";            
            //String folder = "C:";
            string[] filePaths = Directory.GetFiles(@"" + folder, "*.txt");

            Boolean faultfile = false;
            int daytoday = DateTime.Now.DayOfYear;
            //vou percorrer os ficheiros
            foreach (String fi in filePaths)
            {
                //System.IO.File.GetLastWriteTime
                Console.WriteLine(fi.ToString());
                int lastmodified = File.GetLastWriteTime(fi).DayOfYear;
                if (daytoday == lastmodified)
                {
                    faultfile = true;
                }
                if (faultfile) break;
            }


            if (!faultfile)
            {
                SmtpClient client = new SmtpClient();
                client.Port = 25;
                client.Host = "219.21.221.141";
                client.EnableSsl = false;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;
                client.Credentials = new System.Net.NetworkCredential("backup@fafedis.pt", "backup");

                MailMessage mm = new MailMessage("backup@fafedis.pt", "informatica@fafedis.pt", "Problema infosaft", "Falta ficheiros do dia de ontem");
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
            }
        }
    }
}
