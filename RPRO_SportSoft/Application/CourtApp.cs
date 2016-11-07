using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPRO_SportSoft.Application
{
    public class CourtApp
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
        public int delete(int id)
        {
            int ret;
            var item = db.Courts.Where(Court => Court.Id == id).Single();
            ret = item.Sports_Id;
            db.Courts.DeleteOnSubmit(item);
            db.SubmitChanges();
            return ret;
        }
        public Court get(int id)
        {
            return db.Courts.Where(Court => Court.Id == id).Single();
        }
    }
}