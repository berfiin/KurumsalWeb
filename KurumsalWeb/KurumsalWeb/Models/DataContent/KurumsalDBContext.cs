﻿using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace KurumsalWeb.Models.DataContent
{
    public class KurumsalDBContext:DbContext
    {
        public KurumsalDBContext():base("KurumsalWebDB")
        {

        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Hakkimizda> Hakkimizda { get; set; }
        public DbSet<Hizmet> Hizmet { get; set;  }
        public DbSet<Iletisim> Iletisim { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<KKimlik> KKimlik { get; set; }


    }
}