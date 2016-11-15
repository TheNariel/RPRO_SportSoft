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
            if (!CheckIfTaken(n))
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
        public Boolean Edit(int id,String n, int S_Id)
        {
            Boolean ret;
            if (!CheckIfTaken(n))
            {
                var obj = db.Courts.Single(x => x.Id == id);
                obj.Sports_Id = S_Id;
                obj.Name = n;
                db.SubmitChanges();
                ret = true;
            }
            else
            {
                ret = false;
            }
            return ret;

        }
        public Boolean CheckIfTaken(String n)
        {
            return db.Courts.Where(Court => Court.Name == n).Any();

        }
        public bool Delete(int id)
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

        public Court Get(int id)
        {
            return db.Courts.Where(Court => Court.Id == id).Single();
        }

        public int GetSportId(int id) {
            return db.Courts.Where(Court => Court.Id == id).Single().Sports_Id;
        }
    }
}