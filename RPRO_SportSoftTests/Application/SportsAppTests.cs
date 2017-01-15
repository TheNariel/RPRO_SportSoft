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
    public class SportsAppTests
    {
        DataClasses1DataContext db = new DataClasses1DataContext(System.Configuration.ConfigurationManager.ConnectionStrings["TestDatabase"].ConnectionString);

        [TestMethod()]
        public void AddTestNotTaken()
        {
            SportsApp app = new SportsApp("TestDatabase");

            var result = app.Add("Test", "No_photo.jpg");
            var exp = true;

            try
            {
                var item = db.Sports.Where(Sport => Sport.Name == "Test").Single();
                db.Sports.DeleteOnSubmit(item);
                db.SubmitChanges();
            }
            catch
            {
                Assert.Fail();
            }

            Assert.AreEqual(exp, result);

        }
        [TestMethod()]
        public void AddTestTaken()
        {
            SportsApp app = new SportsApp("TestDatabase");

            var result = app.Add("DontDeleteThis", "No_photo.jpg");
            var exp = false;

            Assert.AreEqual(exp, result);

        }

        [TestMethod()]
        public void CheckForWhiteSpacesNoWhite()
        {
            SportsApp app = new SportsApp("TestDatabase");
            var result = app.CheckForWhiteSpaces("test");
            var exp = true;
            Assert.AreEqual(exp, result);
        }
        [TestMethod()]
        public void CheckForWhiteSpacesYesWhite()
        {
            SportsApp app = new SportsApp("TestDatabase");
            var result = app.CheckForWhiteSpaces("  ");
            var exp = false;
            Assert.AreEqual(exp, result);
        }


        [TestMethod()]
        public void DeleteTest()
        {
            SportsApp app = new SportsApp("TestDatabase");

            Sport s = new Sport();
            s.Name = "TestDeleteData";
            s.Image_Id = 1;
            db.Sports.InsertOnSubmit(s);
            db.SubmitChanges();

            int id = db.Sports.Where(Sport => Sport.Name == "TestDeleteData").Single().Id;

            app.Delete(id);

            Boolean b;
            try
            {
                var item = db.Sports.Where(Sport => Sport.Name == "TestDeleteData").First();
                b = false;
            }
            catch
            {
                b = true;
            }
            Assert.IsTrue(b);

        }

        [TestMethod()]
        public void GetTest()
        {
            SportsApp app = new SportsApp("TestDatabase");
            var result = app.Get(19).Name;
            var exp = "DontDeleteThis";
            Assert.AreEqual(exp, result);
        }

        [TestMethod()]
        public void GetNameTest()
        {
            SportsApp app = new SportsApp("TestDatabase");
            var result = app.GetName(19);
            var exp = "DontDeleteThis";
            Assert.AreEqual(exp, result);
        }
    }
}