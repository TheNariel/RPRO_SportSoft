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
                r.DateTime = date;

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
            return db.Reservations.Where(Reservation => Reservation.Courts_Id == id_court && Reservation.DateTime == date).Any();
        }
    }
}