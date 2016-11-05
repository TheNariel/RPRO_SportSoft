using RPRO_SportSoft.Application;
using System;
using System.Linq;
using System.Web.Mvc;

namespace RPRO_SportSoft.Controllers
{
    public class SportsController : Controller
    {
        SportsApp app = new SportsApp();
        // GET: Sports
        public ActionResult Index()
        {
           
            return View(app.getList());
            
        }
        // GET: Sports/Details/5
        public ActionResult Details(int? id)
        {
          

            return View();
        }
        // GET: Sports/Create
        public ActionResult Create()
        {
            return View(new SportB(null, true));
        }

        // POST: Sports/Create
        [HttpPost]
        public ActionResult Create(String SportName)
        {
            try
            {
                if (app.Add(SportName))
                {
                    return RedirectToAction("Index");
                }
                else {
                    
                    return View(new SportB(SportName, false));
                }

                
            }
            catch
            {
                return View(new SportB(SportName, true));
            }
        }

        // GET: Sports/Delete/5
        public ActionResult Delete(int id)
        {
            return View(app.get(id));
        }

        // POST: Sports/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                app.delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
