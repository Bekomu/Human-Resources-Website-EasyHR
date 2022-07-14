using EasyHR.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models.ViewModels
{
    [AvansTalep]
    public class AvansTalepEkleViewModel
    {
        [Required(ErrorMessage = "Avans Tutarı kısmı boş bırakılamaz.")]
        [Remote(action: "AvansTutariValidation", controller:"ClientSideValidation")]
        public decimal? AvansTutari { get; set; }

        [Required(ErrorMessage = "Açıklama kısmı boş bırakılamaz.")]
        [MaxLength(140, ErrorMessage = "140 karakterden fazla karakter girişi yapılamaz!")]
        [Remote(action: "AvansAciklamaValidation", controller: "ClientSideValidation")]
        public string Aciklama { get; set; }
    }
}
