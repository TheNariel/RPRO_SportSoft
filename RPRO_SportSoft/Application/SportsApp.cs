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
            if (!checkIfTaken(n))
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
        public Boolean checkIfTaken(String n)
        {
           return db.Sports.Where(Sport => Sport.Name == n).Any();

        }
        public void delete(int id)
        {
            var item = db.Sports.Where(Sport => Sport.Id == id).Single();
            db.Sports.DeleteOnSubmit(item);
            db.SubmitChanges();
        }
        public Sport get(int id)
        {
            return db.Sports.Where(Sport => Sport.Id == id).Single();
        }
        public String getName(int id)
        {
            return db.Sports.Where(Sport => Sport.Id == id).Single().Name;
        }
        public IEnumerable<Sport> getList()
        {
            return db.Sports.ToList();
        }
        public IEnumerable<Court> getCourts(int id)
        {
            return db.Courts.Where(Court => Court.Sports_Id == id).ToList();
        }
        public Boolean Edit(int id,String SportName)
        {
            Boolean ret;
            if (!checkIfTaken(SportName))
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
