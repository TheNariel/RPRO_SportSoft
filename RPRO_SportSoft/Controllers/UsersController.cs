using RPRO_SportSoft.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RPRO_SportSoft.Controllers
{
    public class UsersController : Controller
    {
        UsersApp app = new UsersApp();
        // GET: Users
        public ActionResult Index()
        {
            User u = new User();
            u.Email = "";
            return View(u);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            User u = new User();
            u.Email = "";
            return View(u);
        }

        // POST: Users/Create
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
                    return View();
                }

             
            }
            catch
            {
                ViewBag.MessageCreate = "Uživatele se nepovedlo vytvořit";
                return View();
            }
        }

        // POST: User/Login
        [HttpPost]
        public ActionResult Index(String UserEmail, String UserPass)
        {
            if (app.Login(UserEmail, UserPass))
            {
                ViewBag.MessageLogin = UserEmail.ToString();
                return RedirectToAction("Index", "Sports");
            }
            else
            {
                ViewBag.MessageLogin = "Špatně zadaný email nebo heslo! Zkuste to znovu.";
                return RedirectToAction("Index");
            }
        }
        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
