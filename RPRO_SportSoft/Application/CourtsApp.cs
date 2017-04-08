using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPRO_SportSoft.Application
{
    public class CourtsApp
    {
        DataClasses1DataContext db;
        String Connection = "SportSoftDbConnectionString1";
        public CourtsApp()
        {
            db = new DataClasses1DataContext();
        }


        public CourtsApp(String ConnectionName)
        {
            Connection = ConnectionName;
            db = new DataClasses1DataContext(System.Configuration.ConfigurationManager.ConnectionStrings[Connection].ConnectionString);
        }

        public Boolean Add(String n,int S_Id, int P_Id)
        {
            Boolean ret;
            if (!CheckIfTaken(n, S_Id))
            {
                Court c = new Court();
                c.Name = n.Trim();
                c.Sports_Id = S_Id;
                db.Courts.InsertOnSubmit(c);
                db.SubmitChanges();
                
                PriceList_CourtsApp pc = new PriceList_CourtsApp();
                pc.Add(this.Get(n), P_Id);
                ret = true;
            }
            else
            {
                ret = false;
            }
            return ret;

        }
        public Boolean Edit(int id, String n, int S_Id, int P_Id, DateTime date)
        {
            Boolean ret;
            if (!CheckIfTakenEdit(n, S_Id, id))
            {
                var obj = db.Courts.Single(x => x.Id == id);
                obj.Sports_Id = S_Id;
                obj.Name = n.Trim();
                db.SubmitChanges();
                PriceList_CourtsApp pc = new PriceList_CourtsApp();
                Court c = this.Get(n);
                pc.Add(c.Id, P_Id, date);

                ret = true;
            }
            else
            {
                ret = false;
            }
            return ret;

        }

        public Boolean CheckForWhiteSpaces(String n)
        {
            Court c = new Court();
            c.Name = n.Trim();
            if (!string.IsNullOrWhiteSpace(n))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean CheckIfTaken(String n, int S_Id)
        {
            return db.Courts.Where(Court => Court.Name == n && Court.Sports_Id == S_Id).Any();

        }

        private Boolean CheckIfTakenEdit(String n, int S_Id, int id) {
            return db.Courts.Where(Court => Court.Name == n && Court.Sports_Id == S_Id && Court.Id != id).Any();
        }

        public bool Delete(int id)
        {
            bool ret = true;
            if (!CheckForRegistration(id))
            {
               
                List<PriceLists_Courts> list = db.PriceLists_Courts.Where(PriceLists_Courts => PriceLists_Courts.Courts_Id == id).ToList();
                db.PriceLists_Courts.DeleteAllOnSubmit(list);
                db.SubmitChanges();
                var item = db.Courts.Where(Court => Court.Id == id).Single();
                db.Courts.DeleteOnSubmit(item);
                db.SubmitChanges();
            }
            else {
                ret = false;
            }
            
            return ret;
        }

        public bool CheckForRegistration(int id)
        {
            return  db.Reservations.Where(Reservation => Reservation.Courts_Id == id).Any();
        }

        public Court Get(int id)
        {
            return db.Courts.Where(Court => Court.Id == id).Single();
        }
        public IEnumerable<Court> GetList()
        {
            return db.Courts.ToList();
        }
        public Court Get(String name)
        {
            return db.Courts.Where(Court => Court.Name == name).Single();
        }

        public int GetSportId(int id) {
            return db.Courts.Where(Court => Court.Id == id).Single().Sports_Id;
        }

        public Boolean CheckIfUsed(int id)
        {
            return db.Reservations.Where(Court => Court.Courts_Id == id).Any();
        }
        public Boolean CheckIfExist(int id)
        {
            return db.Courts.Where(Court => Court.Id == id).Any();
        }

        public double getGain(int Id, DateTime from, DateTime to)
        {
            double ret = 0;
            List<Reservation> list = db.Reservations.Where(Reservation => Reservation.Courts_Id == Id).ToList();
            foreach (Reservation r in list)
            {
                if (r.Date >= from && r.Date <= to)
                {
                    ret += r.Price;
                }
            }
            return ret;
        }

        public int getCountOfReservations(int Id, DateTime from, DateTime to)
        {
            List<Reservation> list = db.Reservations.Where(Reservation => Reservation.Courts_Id == Id).ToList();
            List<Reservation> listOfReservation = new List<Reservation>();
            foreach (Reservation r in list)
            {
                if (r.Date >= from && r.Date <= to)
                {
                    listOfReservation.Add(r);
                }
            }
            return listOfReservation.Count;
        }
    }
}