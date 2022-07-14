using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models.Enums
{
    public enum HarcamaOnayDurumuEnum
    {
        [Display(Name = "Onaylandı")]
        Onaylandi = 1,

        [Display(Name = "Beklemede")]
        Beklemede = 2,

        [Display(Name = "Reddedildi")]
        Reddedildi = 3
    }
}
