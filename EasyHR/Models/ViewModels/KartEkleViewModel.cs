using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models.ViewModels
{
    public class KartEkleViewModel
    {
        public string AdSoyad { get; set; }

        public string KartIsmi { get; set; }

        [CreditCard(ErrorMessage = "Kart numarası geçerli değil.")]
        public string KartNumarasi { get; set; }

        [RegularExpression("^(0[1-9]|1[0-2])\\/?([0-9]{4}|[0-9]{2})$", ErrorMessage = "aa/YY, aaYY, aa-YY formatında giriş yapmalısınız. Örn: 12/24")]
        public string SKT { get; set; }

        [Required]
        public string CVC2 { get; set; }
    }
}
