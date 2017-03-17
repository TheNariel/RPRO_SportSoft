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
        public ActionResult Create( String UserEmail, String UserPass, String UserPass2, String Name, String SurName, String Phone)
        {
            try
            {
                if (app.CheckPassword(UserPass, UserPass2))
                {
                    if (app.Add(UserEmail, UserPass, Name, SurName, Phone))
                    {

                        EmailApp Eapp = new EmailApp();
                        String body = String.Format(Properties.Resources.EReg, UserEmail);
                        Eapp.SendEmail("Vaše registrace", body, UserEmail);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.MessageCreate = "Účet s tímto emailem již existuje.";
                        User u = new User();
                        u.Email = "";
                        return View(u);
                    }
                }
                else {
                    ViewBag.MessageCreate = "Hesla se neshodují.";
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

        public ActionResult Edit(String e)
        {
            return View(app.GetUser(e));
        }

        // POST: Main/Edit
        [HttpPost]
        public ActionResult Edit(String oldEmail, String Name, String SurName, String Phone)
        {
            try
            {
                if (app.CheckForWhiteSpaces(Name, SurName))
                {

                    if (app.Edit(oldEmail, Name, SurName, Phone))
                    {
                        return RedirectToAction("Account", "Main", app.GetUser(oldEmail));
                    }
                    else
                    {
                        ViewBag.MyMessageToUser = "Pravděpodobně špatně zadané telefnní číslo.";
                        return View(app.GetUser(oldEmail));
                    }

                }
                else
                {
                    ViewBag.MyMessageToUser = "Musíte vyplnit všechny pole.";
                    return View(app.GetUser(oldEmail));
                }


            }
            catch
            {
                ViewBag.MyMessageToUser = "Vyplňte všechny údaje správně!";
                return View(app.GetUser(oldEmail));


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
        public ActionResult Account(String email) {
            return View(app.GetUser(email));
        }
        public ActionResult Users()
        {
            F.Mflag = 3;
            return View(app.GetUserList());
        }

        public  ActionResult ChangeActive(String Email)
        {
            if (app.GetUser(Email).Active.Equals("Yes"))
            {
                app.DeactivateUser(Email);
            }
            else
            {
                app.ActivateUser(Email);
            }
            IEnumerable<User> model = app.GetUserListSorted(F.Mflag);
            return PartialView("ListUser", model); 
        }

        public ActionResult SortUsers(int flag)
        {
            F.Mflag = flag;
            IEnumerable<User> model = app.GetUserListSorted(flag);
            return PartialView("ListUser", model);
        }
        public ActionResult EditPass(String e)
        {
            return View(app.GetUser(e));
        }
        // POST: Main/EditPass
        [HttpPost]
        public ActionResult EditPass(String e, String oldPass, String newPass, String newPass2)
        {
            if (app.ChangingPassword(e, oldPass, newPass, newPass2))
            {
                ViewBag.MessagePasswordChanged = "Heslo změněno.";
                return RedirectToAction("Account", "Main", app.GetUser(e));
            }
            else {
                ViewBag.MessageChangingPassword = "Špatně vypsané údaje!";
                return View(app.GetUser(e));
            }
            
        }
        public ActionResult ForgottenPass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgottenPass(String e)
        {
            String newPass = app.ForgottenPass(e);
            EmailApp Eapp = new EmailApp();
            String body = String.Format(Properties.Resources.EForgPass, newPass);
            Eapp.SendEmail("Zapomenuté heslo", body, e);
            ViewBag.MessageForgottenPass = "Nové heslo odesláno na email.";
            return View();
        }
    }
}
