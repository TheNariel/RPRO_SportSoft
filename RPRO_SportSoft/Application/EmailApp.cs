using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace RPRO_SportSoft.Application
{
    public class EmailApp
    {
        public void SendEmail(String Sub,String Bod)
        {
          

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress(Properties.Resources.EFrom);
            msg.To.Add("noreplysportsoft@gmail.com");
            msg.Subject = Sub;
            msg.Body = Bod;
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = true;
            client.Host = Properties.Resources.EHost;
            client.Port = Int32.Parse(Properties.Resources.EPort);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(Properties.Resources.ELogin, Properties.Resources.EPass);
            client.Timeout = 20000;
            try
            {
                client.Send(msg);
              
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                msg.Dispose();

            }
        }
    }

}