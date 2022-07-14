using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models.Enums
{
    public enum HarcamaTuruEnum
    {
        [Display(Name = "Yakıt")]
        Yakit,

        Konaklama,

        [Display(Name = "Ulaşım")]
        Ulasim,

        Yemek,

        Lojistik,

        Etkinlik,

        [Display(Name = "Karşılama")]
        Karsilama,

        [Display(Name = "Müşteri Memnuniyeti")]
        MusteriMemnuniyeti,

        [Display(Name = "Diğer (Açıklama giriniz)")]
        Diger
    }
}
