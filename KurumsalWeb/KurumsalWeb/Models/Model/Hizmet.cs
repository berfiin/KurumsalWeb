using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    [Table("Hizmet")]
    public class Hizmet
    {
        [Key]
        public int HizmetID { get; set; }
        [DisplayName("Hizmet Baslik")]
        [Required, StringLength(150, ErrorMessage = "150 karakter olmalıdır")]
        public string Baslik { get; set; }
        [DisplayName("Hizmet Aciklama")]
        public string Aciklama { get; set; }
        [DisplayName("Hizmet Resim")]
        public string ResimURL { get; set; }


    }
}