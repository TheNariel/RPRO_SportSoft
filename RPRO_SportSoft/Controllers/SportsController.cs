using RPRO_SportSoft.Application;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Globalization;

namespace RPRO_SportSoft.Controllers
{
    public class SportsController : Controller
    {
        SportsApp app = new SportsApp();
        ReservationsApp appR = new ReservationsApp();
        EmailApp appE = new EmailApp();
        CourtsApp appC = new CourtsApp();
        // GET: Sports
        public ActionResult Index()
        {
            ViewBag.InvariantCulture = CultureInfo.InvariantCulture;
            ViewBag.Date = DateTime.Today.ToString("dd.MM.yyyy");
            return View(app.GetList());
        }

        // GET: Sports/Details/5
        public ActionResult Details(int id,String date, String date2, String radio)
        {
            if (radio.Equals("one"))
            {
                date2 = date;
            }     
            var Reservations = new Dictionary<string, List<int>>();
            IEnumerable<Court> courts = app.GetCourts(id);
            foreach(Court court in courts)
            {
                Reservations[court.Name] = new List<int>();
            }
            List<Reservation_Time> times = appR.GetListOfTimeReservations();
            CultureInfo provider = CultureInfo.InvariantCulture;
            String dateformat = "dd. MM. yyyy";
            ViewBag.InvariantCulture = provider;
            String[] d = date.Split('.');
            String dateCons = d[0] + ". " + d[1] + ". " + d[2];
            int plusDays = 0;
            DateTime dateFrom = DateTime.ParseExact(date, "dd.MM.yyyy", provider);
            DateTime dateTo = DateTime.ParseExact(date2, "dd.MM.yyyy", provider);
            DateTime datePom = new DateTime();
            datePom = dateFrom;
            if (dateFrom  < DateTime.Today) {
                dateFrom = DateTime.ParseExact(DateTime.Today.ToString(), "dd.MM.yyyy", provider);
            }
            if (dateTo < DateTime.Today)
            {
                dateTo = DateTime.ParseExact(DateTime.Today.ToString(), "dd.MM.yyyy", provider); ;
            }
            if (dateFrom > dateTo) {
                dateFrom = dateTo;
                dateTo = datePom;
                datePom = dateFrom;
            }
            do
            {
                foreach (var c in courts)
                {
                    Reservations[c.Name].AddRange(appR.GetReservations(c.Id, DateTime.ParseExact(dateCons, dateformat, provider).AddDays(plusDays)));
                }
                plusDays += 7;
                datePom = dateFrom.AddDays(plusDays);
            } while (datePom <= dateTo);

            ViewBag.DateTo = dateTo.ToString("dd.MM.yyyy");          
            ViewBag.Reservations = Reservations;
            ViewBag.Times = times.ToArray();
            ViewBag.Date = date;
            ViewBag.Radio = radio;
            CourtListP CourtList = new CourtListP(id, app.GetName(id), app.GetCourts(id));
            return View(CourtList);
        }

        public ActionResult CourtDetails(int id)
        {
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
                        TempData["MessageCreateSport"] = "Sportoviště bylo vytvořeno.";
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
                if (app.CheckIfExist(id)) {
                    app.Delete(id);
                }
                TempData["MessageDeleteSport"] = "Sportoviště bylo vymazáno.";
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
                if (app.CheckIfExist(id))
                {
                    if (app.CheckForWhiteSpaces(SportName))
                    {

                        if (app.Edit(id, SportName, image))
                        {

                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.MyMessageToUser = "Název musí být unikátní.";
                            return View(app.Get(id));
                        }

                    }
                    else
                    {
                        ViewBag.MyMessageToUser = "Musíte vyplnit název sportoviště.";
                        return View(app.Get(id));
                    }


                }
                else
                {
                    ViewBag.MyMessageToUser = "Toto sportoviště nelze editovat.";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ViewBag.MyMessageToUser = "Toto sportoviště nelze editovat.";
                return View(app.Get(id));


            }
        }

        public ActionResult Reservation(int id, String sport, String time, Int64 date, String user, Int64 date2, String radio)
        {
            ViewBag.Sport = sport;
            ViewBag.Id = id;
            ViewBag.Time = time;
            ViewBag.DateBinary = (Int64)date;
            ViewBag.DateString = DateTime.FromBinary(date).ToString("dd.MM.yyyy");
            ViewBag.User = user;
            if (radio.Equals("one")) {
                date2 = date;
            }
            ViewBag.DateTo = date2;
            ViewBag.Radio = radio;

            return View();
        }

        [HttpPost]
        public ActionResult Reservation(int id, String time, Int64 date, String user, String number, Int64 date2)
        {
            int plusDays = 0;
            int timeIndex = appR.GetNumber(number);
            int timeInt = appR.GetIdTime(time);
            DateTime dateFrom = DateTime.FromBinary(date);
            DateTime dateTo = DateTime.FromBinary(date2);
            List<Boolean> listOfBools = new List<bool>();
            try
            {
                do
                {
                    for (int i = 0; i <= timeIndex; i++)
                    {
                        listOfBools.Add(appR.CheckForReservations(id, DateTime.FromBinary(date).AddDays(plusDays), timeInt + i));
                    }
                    plusDays += 7;
                } while (dateFrom.AddDays(plusDays) <= dateTo);
                if (CheckTrue(listOfBools))
                {
                    plusDays = 0;
                    dateFrom = DateTime.FromBinary(date);
                    do
                    {
                        for (int i = 0; i <= timeIndex; i++)
                        {
                            appR.Add(id, DateTime.FromBinary(date).AddDays(plusDays), timeInt + i, user);
                        }
                        plusDays += 7;
                    } while (dateFrom.AddDays(plusDays) <= dateTo);
                    EmailApp appE = new EmailApp();
                    String body = String.Format(Properties.Resources.ERes,appC.Get(id).Name,DateTime.FromBinary(date).ToShortDateString(),time, DateTime.FromBinary(date2).ToString("dd.MM.yyyy"));
                    appE.SendEmail("Rezervace", body, user);

                    TempData["MessageCreateReservation"] = "Kurt byl rezervován.";
                    return RedirectToAction("IndexR", "Courts", new { email = user});
                }
                else
                {
                    ViewBag.MyMessageToUser = "Tento kurt je již v daný čas rezervován.";
                    return RedirectToAction("Index", "Sports");
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

        private bool CheckTrue(List<Boolean> list)
        {
            foreach (Boolean b in list)
            {
                if (b == false) return false;
            }
            return true;
        }

        public ActionResult ExtractOfPriceLists(int id)
        {
            PriceList_CourtsApp appL = new PriceList_CourtsApp();
            ViewBag.Court = appC.Get(id).Name;
            return View(appL.ListOfPrices(id));
        }
    }
}
