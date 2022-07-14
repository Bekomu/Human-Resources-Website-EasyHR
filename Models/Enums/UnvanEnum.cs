using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models.Enums
{
    public enum UnvanEnum
    {
        [Display(Name = "Yönetici")]
        Yonetici,

        [Display(Name = "Çalışan")]
        Calisan
    }
}
