using RPRO_SportSoft.Application;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public ActionResult Create(String CourtName, int Id, String De_P)
        {
            int Id_P = appPL.GetId(De_P);
            try
            {
                if (app.CheckForWhiteSpaces(CourtName))
                {
                    if (app.Add(CourtName, Id, Id_P))
                    {
                        ViewBag.InvariantCulture = CultureInfo.InvariantCulture;
                        ViewBag.Date = DateTime.Today.ToString("dd.MM.yyyy");
                        return RedirectToAction("CourtDetails", "Sports", new { id = Id, date = DateTime.Today.ToString("dd.MM.yyyy"), count = 1 });
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
            catch (System.Data.SqlClient.SqlException e)
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
            else
            {
                return View(app.Get(id));
            }

        }

        // POST: Courts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,int sportId)
        {
            try
            {
                if (app.CheckIfExist(id))
                {
                    if (app.Delete(id))
                    {
                        return RedirectToAction("CourtDetails", "Sports", new { id = sportId, date = DateTime.Today.ToString("dd.MM.yyyy"), count = 1 });
                    }
                    else
                    {
                        ViewBag.MyMessageToUser = "Nelze smazat kurt, který byl použit.";
                        return View(app.Get(id));
                    }
                }
                else {
                    return RedirectToAction("CourtDetails", "Sports", new { id = sportId, date = DateTime.Today.ToString("dd.MM.yyyy"), count = 1 });
                }
                


            }
            catch (Exception e)
            {
                ViewBag.MyMessageToUser = "Nelze smazat kurt";
                return View(app.Get(id));
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.date = DateTime.Today.ToString("dd.MM.yyyy");
            return View(app.Get(id));
        }

        // POST: Courts/Delete/5
        [HttpPost]
        public ActionResult Edit(int Id, int Sports_Id, String CourtName, String De_P, String date)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            String dateformat = "dd. MM. yyyy";
            ViewBag.InvariantCulture = provider;
            String[] d = date.Split('.');
            String dateCons = d[0] + ". " + d[1] + ". " + d[2];

            int Id_P = appPL.GetId(De_P);
            int sport = app.GetSportId(Id);
            try
            {
                if (app.CheckForWhiteSpaces(CourtName))
                {

                    if (app.Edit(Id, CourtName, Sports_Id, Id_P, DateTime.ParseExact(dateCons, dateformat, provider)))
                    {
                        return RedirectToAction("CourtDetails", "Sports", new { id = Sports_Id, date = DateTime.Today.ToString("dd.MM.yyyy"), count = 1 });
                    }
                    else
                    {
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

        public ActionResult IndexR(String email)
        {
            SportsApp appS = new SportsApp();
            var MapedCourts = new Dictionary<int, string>();
            IEnumerable<Court> CList = app.GetList();
            foreach (Court c in CList)
            {
                MapedCourts[c.Id] = appS.GetName(c.Sports_Id) + ": " + c.Name;
            }

            Reservation[] ResList = appR.GetListByEmail(email).ToArray();
            Reservation[] PastReservations = appR.GetPastListByEmail(email).ToArray();
            ViewBag.MapedCourts = MapedCourts;

            ViewBag.PastReservations = ReformatReservations(PastReservations);
            return View(ReformatReservations(ResList));
        }

        private List<ReservationFormated> ReformatReservations(Reservation[] ResList)
        {
            List<ReservationFormated> ret = new List<ReservationFormated>();
            int i = 0;
            DateTime date;
            int court;
            int price;
            int startTime;
            int endTime;
            String LengthText="";
            int length;
            Boolean same = true;
            while (i < ResList.Length)
            {
                date = ResList[i].Date;
                court = ResList[i].Courts_Id;
                price = ResList[i].Price;
                startTime = ResList[i].Time_Id;
                length = 0;
                while (same)
                {
                    if ( i < ResList.Length-1 && 
                        date == ResList[i + 1].Date &&
                        court == ResList[i + 1].Courts_Id &&
                        price == ResList[i + 1].Price &&
                        startTime + length + 1 == ResList[i + 1].Time_Id)
                    {
                        length++;
                        i++;
                        if (i== ResList.Length-1)
                        {
                            same = false;
                        }
                    }
                    else
                    {
                        same = false;
                    }
                }
                i++;
                same = true;
                endTime = startTime + length+1;
                LengthText = appR.getTime(startTime) + "-" + appR.getTime(endTime);
                ret.Add(new ReservationFormated(date,court,price, LengthText));
            }
            
        

            return ret;
        }
    }
}
