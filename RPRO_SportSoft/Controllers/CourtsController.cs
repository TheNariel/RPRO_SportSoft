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
        ReservationsApp appR = new ReservationsApp();
        PriceListsApp appPL = new PriceListsApp();

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
        public ActionResult Create(String CourtName,int Id, String De_P)
        {
            int Id_P = appPL.GetId(De_P);
            try
            {
                if (app.CheckForWhiteSpaces(CourtName)) 
                {
                    if (app.Add(CourtName, Id, Id_P))
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
                else
                {
                    ViewBag.MyMessageToUser = "Musíte vyplnit název kurtu.";
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
        public ActionResult Edit(int Id, int Sports_Id, String CourtName, String De_P, DateTime date)
        {
            int Id_P = appPL.GetId(De_P);
            int sport = app.GetSportId(Id);
            try
            {
                if (app.CheckForWhiteSpaces(CourtName)) {

                    if (app.Edit(Id, CourtName, Sports_Id, Id_P, date))
                    {
                        return RedirectToAction("Details", "Sports", new { id = Sports_Id });
                    }
                    else {
                        ViewBag.MessageEditCourt = "Kurt s tímto názvem již existuje.";
                        return View(app.Get(Id));
                    }

                }
                else
                {
                    ViewBag.MessageEditCourt = "Musíte vyplnit název kurtu.";
                    return View(app.Get(Id));

                }


            }
            catch
            {
                ViewBag.MessageEditCourt = "Nelze smazat změnit";
                return View(app.Get(Id));
            }
        }

        public ActionResult Reservation(int id) {
            Reservation r = new Reservation();            
            return View(r);
        }

        [HttpPost]
        public ActionResult Reservation(int id, DateTime date)
        {
            try
            {
                if (appR.Add(id, date))
                {
                    return RedirectToAction("IndexR");
                }
                else
                {
                    ViewBag.MyMessageToUser = "Tento kurt je již v daný čas rezervován.";
                    Reservation r = new Reservation();
                    return View(r);
                }

            }
            catch (System.Data.SqlClient.SqlException e)
            {
                ViewBag.MyMessageToUser = "Nelze rezervovat kurt.";
                e.ToString();
                Reservation r = new Reservation();
                return View(r);
            }
        }

        public ActionResult IndexR()
        {
            return View(appR.GetList());
        }
    }
}
