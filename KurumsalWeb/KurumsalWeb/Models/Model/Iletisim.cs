﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    [Table("Iletisim")]
    public class Iletisim
    {
        [Key]
        public int IletisimID { get; set; }
        [Required, StringLength(250, ErrorMessage = "250 karakter olmalıdır")]
        public string Adres{ get; set; }
        [Required, StringLength(250, ErrorMessage = "250 karakter olmalıdır")]
        public string Telefon { get; set; }

        public string Whatsapp { get; set; }
        public string Facebook{ get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }

    }
}