using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models.Enums
{
    public enum ParaBirimiEnum
    {
        [Display(Name = " ₺ - Türk Lirası")]
        TRY,

        [Display(Name = " $ - Amerikan Doları")]
        USD,

        [Display(Name = " € - Euro")]
        EUR,

        [Display(Name = " £ - Sterlin")]
        GBP
    }
}
