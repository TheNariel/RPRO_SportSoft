using RPRO_SportSoft.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RPRO_SportSoft.Controllers
{
    public class PriceListsController : Controller
    {
        PriceListsApp app = new PriceListsApp();
        // GET: PriceLists
        public ActionResult Index()
        {
            return View(app.GetList());
        }

        // GET: PriceLists/Create
        public ActionResult Create()
        {
            PriceList pl = new PriceList();
            return View(pl);
        }
        // POST: PriceLists/Create
        [HttpPost]
        public ActionResult Create(String Description, int Price)
        {
            app.Add(Description, Price);
            return RedirectToAction("Index");
        }
    }
}