namespace KurumsalWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Blog")]
    public partial class Blog
    {
        public int BlogID { get; set; }

        [StringLength(250)]
        public string Baslik { get; set; }

        public string Icerik { get; set; }

        [StringLength(250)]
        public string ResimURL { get; set; }

        public int? KategoriID { get; set; }

        public virtual Kategori Kategori { get; set; }
    }
}
