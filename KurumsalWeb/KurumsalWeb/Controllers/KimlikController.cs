using KurumsalWeb.Models.DataContent;
using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class KimlikController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();
        // GET: Kimlik
        public ActionResult Index()
        {
            return View(db.KKimlik.ToList());
        }

        
  
        // GET: Kimlik/Edit/5
        public ActionResult Edit(int id)
        {
            var kimlik = db.KKimlik.Where(x => x.KKimlikID == id).SingleOrDefault();
            return View(kimlik);
        }

        // POST: Kimlik/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id,KKimlik kimlik,HttpPostedFileBase LogoURL)
        {
            if (ModelState.IsValid)
            {
                var k = db.KKimlik.Where(x => x.KKimlikID == id).SingleOrDefault();
                if (LogoURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(k.LogoURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(k.LogoURL));
                    }
                    WebImage img = new WebImage(LogoURL.InputStream);
                    FileInfo imginfo = new FileInfo(LogoURL.FileName);

                    string logoname = LogoURL.FileName+ imginfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/Kimlik/" + logoname);

                  k.LogoURL = "/Uploads/Kimlik/" + logoname;
                }
                k.Title = kimlik.Title;
                k.Keywords = kimlik.Keywords;
                k.Description = kimlik.Description;
                k.Unvan = kimlik.Unvan;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kimlik);
        }  
    }
}
