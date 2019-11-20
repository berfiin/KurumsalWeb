namespace KurumsalWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KurumsalDB : DbContext
    {
        public KurumsalDB()
            : base("name=KurumsalDB")
        {
        }

        public virtual DbSet<C_Kimlik> C_Kimlik { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Hakkimizda> Hakkimizdas { get; set; }
        public virtual DbSet<Hizmet> Hizmets { get; set; }
        public virtual DbSet<İletisim> İletisim { get; set; }
        public virtual DbSet<Kategori> Kategoris { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
