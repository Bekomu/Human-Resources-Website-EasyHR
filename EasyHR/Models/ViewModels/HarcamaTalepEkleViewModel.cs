using EasyHR.Attributes;
using EasyHR.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models.ViewModels
{
    public class HarcamaTalepEkleViewModel
    {
        [Required(ErrorMessage = "Açıklama kısmı boş bırakılamaz."), MaxLength(140)]
        [Remote(action: "HarcamaAciklamaValidation", controller: "ClientSideValidation")]
        public string Aciklama { get; set; }

        [Required(ErrorMessage = "Harcama tutarı kısmı boş bırakılamaz.")]
        [Range(0, int.MaxValue, ErrorMessage = "Lütfen geçerli bir tutar giriniz.")]
        [Remote(action: "HarcamaTutariValidation", controller: "ClientSideValidation")]
        public decimal HarcamaTutari { get; set; }

        [Required(ErrorMessage = "Dosya yüklemek zorunludur."), GecerliDosya]
        [Remote(action: "DosyaValidation", controller: "ClientSideValidation")]
        public IFormFile Dosya { get; set; }

        [Zorunlu]
        public HarcamaTuruEnum HarcamaTuru { get; set; }
    }
}
