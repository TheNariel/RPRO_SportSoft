using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPRO_SportSoft.Application
{
    public class PriceList_CourtsApp
    {
        DataClasses1DataContext db;
        String Connection = "SportSoftDbConnectionString1";
        public PriceList_CourtsApp()
        {
            db = new DataClasses1DataContext();
        }


        public PriceList_CourtsApp(String ConnectionName)
        {
            Connection = ConnectionName;
            db = new DataClasses1DataContext(System.Configuration.ConfigurationManager.ConnectionStrings[Connection].ConnectionString);
        }

        public Boolean Add(int Courts_Id, int PriceList_Id, DateTime date)
        {
            PriceLists_Courts pc = new PriceLists_Courts();
            pc.Courts_Id = Courts_Id;
            pc.PriceLists_Id = PriceList_Id;
            pc.Date = date.Date;
            db.PriceLists_Courts.InsertOnSubmit(pc);
            db.SubmitChanges();
            return true;
        }
        public Boolean Add(Court court, int P_Id)
        {
            PriceLists_Courts pc = new PriceLists_Courts();
            pc.Courts_Id = court.Id;
            pc.PriceLists_Id = P_Id;
            pc.Date = DateTime.Today.Date;
            db.PriceLists_Courts.InsertOnSubmit(pc);
            db.SubmitChanges();
            return true;
        }
    }
}