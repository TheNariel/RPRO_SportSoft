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

        // GET: PriceLists/Delete/
        public ActionResult Delete(int Id)
        {
            return View(app.GetListId(Id));
        }

        // POST: PriceLists/Delete/
        [HttpPost]
        public ActionResult Delete(int Id, FormCollection a)
        {
            try
            {
                app.Delete(Id);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.MyMessageToUser = "Tento ceník nelze odstranit, protože byl použit.";
                return View(app.GetListId(Id));


            }
        }
        public ActionResult Edit(int id)
        {
            return View(app.GetListId(id));
        }

        // POST: PriceLists/Delete/
        [HttpPost]
        public ActionResult Edit(int Id, String Description, int Price)
        {
            if(app.Edit(Id, Description, Price))
            {
                return RedirectToAction("Index", "PriceLists", app.GetList());
            }
            else
            {
                ViewBag.MyMessageToUserPriceList = "Pravděpodobně špatně zadané údaje.";
                return View(app.GetListId(Id));
            }
        }

    }
}