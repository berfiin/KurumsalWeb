using KurumsalWeb.Models.DataContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class HomeController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();
        // GET: Home
        public ActionResult Index()
        {

            ViewBag.Iletisim = db.Iletisim.SingleOrDefault();

            ViewBag.Blog = db.Blog.ToList().OrderByDescending(x => x.BlogID);

            return View();
        }

        public ActionResult Hakkimizda()

        {
            return View(db.Hakkimizda.SingleOrDefault());
        }
       
    }
}