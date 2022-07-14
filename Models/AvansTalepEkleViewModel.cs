using EasyHR.Attributes;
using EasyHR.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models
{
    public class AvansTalepEkleViewModel
    {
        [Required(ErrorMessage = "Avans Tutarı kısmı boş bırakılamaz."), AvansTutari]
        public decimal AvansTutari { get; set; }

        [Required(ErrorMessage = "Açıklama kısmı boş bırakılamaz."), MaxLength(140)]
        public string Aciklama { get; set; }
    }
}
