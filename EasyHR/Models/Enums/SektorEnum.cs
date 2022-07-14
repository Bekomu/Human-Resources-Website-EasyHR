using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models.Enums
{
    public enum SektorEnum
    {
        [Display(Name = "Bankacılık Ve Sermaye Piyasaları")]
        BankacilikVeSermaye,

        [Display(Name = "Sigortacılık ve Bireysel Emeklilik")]
        SigortacilikVeBireyselEmeklilik,

        [Display(Name = "Varlık ve Servet Yönetimi")]
        VarlikVeServetYonetimi,

        Gayrimenkul,

        Teknoloji,

        [Display(Name = "Eğlence ve Medya")]
        EglenceVeMedya,

        Telekomunikasyon,

        [Display(Name = "Sağlık")]
        Saglik,

        [Display(Name = "Taşımacılık ve Lojistik")]
        TasimacilikVeLojistik,

        [Display(Name = "Elektrik ve Altyapı")]
        ElektrikVeAltyapi,

        Madencilik,

        [Display(Name = "Petrol ve Doğalgaz")]
        PetrolVeDogalgaz,

        Kimya,

        Kamu,

        Perakende,

        Otomotiv,

        [Display(Name = "Üretim")]
        Uretim,

        [Display(Name = "İnşaat")]
        Insaat,

        [Display(Name = "Özel")]
        Ozel,

        [Display(Name = "Diğer")]
        Diger
    }
}
