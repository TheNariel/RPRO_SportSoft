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

                        TempData["MessageCreateCourt"] = "Kurt byl vytvořen.";
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
        public ActionResult Delete(int id, int sportId)
        {
            try
            {
                if (app.CheckIfExist(id))
                {
                    if (app.Delete(id))
                    {
                        TempData["MessageDeleteCourt"] = "Kurt byl vymazán.";
                        return RedirectToAction("CourtDetails", "Sports", new { id = sportId, date = DateTime.Today.ToString("dd.MM.yyyy"), count = 1 });
                    }
                    else
                    {
                        ViewBag.MyMessageToUser = "Nelze smazat kurt, který byl použit.";
                        return RedirectToAction("CourtDetails", "Sports", new { id = sportId, date = DateTime.Today.ToString("dd.MM.yyyy"), count = 1 });
                    }
                }
                else
                {
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

            
            try
            {
                if (app.CheckIfExist(Id))
                {
                    int Id_P = appPL.GetId(De_P);
                    int sport = app.GetSportId(Id);
                    if (app.CheckForWhiteSpaces(CourtName))
                    {

                        if (app.Edit(Id, CourtName, Sports_Id, Id_P, DateTime.ParseExact(dateCons, dateformat, provider)))
                        {
                            return RedirectToAction("CourtDetails", "Sports", new { id = Sports_Id, date = DateTime.Today.ToString("dd.MM.yyyy"), count = 1 });
                        }
                        else
                        {
                            ViewBag.MessageEditCourt = "Kurt s tímto názvem již existuje.";
                            ViewBag.date = DateTime.Today.ToString("dd.MM.yyyy");
                            return View(app.Get(Id));
                        }

                    }
                    else
                    {
                        ViewBag.MessageEditCourt = "Musíte vyplnit název kurtu.";
                        ViewBag.date = DateTime.Today.ToString("dd.MM.yyyy");
                        return View(app.Get(Id));

                    }


                }
                else
                {
                    ViewBag.MessageEditCourt = "Nelze změnit kurt";
                    return RedirectToAction("CourtDetails", "Sports", new { id = Sports_Id, date = DateTime.Today.ToString("dd.MM.yyyy"), count = 1 });
                }
            }
            catch
            {
                ViewBag.MessageEditCourt = "Nelze změnit kurt";
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
            ViewBag.MapedCourts = MapedCourts;
            Reservation[] ResList = appR.GetListByEmail(email).ToArray();
            Reservation[] PastReservations = appR.GetPastListByEmail(email).ToArray();
           
            List<ReservationFormated> futureRes =ReformatReservations(ResList);
            List<ReservationFormated> pastRes = ReformatReservations(PastReservations);
            ReservationFormated[] hF = futureRes.ToArray();
            int i = 0;
            while (true)
            {
                
                if (hF[i].date.CompareTo(DateTime.Now)==-1)
                {
                    pastRes.Reverse();
                    pastRes.Add(futureRes.First());
                    pastRes.Reverse();
                    futureRes.RemoveAt(0);
                    i++;
                }
                else {
                    break;
                }
            }
            pastRes= pastRes.OrderByDescending(o => o.date).ThenBy(o => o.time).ToList();

            futureRes = futureRes.OrderBy(o => o.date).ThenBy(o => o.time).ToList();
            ViewBag.PastReservations = pastRes;
            return View(futureRes);
        }

        private List<ReservationFormated> ReformatReservations(Reservation[] ResList)
        {
            List<ReservationFormated> ret = new List<ReservationFormated>();
            int i = 0,h =0;
            DateTime date;
            int court;
            int price;
            int startTime;
            int endTime;
            String LengthText = "",dateHelp="";
            String[] datetime;
            float hour;
            int length;
            Boolean same = true;
            String ids = "";
            while (i < ResList.Length)
            {
                date = ResList[i].Date;
                court = ResList[i].Courts_Id;
                price = ResList[i].Price;
                startTime = ResList[i].Time_Id;
                ids = ResList[i].Id.ToString();
                length = 0;
                h = 1;
                while (same)
                {
                    if (i < ResList.Length - 1 &&
                        date == ResList[i + 1].Date &&
                        court == ResList[i + 1].Courts_Id &&
                        price == ResList[i + 1].Price &&
                        startTime + length + 1 == ResList[i + 1].Time_Id)
                    {
                        length++;
                        i++;
                        h++;
                        ids += "\\" + ResList[i].Id.ToString();
                        if (i == ResList.Length - 1)
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
                endTime = startTime + length + 1;
                LengthText = appR.getTime(startTime) + "-" + appR.getTime(endTime);

                dateHelp = appR.getTime(startTime);
                datetime = dateHelp.Split(':');
                hour = float.Parse(datetime[0]);
                if (datetime[1].Equals("30"))
                {
                    hour = hour + 0.5f;
                }

                ret.Add(new ReservationFormated(date.AddHours(hour), court, price*h, LengthText, ids));
            }



            return ret;
        }
        public ActionResult CancelReservation(DateTime d, int cId, int price, String time, String ids)
        {
            SportsApp appS = new SportsApp();
            var MapedCourts = new Dictionary<int, string>();
            IEnumerable<Court> CList = app.GetList();
            foreach (Court c in CList)
            {
                MapedCourts[c.Id] = appS.GetName(c.Sports_Id) + ": " + c.Name;
            }
            ViewBag.MapedCourts = MapedCourts;
            ViewBag.reservation = new ReservationFormated(d, cId, price,time, ids);
            return View();
        }
        [HttpPost]
        public ActionResult CancelReservation(String ids,String email)
        {
            String[] idField = ids.Split('\\');
            foreach (String id in idField)
            {
                appR.Delete(int.Parse(id));
            }
            TempData["MessageCancelReservation"] = "Rezervace byla zrušena.";
            return RedirectToAction("IndexR", "Courts", new {email = email });
          
        }

        public ActionResult Stats()
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            ViewBag.InvariantCulture = provider;
            ViewBag.dateFrom = DateTime.Today.ToString("dd.MM.yyyy");
            ViewBag.dateTo = DateTime.Today.ToString("dd.MM.yyyy");
            List<String> sportList = new SportsApp().GetListNames();
            ViewBag.Sport = sportList.ElementAt(0).ToString();
            SportsApp sport = new SportsApp();
            ViewBag.Times = appR.GetListOfTimeReservations();

            ViewBag.ListOfReserv = app.getListOfDays(sport.GetId(sportList.ElementAt(0).ToString()), ViewBag.dateFrom, ViewBag.dateTo);

            List<CrateCurtGain> listCurtsGain = new List<CrateCurtGain>();
            IEnumerable<Court> courtList = sport.GetCourts(sport.GetId(sportList.ElementAt(0).ToString()));
            foreach (Court c in courtList) {
                int count = app.getCountOfReservations(c.Id, DateTime.ParseExact(ViewBag.DateFrom, "dd.MM.yyyy", ViewBag.InvariantCulture),
                DateTime.ParseExact(ViewBag.DateTo, "dd.MM.yyyy", ViewBag.InvariantCulture));
                double gain = app.getGain(c.Id, DateTime.ParseExact(ViewBag.DateFrom, "dd.MM.yyyy", ViewBag.InvariantCulture),
                DateTime.ParseExact(ViewBag.DateTo, "dd.MM.yyyy", ViewBag.InvariantCulture));
                listCurtsGain.Add(new CrateCurtGain(c.Name, count, gain));
            }
            ViewBag.CrateList = listCurtsGain;
            return View(sport.GetCourts(sport.GetId(sportList.ElementAt(0).ToString())));
        }
        [HttpPost]
        public ActionResult Stats(String Sport, String dateFrom, String dateTo)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            ViewBag.InvariantCulture = provider;
            ViewBag.dateFrom = dateFrom;
            ViewBag.dateTo = dateTo;
            ViewBag.Sport = Sport;
            SportsApp sport = new SportsApp();
            ViewBag.Times = appR.GetListOfTimeReservations();
            ViewBag.ListOfReserv = app.getListOfDays(sport.GetId(Sport), dateFrom, dateTo);

            List<CrateCurtGain> listCurtsGain = new List<CrateCurtGain>();
            IEnumerable<Court> courtList = sport.GetCourts(sport.GetId(Sport));
            foreach (Court c in courtList)
            {
                int count = app.getCountOfReservations(c.Id, DateTime.ParseExact(ViewBag.DateFrom, "dd.MM.yyyy", ViewBag.InvariantCulture),
                DateTime.ParseExact(ViewBag.DateTo, "dd.MM.yyyy", ViewBag.InvariantCulture));
                double gain = app.getGain(c.Id, DateTime.ParseExact(ViewBag.DateFrom, "dd.MM.yyyy", ViewBag.InvariantCulture),
                DateTime.ParseExact(ViewBag.DateTo, "dd.MM.yyyy", ViewBag.InvariantCulture));
                listCurtsGain.Add(new CrateCurtGain(c.Name, count, gain));
            }
            ViewBag.CrateList = listCurtsGain;

            return View(sport.GetCourts(sport.GetId(Sport)));
        }
    }
}
