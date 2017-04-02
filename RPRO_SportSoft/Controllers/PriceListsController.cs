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
        public ActionResult Create(String description, int price)
        {
            try
            {
                if (!app.CheckIfTaken(description))
                {
                    app.Add(description, price);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.MessageCreate = "Ceník s tímto názvem již existuje.";
                    PriceList p = new PriceList();
                    return View(p);
                }
            }
            catch
            {
                ViewBag.MessageCreate = "Ceník se nepovedlo vytvořit.";
                PriceList p = new PriceList();
                return View(p);
            }

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
                if (app.CheckIfExist(Id)) {
                    app.Delete(Id);
                }
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
        public ActionResult Edit(int id, String description, int price)
        {
            try
            {
                if (!app.CheckIfTakenEdit(description, id))
                {
                    app.Edit(id, description, price);
                    return RedirectToAction("Index", "PriceLists", app.GetList());
                }
                else
                {
                    ViewBag.EditMessage = "Ceník s tímto názvem již existuje.";
                    return View(app.GetListId(id));
                }
            }
            catch
            {
                ViewBag.MessageCreate = "Údaje se nepovedlo uložit.";
                PriceList p = new PriceList();
                return View(p);
            }
        }
    }
}
