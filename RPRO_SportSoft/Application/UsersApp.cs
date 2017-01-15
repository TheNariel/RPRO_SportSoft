using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace RPRO_SportSoft.Application
{
    public class UsersApp
    {
        DataClasses1DataContext db;
        String Connection = "SportSoftDbConnectionString1";
        public UsersApp()
        {
            db = new DataClasses1DataContext();
        }


        public UsersApp(String ConnectionName)
        {
            Connection = ConnectionName;
            db = new DataClasses1DataContext(System.Configuration.ConfigurationManager.ConnectionStrings[Connection].ConnectionString);
        }

        public Boolean Add(String e, String p, String r)
        {
            Boolean ret;
            if (!CheckIfTaken(e))
            {
                User u = new User();
                u.Email = e;
                String salt = CreateSalt();
                u.Password = CreatePasswordHash(p, salt);
                u.Salt = salt;
                if (r.Equals("Majitel"))
                {
                    u.Role = "Owner";
                } else if (r.Equals("Zákazník"))
                {
                    u.Role = "Customer";
                } else
                {
                    u.Role = "Undefined";
                }


                db.Users.InsertOnSubmit(u);
                db.SubmitChanges();
                ret = true;
            }
            else
            {
                ret = false;
            }

            return ret;

        }
        private Boolean CheckIfTaken(String e)
        {
            return db.Users.Where(User => User.Email == e).Any();

        }

        public Boolean Login(String email, String password)
        {
            if (CheckIfTaken(email))
            {
                User u = db.Users.Where(User => User.Email == email).First();
                if (u.Password.Equals(CreatePasswordHash(password, u.Salt)))
                {
                    return true;
                }
                else return false;
            }
           
            else return false;
        }

        private static String CreateSalt()
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[5];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        private static String CreatePasswordHash(String input, String salt)
        {
            string saltAndPwd = String.Concat(input, salt);
            string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "sha1");

            return hashedPwd;
        }
        public User GetUser(String e)
        {
            return db.Users.Where(User => User.Email == e).First();
        }
    }
}