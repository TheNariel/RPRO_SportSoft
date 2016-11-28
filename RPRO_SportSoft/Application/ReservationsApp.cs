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
            Reservation r = new Reservation();

            r.Courts_Id = court_id;
            r.DateTime = date.Date;

            db.Reservations.InsertOnSubmit(r);
            db.SubmitChanges();

            return true;
        }
    }
}