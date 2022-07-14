using EasyHR.Attributes;
using EasyHR.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyHR.Models
{
    public class Paket
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Ad { get; set; }

        public decimal Tutar { get; set; }

        public ParaBirimiEnum ParaBirimiEnum { get; set; }

        public int KullaniciSayisi { get; set; }

        public DateTime YayimlanmaTarihi { get; set; }

        public DateTime YayimdanAlmaTarihi { get; set; }

        public bool SatistaMi { get; set; }

        public DateTime OlusturulmaTarihi { get; set; }

        public int KullanimSuresiGun { get; set; }

        [Required]
        public string FotografAdi { get; set; }


        // Nav prop
        public List<Sirket> Sirketler { get; set; }
    }
}
