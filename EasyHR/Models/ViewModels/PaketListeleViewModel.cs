using EasyHR.Attributes;
using EasyHR.Models.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models.ViewModels
{
    public class PaketListeleViewModel
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Ad { get; set; }

        public decimal Tutar { get; set; }

        public string ParaBirimiStr { get; set; }

        public int KullaniciSayisi { get; set; }

        public DateTime YayimlanmaTarihi { get; set; }

        public DateTime YayimdanAlmaTarihi { get; set; }

        public bool SatistaMi { get; set; }

        public DateTime OlusturulmaTarihi { get; set; }

        public int KullanimSuresiGun { get; set; }

        public string FotografAdi { get; set; }
    }
}
