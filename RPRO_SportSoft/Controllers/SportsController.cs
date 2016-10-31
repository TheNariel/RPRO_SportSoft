using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RPRO_SportSoft.Controllers
{
    public class SportsController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        // GET: Sports
        public ActionResult Index()
        {
            return View(db.Sports.ToList());
            
        }
        // GET: Sports/Details/5
        public ActionResult Details(int? id)
        {
            var item = db.Courts.Where(Court => Court.Sports_Id == id);

            return View(item.ToList());
        }
        // GET: Sports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sports/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name")] Sport s)
        {
            try
            {
                db.Sports.InsertOnSubmit(s);
                db.SubmitChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sports/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Sports.Where(Sport => Sport.Id == id).Single());
        }

        // POST: Sports/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var item = db.Sports.Where(Sport => Sport.Id == id).Single();
               db.Sports.DeleteOnSubmit(item);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
