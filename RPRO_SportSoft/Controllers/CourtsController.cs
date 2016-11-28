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
        CourtsApp app = new CourtsApp();

        //
        // GET: Courts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Courts/Create
        public ActionResult Create(int sport)
        {
            Court c = new Court();
            c.Sports_Id = sport;
            return View(c);
        }

        // POST: Courts/Create
        [HttpPost]
        public ActionResult Create(String CourtName,int Id, int Id_P)
        {
            
            try
            {
                if (app.Add(CourtName,Id, Id_P))
                {
                    return RedirectToAction("Details", "Sports", new { id = Id });
                }
                else
                {
                    ViewBag.MyMessageToUser = "Kurt s tímto názvem již existuje.";
                    Court c = new Court();
                    c.Name = CourtName;
                    c.Sports_Id = Id;
                    return View(c);
                }
               
            }
            catch(System.Data.SqlClient.SqlException e )
            {
                ViewBag.MyMessageToUser = "Nelze přidat kurt";
                e.ToString();
                Court c = new Court();
                c.Name = CourtName;
                c.Sports_Id = Id;
                return View(c);
            }
        }

       

        // GET: Courts/Delete/5
        public ActionResult Delete(int id)
        {
            if (app.CheckForRegistration(id))
            {
                ViewBag.MyMessageToUser = "Nelze smazat kurt, který byl použit.";
                return View(app.Get(id));
            }
            else {
                return View(app.Get(id));
            }
            
        }

        // POST: Courts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            int sport=app.GetSportId(id);
            try
            {
                if (app.Delete(id))
                {
                 return RedirectToAction("Details", "Sports", new { id = sport });
                }
                else
                {
                    ViewBag.MyMessageToUser = "Nelze smazat kurt, který byl použit.";
                    return View(app.Get(id));
                }

               
            }
            catch
            {
                ViewBag.MyMessageToUser = "Nelze smazat kurt";
                return View(app.Get(id));
            }
        }

        public ActionResult Edit(int id)
        {
            return View(app.Get(id));
        }

        // POST: Courts/Delete/5
        [HttpPost]
        public ActionResult Edit(int Id, String CourtName,int Sports_Id, int P_Id)
        {
            int sport = app.GetSportId(Id);
            try
            {
                if (app.Edit(Id, CourtName, Sports_Id, P_Id))
                {
                    return RedirectToAction("Details", "Sports", new { id = Sports_Id });
                }
                else
                {
                    ViewBag.MessageEditCourt = "Kurt s tímto názvem již existuje.";
                    return View(app.Get(Id));
                }


            }
            catch
            {
                ViewBag.MessageEditCourt = "Nelze smazat změnit";
                return View(app.Get(Id));
            }
        }
    }
}
