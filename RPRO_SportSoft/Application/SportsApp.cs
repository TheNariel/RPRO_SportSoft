using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPRO_SportSoft.Application
{
    public class SportsApp
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public  Boolean Add(String n)
        {
            Boolean ret;
            if (!CheckIfTaken(n))
            {
                Sport s = new Sport();
                s.Name = n;
                db.Sports.InsertOnSubmit(s);
                db.SubmitChanges();
                ret = true;
            }
            else {
                ret = false;
            }

            return ret; 

        }
        private Boolean CheckIfTaken(String n)
        {
           return db.Sports.Where(Sport => Sport.Name == n).Any();

        }
        public void Delete(int id)
        {
            var item = db.Sports.Where(Sport => Sport.Id == id).Single();
            db.Sports.DeleteOnSubmit(item);
            db.SubmitChanges();
        }
        public Sport Get(int id)
        {
            return db.Sports.Where(Sport => Sport.Id == id).Single();
        }
        public String GetName(int id)
        {
            return db.Sports.Where(Sport => Sport.Id == id).Single().Name;
        }
        public IEnumerable<Sport> GetList()
        {
            return db.Sports.ToList();
        }
        public IEnumerable<Court> GetCourts(int id)
        {
            return db.Courts.Where(Court => Court.Sports_Id == id).ToList();
        }
        public Boolean Edit(int id,String SportName)
        {
            Boolean ret;
            if (!CheckIfTaken(SportName))
            {
                var obj = db.Sports.Single(x => x.Id == id);
                obj.Name = SportName;
                db.SubmitChanges();
                ret = true;
            }
            else
            {
                ret = false;
            }
            return ret;
        }

    }

      }
