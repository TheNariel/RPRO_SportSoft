using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RPRO_SportSoft.Controllers
{
    public class CourtsController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        int s;
        // GET: Courts
        public ActionResult Index()
        {
            return View(db.Courts.ToList());
        }

        // GET: Courts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Courts/Create
        public ActionResult Create(int sport)
        {
           this.s = sport;
            return View();
        }

        // POST: Courts/Create
        [HttpPost]
        public ActionResult Create(String CourtName)
        {
            try
            {
                Court k = new Court();
                k.Name = CourtName;
                k.Sports_Id = s;
                db.Courts.InsertOnSubmit(k);
                db.SubmitChanges();
               
                return RedirectToAction("Details", "Sports" ,new { id = s });
            }
            catch(System.Data.SqlClient.SqlException e )
            {
                e.ToString();
                return View();
            }
        }

        // GET: Courts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Courts/Edit/5
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

        // GET: Courts/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Courts.Where(Court => Court.Id == id).Single());
        }

        // POST: Courts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var item = db.Courts.Where(Court => Court.Id == id).Single();
                db.Courts.DeleteOnSubmit(item);
                db.SubmitChanges();

                return RedirectToAction("Index","Main");
            }
            catch
            {
                return View();
            }
        }
    }
}
