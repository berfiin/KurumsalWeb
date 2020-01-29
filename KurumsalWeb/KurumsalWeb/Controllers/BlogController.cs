
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
    public class BlogController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();
        // GET: Blog
        public ActionResult Index()
        {
          
            return View(db.Blog.ToList().OrderByDescending( x => x.BlogID));
        }
        public ActionResult Create()
        {
            ViewBag.KategoriID = new SelectList(db.Kategori, "KategoriID", "KategoriAd");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blog blog, HttpPostedFileBase ResimURL)
        {
            if (ResimURL != null)
            {
               
                WebImage img = new WebImage(ResimURL.InputStream);
                FileInfo imginfo = new FileInfo(ResimURL.FileName);

                string blogimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                img.Resize(600, 400);
                img.Save("~/Uploads/Blog/" + blogimgname);

                blog.ResimURL = "/Uploads/Blog/" + blogimgname;
            }
            db.Blog.Add(blog);
            db.SaveChanges();
            return View();
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var b = db.Blog.Where(x => x.BlogID == id).SingleOrDefault();
            if (b == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriID = new SelectList(db.Kategori, "KategoriID", "KategoriAd", b.KategoriID);
            return View(b);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit (int id,Blog blog,HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                var b = db.Blog.Where(x => x.BlogID == id).SingleOrDefault();
                if (ResimURL != null)
                {

                    if (System.IO.File.Exists(Server.MapPath(b.ResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(b.ResimURL));
                    }
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);

                    string blogimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(600, 400);
                    img.Save("~/Uploads/Blog/" + blogimgname);

                    b.ResimURL = "/Uploads/Blog/" + blogimgname;
                }
                b.Baslik = blog.Baslik;
                b.Icerik = blog.Icerik;
                b.KategoriID = blog.KategoriID;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var b = db.Blog.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            if (System.IO.File.Exists(Server.MapPath(b.ResimURL)))
            {
                System.IO.File.Delete(Server.MapPath(b.ResimURL));
            }
            db.Blog.Remove(b);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}