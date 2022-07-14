using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models.Enums
{
    public enum IzinTuruEnum
    {
        [Display(Name = "Yıllık İzin")]
        YillikIzin = 0,

        [Display(Name = "Doğum İzni")]
        DogumIzni,

        [Display(Name = "Doğum Sonrası İzin")]
        DogumSonrasiIzin,

        [Display(Name = "Hastalık İzni")]
        HastalikIzni,

        [Display(Name = "Mazeret İzni")]
        MazeretIzni,

        [Display(Name = "Babalık İzni")]
        BabalikIzni,
    }
}
