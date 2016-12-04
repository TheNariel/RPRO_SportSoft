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
        public void SendEmail()
        {
           Email E = SetEmailInfo();

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress(E.From);
            msg.To.Add("noreplysportsoft@gmail.com");
            msg.Subject = "H! " + DateTime.Now.ToString();
            msg.Body = "hi ...";
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = true;
            client.Host = E.Host;
            client.Port = E.Port;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential(E.Login,E.Pass);
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

        public Email SetEmailInfo()
        {
            String from="", host = "", login = "", pass = "";
            int port = 0;
            XDocument settings = XDocument.Parse(Properties.Resources.Email);
            IEnumerable<XElement> Sett = settings.Elements();
            foreach (var S in Sett)
            {
                from = S.Element("From").Value;
                host = S.Element("Host").Value;
                port = Int32.Parse(S.Element("Port").Value);
                login = S.Element("Login").Value;
                pass = S.Element("Pass").Value;
            }
           
            return new Email(from,host,port,login,pass);
        }

    }
}