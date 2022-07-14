using EasyHR.Attributes;
using EasyHR.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models.ViewModels
{
    public class PaketEkleViewModel
    {
        [Zorunlu]
        public string Ad { get; set; }

        [Zorunlu]
        public decimal Tutar { get; set; }

        public ParaBirimiEnum ParaBirimiEnum { get; set; }

        [Zorunlu]
        public int KullaniciSayisi { get; set; }

        [Required(ErrorMessage = "Yayimlanma Tarihi zorunludur!"), PaketYayimlanma]
        [Remote(action: "PaketTarihValidation", controller: "ClientSideValidation", AdditionalFields = nameof(YayimlanmaBitis))]
        public DateTime? YayimlanmaBaslangic { get; set; }

        [Required(ErrorMessage ="Yayimdan Kaldırma Tarihi zorunludur!"), PaketYayimlanma]
        [Remote(action: "PaketTarihValidation", controller: "ClientSideValidation", AdditionalFields = nameof(YayimlanmaBaslangic))]
        public DateTime? YayimlanmaBitis { get; set; }

        //public int KalanGun { get; set; }
        // listelerken controller da çözülecek. " YayimlanmaBitis - DateTime.Now "

        [Zorunlu]
        public DateTime OlusturulmaTarihi { get; set; }

        [Zorunlu]
        public int KullanilmaSuresi { get; set; }

        [GecerliFoto]
        public IFormFile PaketFotografi { get; set; }
    }
}
