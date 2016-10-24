using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RPRO_SportSoft.Models;

namespace RPRO_SportSoft.Controllers
{
    public class SportovistesController : Controller
    {
        private SportSoftDBContext db = new SportSoftDBContext();

        // GET: Sportovistes
        public ActionResult Index()
        {
            return View(db.TSportoviste.ToList());
        }

        // GET: Sportovistes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sportoviste sportoviste = db.TSportoviste.Find(id);
            if (sportoviste == null)
            {
                return HttpNotFound();
            }
            return View(sportoviste);
        }

        // GET: Sportovistes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sportovistes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Jmeno")] Sportoviste sportoviste)
        {
            if (ModelState.IsValid)
            {
                db.TSportoviste.Add(sportoviste);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sportoviste);
        }

        // GET: Sportovistes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sportoviste sportoviste = db.TSportoviste.Find(id);
            if (sportoviste == null)
            {
                return HttpNotFound();
            }
            return View(sportoviste);
        }

        // POST: Sportovistes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Jmeno")] Sportoviste sportoviste)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sportoviste).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sportoviste);
        }

        // GET: Sportovistes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sportoviste sportoviste = db.TSportoviste.Find(id);
            if (sportoviste == null)
            {
                return HttpNotFound();
            }
            return View(sportoviste);
        }

        // POST: Sportovistes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sportoviste sportoviste = db.TSportoviste.Find(id);
            db.TSportoviste.Remove(sportoviste);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
