﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    [Table("Hakkimizda")]
    public class Hakkimizda
    {
        [Key]
        public int HakkimizdaID { get; set; }
        [Required]
        [DisplayName("Hakkimizda Aciklama")]
        public string Aciklama { get; set; }
    }
}