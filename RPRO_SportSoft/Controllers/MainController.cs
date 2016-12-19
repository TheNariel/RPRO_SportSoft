using RPRO_SportSoft.Application;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            Session["Role"] = "Undefined";
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
        public ActionResult Create(String UserEmail, String UserPass, String UserRole)
        {
            try
            {
                if (app.Add(UserEmail, UserPass, UserRole))
                {
                    EmailApp Eapp = new EmailApp();
                    String body = String.Format(Properties.Resources.EReg, UserEmail);
                    Eapp.SendEmail("Registrace", body);
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
                Session["Role"] = app.GetUser(UserEmail).Role.ToString();
                Session["Logged"] = UserEmail.ToString();
                return RedirectToAction("Index", "Sports");
            }
            else
            {
                ViewBag.MessageLogin = "Špatně zadaný email nebo heslo!  Zkuste to znovu.";
                User u = new User();
                u.Email = "";
                return View(u);
            }
        }

       
        public ActionResult Contacts()
        {
            return View();
        }
        public ActionResult Rules()
        {
            return View();
        }
        public ActionResult Account() {
            return View();
        }
    }
}
