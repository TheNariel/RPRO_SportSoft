using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPRO_SportSoft.Application
{
    public class PriceListsApp
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

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
       
        public Boolean Add(String description, int price)
        {
            
            PriceList pl = new PriceList();
            pl.Description = description;
            pl.Price = price;
            db.PriceLists.InsertOnSubmit(pl);
            db.SubmitChanges();
            return true;
        }
    }
}