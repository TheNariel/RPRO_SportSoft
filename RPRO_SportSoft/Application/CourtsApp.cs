using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace RPRO_SportSoft.Application
{
    public class CourtsApp
    {
        DataClasses1DataContext db;
        String Connection = "SportSoftDbConnectionString1";
        public CourtsApp()
        {
            db = new DataClasses1DataContext();
        }


        public CourtsApp(String ConnectionName)
        {
            Connection = ConnectionName;
            db = new DataClasses1DataContext(System.Configuration.ConfigurationManager.ConnectionStrings[Connection].ConnectionString);
        }

        public Boolean Add(String n,int S_Id, int P_Id)
        {
            Boolean ret;
            if (!CheckIfTaken(n, S_Id))
            {
                Court c = new Court();
                c.Name = n.Trim();
                c.Sports_Id = S_Id;
                db.Courts.InsertOnSubmit(c);
                db.SubmitChanges();
                
                PriceList_CourtsApp pc = new PriceList_CourtsApp();
                pc.Add(this.Get(n), P_Id);
                ret = true;
            }
            else
            {
                ret = false;
            }
            return ret;

        }
        public Boolean Edit(int id, String n, int S_Id, int P_Id, DateTime date)
        {
            Boolean ret;
            if (!CheckIfTakenEdit(n, S_Id, id))
            {
                var obj = db.Courts.Single(x => x.Id == id);
                obj.Sports_Id = S_Id;
                obj.Name = n.Trim();
                db.SubmitChanges();
                PriceList_CourtsApp pc = new PriceList_CourtsApp();
                Court c = this.Get(n);
                pc.Add(c.Id, P_Id, date);

                ret = true;
            }
            else
            {
                ret = false;
            }
            return ret;

        }

        public Boolean CheckForWhiteSpaces(String n)
        {
            Court c = new Court();
            c.Name = n.Trim();
            if (!string.IsNullOrWhiteSpace(n))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean CheckIfTaken(String n, int S_Id)
        {
            return db.Courts.Where(Court => Court.Name == n && Court.Sports_Id == S_Id).Any();

        }

        private Boolean CheckIfTakenEdit(String n, int S_Id, int id) {
            return db.Courts.Where(Court => Court.Name == n && Court.Sports_Id == S_Id && Court.Id != id).Any();
        }

        public bool Delete(int id)
        {
            bool ret = true;
            if (!CheckForRegistration(id))
            {
               
                List<PriceLists_Courts> list = db.PriceLists_Courts.Where(PriceLists_Courts => PriceLists_Courts.Courts_Id == id).ToList();
                db.PriceLists_Courts.DeleteAllOnSubmit(list);
                db.SubmitChanges();
                var item = db.Courts.Where(Court => Court.Id == id).Single();
                db.Courts.DeleteOnSubmit(item);
                db.SubmitChanges();
            }
            else {
                ret = false;
            }
            
            return ret;
        }

        public bool CheckForRegistration(int id)
        {
            return  db.Reservations.Where(Reservation => Reservation.Courts_Id == id).Any();
        }

        public Court Get(int id)
        {
            return db.Courts.Where(Court => Court.Id == id).Single();
        }
        public IEnumerable<Court> GetList()
        {
            return db.Courts.ToList();
        }
        public Court Get(String name)
        {
            return db.Courts.Where(Court => Court.Name == name).Single();
        }

        public int GetSportId(int id) {
            return db.Courts.Where(Court => Court.Id == id).Single().Sports_Id;
        }

        public Boolean CheckIfUsed(int id)
        {
            return db.Reservations.Where(Court => Court.Courts_Id == id).Any();
        }
        public Boolean CheckIfExist(int id)
        {
            return db.Courts.Where(Court => Court.Id == id).Any();
        }

        public double getGain(int Id, DateTime from, DateTime to)
        {
            double ret = 0;
            List<Reservation> list = db.Reservations.Where(Reservation => Reservation.Courts_Id == Id).ToList();
            foreach (Reservation r in list)
            {
                if (r.Date >= from && r.Date <= to)
                {
                    ret += r.Price;
                }
            }
            return ret;
        }

        public int getCountOfReservations(int Id, DateTime from, DateTime to)
        {
            List<Reservation> list = db.Reservations.Where(Reservation => Reservation.Courts_Id == Id).ToList();
            List<Reservation> listOfReservation = new List<Reservation>();
            foreach (Reservation r in list)
            {
                if (r.Date >= from && r.Date <= to)
                {
                    listOfReservation.Add(r);
                }
            }
            return listOfReservation.Count;
        }
        public List<List<List<Reservation>>> getListOfDays(int idSport, String dateFrom, String dateTo)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime dFrom = DateTime.ParseExact(dateFrom, "dd.MM.yyyy", provider);
            DateTime dTo = DateTime.ParseExact(dateTo, "dd.MM.yyyy", provider);
            List<List<List<Reservation>>> ret = new List<List<List<Reservation>>>();
            double countOfDays = (dTo - dFrom).TotalDays;
            for (int i = 0; i <= countOfDays; i++)
            {
                DateTime pom = dFrom;
                ret.Add(getListOfCourtsRes(idSport, pom.AddDays(i)));
            }
            return ret;
        }
        private List<List<Reservation>> getListOfCourtsRes(int idSport, DateTime date)
        {
            List<List<Reservation>> ret = new List<List<Reservation>>();
            SportsApp sport = new SportsApp();
            IEnumerable<Court> courts = sport.GetCourts(idSport);
            foreach (Court c in courts)
            {
                ret.Add(getListOfReserv(c.Id, date));
            }
            return ret;
        }
        private List<Reservation> getListOfReserv(int idCourt, DateTime date)
        {   
            List<Reservation> ret = new List<Reservation>();
            List<Reservation> pom = db.Reservations.Where(Reservation => Reservation.Courts_Id == idCourt).ToList();
            foreach (Reservation r in pom)
            {
                if (r.Date == date)
                {
                    ret.Add(r);
                }
            }
            return ret;
        }
        public Boolean Contains(List<Reservation> list, Reservation_Time time)
        {
            foreach (Reservation r in list)
            {
                if (r.Time_Id == time.Id) return true;
            }
            return false;
        }
        public String GetActualName(IEnumerable<Court> courts, int j)
        {
            j = j % courts.Count();
            return courts.ElementAt(j).Name;
        }


        public String getPriceList(int Id)
        {
            DateTime pom = new DateTime(1, 1, 1);
            DateTime now = DateTime.Today;
            String result = "None";
            int pomId = 0;
            List<PriceLists_Courts> list = db.PriceLists_Courts.Where(PriceLists_Courts => PriceLists_Courts.Courts_Id == Id).ToList();
            foreach (PriceLists_Courts pc in list)
            {
                if (pc.Date <= now)
                {
                    if (pc.Date >= pom)
                    {
                        pom = pc.Date;
                        pomId = pc.PriceLists_Id;
                    }
                }
            }
            PriceList pl = db.PriceLists.Where(PriceList => PriceList.Id == pomId).First();
            result = pl.Description;
            return result;
        }

    }
}