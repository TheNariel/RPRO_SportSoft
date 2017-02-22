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
    public class UsersAppTests
    {
        //    DataClasses1DataContext db = new DataClasses1DataContext(System.Configuration.ConfigurationManager.ConnectionStrings["TestDatabase"].ConnectionString);

        //    [TestMethod()]
        //    public void AddTest()
        //    {
        //        UsersApp app = new UsersApp("TestDatabase");

        //        var result = app.Add("a@a.a", "aaaaa", "Majitel");
        //        var exp = true;

        //        try
        //        {
        //            var item = db.Users.Where(User => User.Email == "a@a.a").Single();
        //            db.Users.DeleteOnSubmit(item);
        //            db.SubmitChanges();
        //        }
        //        catch
        //        {
        //            Assert.Fail();
        //        }

        //        Assert.AreEqual(exp, result);
        //    }
        //    [TestMethod()]
        //    public void AddTakenTest()
        //    {
        //        UsersApp app = new UsersApp("TestDatabase");

        //        var result = app.Add("test@test.test", "aaaaa", "Majitel");
        //        var exp = false;


        //        Assert.AreEqual(exp, result);
        //    }

        [TestMethod()]
        public void ValidatePhoneNumberTest()
        {
            Assert.IsTrue(UsersApp.ValidatePhoneNumber("+123456789123"));
        }
        [TestMethod()]
        public void ValidatePhoneNumberTest1()
        {
            Assert.IsTrue(UsersApp.ValidatePhoneNumber("+123 123 123 123"));
        }
        [TestMethod()]
        public void ValidatePhoneNumberTest2()
        {
            Assert.IsTrue(UsersApp.ValidatePhoneNumber("123456789"));
        }
        [TestMethod()]
        public void ValidatePhoneNumberTest3()
        {
            Assert.IsFalse(UsersApp.ValidatePhoneNumber("fsd"));
        }
        [TestMethod()]
        public void ValidatePhoneNumberTest4()
        {
            Assert.IsFalse(UsersApp.ValidatePhoneNumber("123456"));
        }
    }
}