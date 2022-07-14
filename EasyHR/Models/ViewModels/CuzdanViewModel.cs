using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models.ViewModels
{
    public class CuzdanViewModel
    {
        public decimal CuzdandakiMevcutPara { get; set; }

        [Required(ErrorMessage ="Eklenecek bakiye alanı boş olamaz!")]
        public decimal? EklenecekBakiye { get; set; }

        [Required(ErrorMessage ="Kart seçilmesi zorunludur!")]
        public int? KartId { get; set; }
    }
}
