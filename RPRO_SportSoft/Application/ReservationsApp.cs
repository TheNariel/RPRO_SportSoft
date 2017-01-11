using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPRO_SportSoft.Application
{
    public class ReservationsApp
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public IEnumerable<Reservation> GetList()
        {
            return db.Reservations.ToList();
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
           return db.Reservation_Times.ToList();
            
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
            int pom = 25;
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
    }
    public class Intervals
    {
        public List<String> listString;
        public Intervals() {
            this.listString = new List<string>();
            listString.Add("0:30");
            listString.Add("1:00");
            listString.Add("1:30");
            listString.Add("2:00");
            listString.Add("2:30");
            listString.Add("3:00");
            listString.Add("3:30");
            listString.Add("4:00");
            listString.Add("4:30");
            listString.Add("5:00");
            listString.Add("5:30");
            listString.Add("6:00");
            listString.Add("6:30");
            listString.Add("7:00");
            listString.Add("7:30");
            listString.Add("8:00");
            listString.Add("8:30");
            listString.Add("9:00");
            listString.Add("9:30");
            listString.Add("10:00");
            listString.Add("10:30");
            listString.Add("11:00");
            listString.Add("11:30");
            listString.Add("12:00");
        }
    }
}