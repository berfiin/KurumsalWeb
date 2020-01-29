﻿
using KurumsalWeb.Models;
using KurumsalWeb.Models.DataContent;
using KurumsalWeb.Models.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
   [Language]
    public class AdminController : Controller
    {

        KurumsalDBContext db = new KurumsalDBContext();
          
        public ActionResult Index()
        {
            var sorgu = db.Kategori.ToList();
            return View(sorgu);
        }
        public ActionResult Login()
        {
            return View();
        }
        
 
       
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var login = db.Admin.Where(x=>x.Eposta==admin.Eposta).SingleOrDefault();
            if(login.Eposta==admin.Eposta&&login.Sifre==admin.Sifre)
            {
                Session["adminID"] = login.AdminID;
                Session["eposta"] = login.Eposta;
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.Uyari = "Kullanıcı adı yada sifre yanlıs";
            
            return View(admin);
        }
        public ActionResult Logout()
        {
            Session["adminID"] = null;
            Session["eposta"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
        }
    }
}