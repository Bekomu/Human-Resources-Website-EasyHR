using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models.Enums
{
    public enum AvansOnayDurumuEnum
    {
        [Display(Name = "Onaylandı")]
        Onaylandi = 1,

        [Display(Name = "Beklemede")]
        Beklemede,

        [Display(Name = "Reddedildi")]
        Reddedildi
    }
}
