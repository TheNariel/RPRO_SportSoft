using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPRO_SportSoft.Application
{
    public class ReservationsApp
    {
        DataClasses1DataContext db;
        String Connection = "SportSoftDbConnectionString1";
        public ReservationsApp()
        {
            db = new DataClasses1DataContext();
        }

        public ReservationsApp(String ConnectionName)
        {
            Connection = ConnectionName;
            db = new DataClasses1DataContext(System.Configuration.ConfigurationManager.ConnectionStrings[Connection].ConnectionString);
        }

        public IEnumerable<Reservation> GetList()
        {
            return db.Reservations.ToList();
        }

        public IEnumerable<Reservation> GetListByEmail(String email)
        {
            return db.Reservations.Where(Reservation => Reservation.User_Email == email && Reservation.Date.CompareTo(System.DateTime.Now) >= 0).OrderBy(Reservation => Reservation.Date).ThenBy(Reservation => Reservation.Courts_Id).ThenBy(Reservation => Reservation.Time_Id).ToList();
        }
        public IEnumerable<Reservation> GetListFuture()
        {
            return db.Reservations.Where(Reservation =>Reservation.Date.CompareTo(System.DateTime.Now) >= 0).OrderBy(Reservation => Reservation.Date).ThenBy(Reservation => Reservation.Courts_Id).ThenBy(Reservation => Reservation.Time_Id).ToList();
        }
        public List<int> GetListId()
        {
            List<int> a = new List<int>();
            foreach (Reservation reservation in db.Reservations.ToList())
            {
                a.Add(reservation.Id);
            }
            return a;
        }

        public Boolean Add(int court_id, DateTime date, int time, String user)
        {
            
           
                Reservation r = new Reservation();

                r.Courts_Id = court_id;
                r.Date = date;
                r.Price = this.GetActualPrice(court_id, date);
                r.User_Email = user;
                r.Time_Id = time;
                db.Reservations.InsertOnSubmit(r);
                db.SubmitChanges();

          

            return true;
        }

        public Boolean CheckForReservations(int id_court, DateTime date, int time)
        {
            List<int> reservations = this.GetReservations(id_court, date);
            return !reservations.Contains(time);
        }


        private int GetActualPrice(int id, DateTime date)
        {
            DateTime pom = new DateTime(1,1,1);
            int result = -1;
            int pomId = 0;
            List<PriceLists_Courts> list = db.PriceLists_Courts.Where(PriceLists_Courts => PriceLists_Courts.Courts_Id == id).ToList();
            foreach (PriceLists_Courts pc in list)
            {
                if (pc.Date <= date)
                {
                    if (pc.Date >= pom)
                    {
                        pom = pc.Date;
                        pomId = pc.PriceLists_Id;
                    }
                }
            }
            PriceList pl = db.PriceLists.Where(PriceList => PriceList.Id == pomId).First();
            result = pl.Price;
            return result;   
        }


        public List<int> GetReservations(int id_court, DateTime date) {
            List<Reservation> list = db.Reservations.Where(Reservations => Reservations.Courts_Id == id_court && Reservations.Date == date).ToList();
            List<int> listOfReservation = new List<int>();

            foreach (Reservation r in list) {
                listOfReservation.Add(r.Time_Id);
            }

            return listOfReservation;
        }
        
        public List<Reservation_Time> GetListOfTimeReservations() {
           return db.Reservation_Times.Where(Reservation_Time => Reservation_Time.Id >=19 && Reservation_Time.Id < 43).ToList();
            
        }

        public int GetIdTime(String time) {
            int id = db.Reservation_Times.Where(Reservation_Time => Reservation_Time.Time == time).First().Id;
            return id;
        }
        public String getTime(int Id)
        {
            String time = db.Reservation_Times.Where(Reservation_Time => Reservation_Time.Id == Id).First().Time;
            return time;
        }
        private int GetNumberOfFreeReservations(Int64 date, String court, int time)
        {
            Court c = db.Courts.Where(Court => Court.Name == court).First();
            int pom = 43;
            List<Reservation> list = db.Reservations.Where(Reservations => Reservations.Date == DateTime.FromBinary(date) && Reservations.Court == c).ToList();
            foreach (Reservation res in list)
            {
                if (res.Time_Id > time)
                {
                    if (res.Time_Id < pom)
                    {
                        pom = res.Time_Id;
                    }

                }      
            }
            return pom - time;
        }
        public List<String> ListOfNumbers(Int64 date, String court, String time)
        {
            Intervals intervals = new Intervals();
            int f = intervals.listString.Count;
            int timeInt = GetIdTime(time);
            List<String> list = new List<String>();
            int x = this.GetNumberOfFreeReservations(date, court, timeInt);
            for (int i = 0; i < x; i++)
            {
                list.Add(intervals.listString.ElementAt(i));
            }

            return list;
        }
        public int GetNumber(String time)
        {
            Intervals intervals = new Intervals();
            return intervals.listString.IndexOf(time);
        }

        public IEnumerable<Reservation> GetPastListByEmail(string email)
        {
            return db.Reservations.Where(Reservation => Reservation.User_Email == email && Reservation.Date.CompareTo(System.DateTime.Now)==-1).OrderByDescending(Reservation => Reservation.Date).ThenBy(Reservation => Reservation.Courts_Id).ThenBy(Reservation => Reservation.Time_Id).ToList();
        }
        public void Delete(int id)
        {
            var item = db.Reservations.Where(Reservations => Reservations.Id == id).Single();
            db.Reservations.DeleteOnSubmit(item);
            db.SubmitChanges();
        }

    }
    
}