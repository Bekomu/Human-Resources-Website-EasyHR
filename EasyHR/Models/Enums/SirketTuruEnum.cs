using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models.Enums
{
    public enum SirketTuruEnum
    {
        [Display(Name = "Anonim Şirketi")]
        Anonim,

        [Display(Name = "Limited Şirketi")]
        Limited,

        [Display(Name = "Şahıs Şirketi")]
        Sahis
    }
}
