using EasyHR.Models.Enums;
using System;

namespace EasyHR.Models
{
    public class IzinTalep
    {
        public IzinTalep(DateTime izinBaslangicTarihi, DateTime izinBitisTarihi)
        {
            IzinGunSayisi = Convert.ToInt32((izinBitisTarihi - izinBaslangicTarihi).TotalDays);
            IzinOnayDurumu = IzinOnayDurumuEnum.Beklemede;
        }

        public int Id { get; set; }

        public IzinTuruEnum IzinTuru { get; set; }

        public DateTime IzinBaslangicTarihi { get; set; }

        public DateTime IzinBitisTarihi { get; set; }

        public int IzinGunSayisi { get; set; }

        public DateTime TalepTarihi { get; set; }

        public DateTime? SonuclanmaTarihi { get; set; }

        public IzinOnayDurumuEnum IzinOnayDurumu { get; set; }

        // Navigation Prop
        public Personel Personel { get; set; }

        // FK
        public int PersonelId { get; set; }
    }
}