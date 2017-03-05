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

        public Boolean Add(String e, String p, String name, String surname, String phone)
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
                u.Role = "Customer";
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

        public Boolean Edit(String oe,String name, String surname, String phone)
        {
            Boolean ret;
            if ((!CheckIfTaken(oe) || oe.Equals(oe)) && ValidatePhoneNumber(phone))
            {
                var obj = db.Users.Single(x => x.Email == oe);
                obj.Name = name.Trim() + " " + surname.Trim();
                obj.Phone = phone;
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

        public Boolean CheckForWhiteSpaces(String name, String surname)
        {
            User u = new User();
            u.Name = name.Trim();
            u.Name = surname.Trim();

            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(surname))
            {
                return true;
            }
            else
            {
                return false;
            }
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
        public IEnumerable<User> GetUserListSorted(int flag)
        {
            IEnumerable<User> ret;
            switch (flag)
            {
                case 1:
                    ret= db.Users.ToList().OrderBy(User => User.Name);
                    break;
                case 2:
                    ret = db.Users.ToList().OrderByDescending(User => User.Name);
                    break;
                case 3:
                    ret = db.Users.ToList().OrderBy(User => User.Email);
                    break;
                case 4:
                    ret = db.Users.ToList().OrderByDescending(User => User.Email);
                    break;

                default :
                    ret = db.Users.ToList().OrderBy(User => User.Name);
                    break;

            }
            return ret;


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
        public Boolean ChangingPassword(String e, String oldPass, String newPass, String newPass2)
        {
            User u = this.GetUser(e);
            if (newPass.Equals(newPass2) && u.Password.Equals(CreatePasswordHash(oldPass, u.Salt)))
            {
                var obj = db.Users.Single(x => x.Email == e);
                obj.Password = CreatePasswordHash(newPass, u.Salt); ;
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }

        } 
    }
}