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
        public Boolean Add(DateTime date, int price)
        {
            
            PriceList pl = new PriceList();
            pl.Date = date.Date;
            pl.Price = price;
            db.PriceLists.InsertOnSubmit(pl);
            db.SubmitChanges();
            return true;
        }
    }
}