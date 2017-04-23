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
        public List<PriceLists_Courts> toList(int CourtId)
        {
            return db.PriceLists_Courts.Where(PriceLists_Courts => PriceLists_Courts.Courts_Id == CourtId).OrderByDescending(PriceLists_Courts => PriceLists_Courts.Date).ToList();
        }

        public List<CratePriceLists> ListOfPrices(int CourtId)
        {
            List<CratePriceLists> ret = new List<CratePriceLists>();
            List<PriceLists_Courts> list = toList(CourtId);
            PriceListsApp app = new PriceListsApp();
            foreach (PriceLists_Courts p in list)
            {
                PriceList pl = app.GetListId(p.PriceLists_Id);
                CratePriceLists crate = new CratePriceLists(p.Date,pl.Description, pl.Price);
                ret.Add(crate);
            }
            return ret;
        }
    }
}