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

        public Boolean Add(String e, String p, String r, String name, String surname, String phone)
        {
            Boolean ret;
            if (!CheckIfTaken(e) && ValidatePhoneNumber(phone))
            {
                User u = new User();
                u.Email = e;
                String salt = CreateSalt();
                u.Password = CreatePasswordHash(p, salt);
                u.Salt = salt;
                u.Name = name.Trim() + " " + surname.Trim();
                u.Phone = phone.Replace(" ", "");


                u.Active = "Yes";
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
        public IEnumerable<User> GetUserList()
        {
            return db.Users.ToList();
        }
        public Boolean ActivateUser(String userEmail)
        {
            var obj = db.Users.Single(x => x.Email == userEmail);
            obj.Active = "Yes";
            db.SubmitChanges();
            return true;
        }
        public Boolean DeactivateUser(String userEmail)
        {
            var obj = db.Users.Single(x => x.Email == userEmail);
            obj.Active = "No";
            db.SubmitChanges();
            return false;
        }
        public static Boolean ValidatePhoneNumber(String phone)
        {
            phone = phone.Replace(" ", "");
            Char[] phoneChar = phone.ToCharArray();
            Boolean ret = true;
            if (phone.Length != 13 && phone.Length != 9) ret = false;

            if ((phoneChar[0] < '0' || phoneChar[0] > '9') && phoneChar[0] != '+') ret = false;
            for (int i = 1; i < phone.Length; i++)
            {
                if (phoneChar[i] < '0' || phoneChar[i] > '9') ret = false;

            }

            return ret;
        } 
    }
}