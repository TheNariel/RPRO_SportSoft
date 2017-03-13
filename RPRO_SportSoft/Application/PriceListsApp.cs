using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPRO_SportSoft.Application
{
    public class PriceListsApp
    {
        DataClasses1DataContext db;
        String Connection = "SportSoftDbConnectionString1";
        public PriceListsApp()
        {
            db = new DataClasses1DataContext();
        }


        public PriceListsApp(String ConnectionName)
        {
            Connection = ConnectionName;
            db = new DataClasses1DataContext(System.Configuration.ConfigurationManager.ConnectionStrings[Connection].ConnectionString);
        }

        public IEnumerable<PriceList> GetList()
        {
            return db.PriceLists.ToList();
        }
        public List<String> GetListDescrioptions()
        {
            List<String> a = new List<String>();
            foreach (PriceList priceList in db.PriceLists.ToList())
            {
                a.Add(priceList.Description);
            }
            return a;
        }
        public int GetId(String d)
        {
            PriceList p = db.PriceLists.Where(PriceList => PriceList.Description == d).First();
            return p.Id;
        }

        public PriceList GetListId(int id)
        {
            return db.PriceLists.Where(PriceList => PriceList.Id == id).Single();
            
        }
        public Boolean Add(String description, int price)
        {
            
            PriceList pl = new PriceList();
            pl.Description = description;
            pl.Price = price;
            db.PriceLists.InsertOnSubmit(pl);
            db.SubmitChanges();
            return true;
        }

        public Boolean Delete(int id)
        {
            bool ret = true;
            if (CheckForUsedPriceLists(id))
            {
                var item = db.PriceLists.Where(PriceList => PriceList.Id == id).Single();
                db.PriceLists.DeleteOnSubmit(item);
                db.SubmitChanges();
            }
            else {
                ret = false;
            } 
            return ret;
        }

        internal bool Edit(int id, string description, int price)
        {
            var obj = db.PriceLists.Single(x => x.Id == id);
            obj.Description = description;
            obj.Price = price;
            db.SubmitChanges();
            return true;
        }

        public bool CheckForUsedPriceLists(int id)
        {
           return db.PriceLists_Courts.Where(CourtId => CourtId.Id == id).Any();
        }
    }
}