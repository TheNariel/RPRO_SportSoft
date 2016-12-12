using RPRO_SportSoft.Application;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web.Mvc;

namespace RPRO_SportSoft.Controllers
{
    public class SportsController : Controller
    {
        SportsApp app = new SportsApp();
        ReservationsApp appR = new ReservationsApp();

        // GET: Sports
        public ActionResult Index()
        {
            return View(app.GetList());
        }

        // GET: Sports/Details/5
        public ActionResult Details(int id)
        {
            var Reservations = new Dictionary<string, List<int>>();
            IEnumerable<Court> courts = app.GetCourts(id);
            List<Reservation_Time> times = appR.GetListOfTimeReservations();

            foreach (var c in courts) {
                Reservations[c.Name] = appR.GetReservations(c.Id, new DateTime(2016, 12, 15));
           }
            ViewBag.Reservations = Reservations;
            ViewBag.Times = times;

            CourtListP CourtList = new CourtListP(id, app.GetName(id), app.GetCourts(id));
            return View(CourtList);
        }

        // GET: Sports/Create
        public ActionResult Create()
        {
            Sport s = new Sport();
            s.Name = "";
            return View(s);
        }

        // POST: Sports/Create
        [HttpPost]
        public ActionResult Create(String SportName, String image)
        {
            try
            {
                if (app.CheckForWhiteSpaces(SportName)) 
                {
                    if (app.Add(SportName, image))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.MessageCreate = "Sportoviště s tímto názvem již existuje.";
                        Sport s = new Sport();
                        s.Name = SportName;
                        return View(s);

                    }

                }
                else {
                    ViewBag.MessageCreate = "Musíte vyplnit název sportoviště.";
                    Sport s = new Sport();
                    s.Name = SportName;
                    return View(s);
                }

            }
            catch
            {
                Sport s = new Sport();
                s.Name = SportName;
                ViewBag.MessageCreate = "Sportoviště se nepovedlo vytvořit";
                return View(s);
            }
        }

        // GET: Sports/Delete/5
        public ActionResult Delete(int id)
        {
            return View(app.Get(id));
        }

        // POST: Sports/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                app.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.MyMessageToUser = "Toto sportoviště nelze odstranit, protože obsahuje kurty.";
                return View(app.Get(id));


            }
        }
        public ActionResult Edit(int id)
        {
            return View(app.Get(id));
        }
        [HttpPost]
        public ActionResult Edit(int id, String SportName, String image)
        {
            try
            {
                if (app.CheckForWhiteSpaces(SportName)) {

                    if (app.Edit(id, SportName, image))
                    {

                        return RedirectToAction("Index");
                    }
                    else {
                        ViewBag.MyMessageToUser = "Název musí být unikátní.";
                        return View(app.Get(id));
                    }

                }
                else {
                    ViewBag.MyMessageToUser = "Musíte vyplnit název sportoviště.";
                    return View(app.Get(id));
                }
                
                
            }
            catch
            {
                ViewBag.MyMessageToUser = "Toto sportoviště nelze editovat.";
                return View(app.Get(id));


            }
        }

        public ActionResult Reservation(String time,String sport)
        {
            ViewBag.Time = time;
            ViewBag.Sport = sport;
            return View();
        }
    }
}
