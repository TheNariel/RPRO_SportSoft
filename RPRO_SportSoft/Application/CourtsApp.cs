using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPRO_SportSoft.Application
{
    public class CourtsApp
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Boolean Add(String n,int S_Id)
        {
            Boolean ret;
            if (!checkIfTaken(n))
            {
                Court c = new Court();
                c.Name = n;
                c.Sports_Id = S_Id;
                db.Courts.InsertOnSubmit(c);
                db.SubmitChanges();
                ret = true;
            }
            else
            {
                ret = false;
            }
            return ret;

        }
        public Boolean checkIfTaken(String n)
        {
            return db.Courts.Where(Court => Court.Name == n).Any();

        }
        public bool delete(int id)
        {
            bool ret = true;
            if (!CheckForRegistration(id))
            {
                var item = db.Courts.Where(Court => Court.Id == id).Single();
                db.Courts.DeleteOnSubmit(item);
                db.SubmitChanges();
            }
            else {
                ret = false;
            }
            
            return ret;
        }

        private bool CheckForRegistration(int id)
        {
            return  db.Reservations.Where(Reservation => Reservation.Courts_Id == id).Any();
        }

        public Court get(int id)
        {
            return db.Courts.Where(Court => Court.Id == id).Single();
        }

        public int getSportId(int id) {
            return db.Courts.Where(Court => Court.Id == id).Single().Sports_Id;
        }
    }
}