using RPRO_SportSoft.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RPRO_SportSoft.Controllers
{
    public class ImagesController : Controller
    {
        ImagesApp app = new ImagesApp();
        // GET: Images
        public ActionResult Index()
        {
            return View(app.GetList());
        }
        public ActionResult Create()
        {
            Image i = new Image();
            return View(i);
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file)
        {
            if (app.UploadImageToDB(file))
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.MessageCreateImage = "Obrázek nebyl nahrán.";
                Image i = new Image();
                return View(i);
            }
            
        }
    }
}