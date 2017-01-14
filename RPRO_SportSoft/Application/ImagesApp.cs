using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace RPRO_SportSoft.Application
{
    public class ImagesApp
    {
        DataClasses1DataContext db;
        String Connection = "SportSoftDbConnectionString1";
        public ImagesApp()
        {
            db = new DataClasses1DataContext();
        }


        public ImagesApp(String ConnectionName)
        {
            Connection = ConnectionName;
            db = new DataClasses1DataContext(System.Configuration.ConfigurationManager.ConnectionStrings[Connection].ConnectionString);
        }

        public bool UploadImageToDB(HttpPostedFileBase file)
        {
            if (!this.CheckIfTaken(file.FileName))
            {
                Image img = new Image();
                img.ImageName = file.FileName;
                System.Drawing.ImageConverter ic = new System.Drawing.ImageConverter();
                img.ImageBytes = new byte[file.ContentLength];
                file.InputStream.Read(img.ImageBytes, 0, file.ContentLength);

                db.Images.InsertOnSubmit(img);
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }


        }
        public IEnumerable<Image> GetList()
        {
            return db.Images.ToList();
        }
        public List<String> GetListNames()
        {
            List<String> a = new List<String>();
            foreach (Image image in db.Images.ToList())
            {
                a.Add(image.ImageName);
            }
            return a;
        }
        public int GetId(String imageName)
        {
            return db.Images.Where(Image => Image.ImageName == imageName).Single().Id;
        }
        private bool CheckIfTaken(String name)
        {
            return db.Images.Where(Image => Image.ImageName == name).Any();
        }
        public Image GetImage(String imageName)
        {
            return db.Images.Where(Image => Image.ImageName == imageName).First();
        }
        public Image GetImage(int id)
        {
            return db.Images.Where(Image => Image.Id == id).First();
        }
    }
}