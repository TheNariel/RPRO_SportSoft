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

        public Boolean Add(int court_id, DateTime date)
        {
            Boolean check;
            if (!CheckIfTakenReservation(court_id, date))
            {
                Reservation r = new Reservation();

                r.Courts_Id = court_id;
                r.Date = date;
                r.Price = this.GetActualPrice(court_id, date);
                db.Reservations.InsertOnSubmit(r);
                db.SubmitChanges();

                check = true;
            }
            else
            {
                check = false;
            }

            return check;
        }

        public Boolean CheckIfTakenReservation(int id_court, DateTime date)
        {
            return db.Reservations.Where(Reservation => Reservation.Courts_Id == id_court && Reservation.Date == date).Any();
        }

        private int GetActualPrice(int id, DateTime date)
        {
            DateTime pom = new DateTime();
            pom.AddYears(0);
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


        //get reservation for specific court and date
        public List<int> GetReservations(int id_court, DateTime date) {
            List<Reservation> list = db.Reservations.Where(Reservations => Reservations.Courts_Id == id_court && Reservations.Date == date).ToList();
            List<int> listOfReservation = new List<int>();

            foreach (Reservation r in list) {
                listOfReservation.Add(r.Time_Id);
            }

            return listOfReservation;
        }


    }
}