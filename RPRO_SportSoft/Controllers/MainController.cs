﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RPRO_SportSoft.Controllers
{
    public class MainController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        // 
        // GET: /HelloWorld/ 

        public ActionResult Index()
        {
            
            return View();
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}