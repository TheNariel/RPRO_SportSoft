using RPRO_SportSoft.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public ActionResult SendEmail()
        {
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("noreplysportsoft@gmail.com");
            msg.To.Add("noreplysportsoft@gmail.com");
            msg.Subject = "Hello world! " + DateTime.Now.ToString();
            msg.Body = "hi to you ... :)";
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("noreplysportsoft@gmail.com", "rpro2016");
            client.Timeout = 20000;
            try
            {
                client.Send(msg);
                ViewBag.MessageEmail = "email odeslán";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.MessageEmail = "error:"+ex;
                return View();
            }
            finally
            {
                msg.Dispose();
                
            }
        }
    }
}
