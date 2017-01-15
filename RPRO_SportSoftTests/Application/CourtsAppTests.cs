using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPRO_SportSoft.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPRO_SportSoft.Application.Tests
{
    [TestClass()]
    public class CourtsAppTests
    {
        DataClasses1DataContext db = new DataClasses1DataContext(System.Configuration.ConfigurationManager.ConnectionStrings["TestDatabase"].ConnectionString);

        [TestMethod()]
        public void AddTest()
        {
            CourtsApp app = new CourtsApp("TestDatabase");

            var result = app.Add("TestAddCourt", 19, 1);
            var exp = true;

            try
            {
                var item = db.Courts.Where(Court => Court.Name == "TestAddCourt").Single();

                var itemH = db.PriceLists_Courts.Where(PriceLists_Court => PriceLists_Court.Courts_Id == item.Id).Single();
                db.PriceLists_Courts.DeleteOnSubmit(itemH);
                db.SubmitChanges();

                db.Courts.DeleteOnSubmit(item);
                db.SubmitChanges();
            }
            catch
            {
                Assert.Fail();
            }

            Assert.AreEqual(exp, result);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            CourtsApp app = new CourtsApp("TestDatabase");

            Court s = new Court();
            s.Name = "TestDeleteData";
            s.Sports_Id = 19;
            db.Courts.InsertOnSubmit(s);
            db.SubmitChanges();

            int id = db.Courts.Where(Court => Court.Name == "TestDeleteData").Single().Id;

            app.Delete(id);

            Boolean b;
            try
            {
                var item = db.Sports.Where(Court => Court.Name == "TestDeleteData").First();
                b = false;
            }
            catch
            {
                b = true;
            }
            Assert.IsTrue(b);
        }

        [TestMethod()]
        public void GetTestId()
        {
            CourtsApp app = new CourtsApp("TestDatabase");
            var result = app.Get(1).Name;
            var exp = "DontDelete_Court";
            Assert.AreEqual(exp, result);
        }
        [TestMethod()]
        public void GetTestName()
        {
            CourtsApp app = new CourtsApp("TestDatabase");
            var result = app.Get("DontDelete_Court").Id;
            var exp = 1;
            Assert.AreEqual(exp, result);
        }

        [TestMethod()]
        public void GetSportIdTest()
        {
            CourtsApp app = new CourtsApp("TestDatabase");
            var result = app.GetSportId(1);
            var exp = 19;
            Assert.AreEqual(exp, result);
        }
    }
}