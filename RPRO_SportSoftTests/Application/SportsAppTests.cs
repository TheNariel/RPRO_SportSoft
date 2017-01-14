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
        public void AddTest()
        {
            SportsApp app = new SportsApp("TestDatabase");

            var ress = app.Add("Test", "No_photo.jpg");
            var exp = true;

            var item = db.Sports.Where(Sport => Sport.Name == "Test").Single();
            db.Sports.DeleteOnSubmit(item);
            db.SubmitChanges();

            Assert.AreEqual(exp, ress);
                      
        }
    }
}