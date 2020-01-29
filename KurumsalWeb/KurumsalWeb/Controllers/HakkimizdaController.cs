﻿using KurumsalWeb.Models.DataContent;
using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class HakkimizdaController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();
        [Language]
        // GET: Hakkimizda
        public ActionResult Index()
        {
            var h = db.Hakkimizda.ToList();
            return View(h);
        }

        public ActionResult Edit(int id)
        {
            var h = db.Hakkimizda.Where(x => x.HakkimizdaID == id).FirstOrDefault();
            return View(h);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id,Hakkimizda h)
        {
            if(ModelState.IsValid)
            {
                var hakkimizda = db.Hakkimizda.Where(x => x.HakkimizdaID == id).SingleOrDefault();
                hakkimizda.Aciklama = h.Aciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}