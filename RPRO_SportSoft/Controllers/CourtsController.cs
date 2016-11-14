using RPRO_SportSoft.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RPRO_SportSoft.Controllers
{
    public class CourtsController : Controller
    {
        CourtApp app = new CourtApp();


        // GET: Courts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Courts/Create
        public ActionResult Create(int sport)
        {
            CourtB c = new CourtB("", sport,true);
            return View(c);
        }

        // POST: Courts/Create
        [HttpPost]
        public ActionResult Create(String CourtName,int Id)
        {
            try
            {
                if (app.Add(CourtName,Id))
                {
                    return RedirectToAction("Details", "Sports", new { id = Id });
                }
                else
                {
                    CourtB c = new CourtB(CourtName, Id, false);
                    return View(c);
                }
               
            }
            catch(System.Data.SqlClient.SqlException e )
            {
                e.ToString();
                return View(Id);
            }
        }

       

        // GET: Courts/Delete/5
        public ActionResult Delete(int id)
        {
            return View(app.get(id));
        }

        // POST: Courts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            int sport=app.getSportId(id);
            try
            {
                if (app.delete(id))
                {
                 return RedirectToAction("Details", "Sports", new { id = sport });
                }
                else
                {
                    ViewBag.MyMessageToUser = "Nelze smazat kurt, který byl použit.";
                    return View(app.get(id));
                }

               
            }
            catch
            {
                ViewBag.MyMessageToUser = "Nelze smazat kurt";
                return View(app.get(id));
            }
        }
    }
}
