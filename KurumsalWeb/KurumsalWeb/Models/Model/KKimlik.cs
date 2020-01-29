using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    [Table("KKimlik")]
    public class KKimlik
    {
        [Key]
        public int KKimlikID { get; set; }
        [DisplayName("Site Baslik")]
        [Required, StringLength(100, ErrorMessage = "100 karakter uzunluğunda olmalıdır")]
        public string Title { get; set; }
        [DisplayName("Anahtar Kelimeler")]
        [Required, StringLength(200, ErrorMessage = "200 karakter olmalıdır")]
        public string Keywords { get; set; }
        [DisplayName("site acıklama")]
        [Required, StringLength(300, ErrorMessage = "300 karakter olmalıdır")]
        public string Description { get; set; }
        [DisplayName("Site Logo")]
        public string LogoURL { get; set; }
        public string Unvan { get; set; }

    }
}