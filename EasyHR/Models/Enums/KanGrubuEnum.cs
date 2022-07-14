using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models.Enums
{
    public enum KanGrubuEnum
    {
        [Display(Name = "0 RH(+)")]
        SifirPozitif,

        [Display(Name = "0 RH(-)")]
        SifirNegatif,

        [Display(Name = "A Rh(+)")]
        APozitif,

        [Display(Name = "A Rh(-)")]
        ANegatif,

        [Display(Name = "B Rh(+)")]
        BPozitif,

        [Display(Name = "B Rh(-)")]
        BNegatif,

        [Display(Name = "AB Rh(+)")]
        AbPozitif,

        [Display(Name = "AB Rh(-)")]
        AbNegatif
    }
}
