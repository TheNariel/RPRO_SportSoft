using RPRO_SportSoft.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace RPRO_SportSoft.Controllers
{
    public class MainController : Controller
    {
        UsersApp app = new UsersApp();


        public ActionResult Index()
        {
            Session["Logged"] = "";
            User u = new User();
            u.Email = "";
            return View(u);
        }
        // GET: Main/Create
        public ActionResult Create()
        {
            User u = new User();
            u.Email = "";
            return View(u);
        }
        // POST: Main/Create
        [HttpPost]
        public ActionResult Create(String UserEmail, String UserPass)
        {
            try
            {
                if (app.Add(UserEmail, UserPass))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.MessageCreate = "Uživatel s tímto emailem již existuje";
                    User u = new User();
                    u.Email = "";
                    return View(u);
                }


            }
            catch
            {
                ViewBag.MessageCreate = "Uživatele se nepovedlo vytvořit";
                User u = new User();
                u.Email = "";
                return View(u);
            }
        }
        // POST: Main/Index
        [HttpPost]
        public ActionResult Index(String UserEmail, String UserPass)
        {
            if (app.Login(UserEmail, UserPass))
            {
                Session["Logged"] = UserEmail.ToString();
                return RedirectToAction("Index", "Sports");
            }
            else
            {
                ViewBag.MessageLogin = "Špatně zadaný email nebo heslo! Zkuste to znovu.";
                User u = new User();
                u.Email = "";
                return View(u);
            }
        }

        public void sendEmail()
        {
            SmtpClient smtpClient = new SmtpClient("mail.MyWebsiteDomainName.com", 25);

            smtpClient.Credentials = new System.Net.NetworkCredential("info@MyWebsiteDomainName.com", "myIDPassword");
            smtpClient.UseDefaultCredentials = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();

            //Setting From , To and CC
            mail.From = new MailAddress("info@MyWebsiteDomainName", "MyWeb Site");
            mail.To.Add(new MailAddress("info@MyWebsiteDomainName"));
            mail.CC.Add(new MailAddress("MyEmailID@gmail.com"));

            smtpClient.Send(mail);
        }
    }
}