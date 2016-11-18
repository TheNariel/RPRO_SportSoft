using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RPRO_SportSoft.Application
{
    public class UsersApp
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Boolean Add(String e, String p)
        {
            Boolean ret;
            if (!CheckIfTaken(e))
            {
                User u = new User();
                u.Email = e;
                u.Password = p;
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
        public Boolean CheckIfTaken(String e)
        {
            return db.Users.Where(User => User.Email == e).Any();

        }
        public Boolean Login(String email, String password)
        {
            if (CheckIfTaken(email))
            {
                if (db.Users.Where(User => User.Email == email && User.Password == password).Any())
                {
                    return true;
                }
                else return false;
            }
           
            else return false;


            
        }
    }
}