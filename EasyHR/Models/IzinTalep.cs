using EasyHR.Data;
using EasyHR.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyHR.Models
{
    public class IzinTalep
    {
        public IzinTalep()
        {
            IzinOnayDurumu = IzinOnayDurumuEnum.Beklemede;
            TalepTarihi = DateTime.Now;
        }

        public int Id { get; set; }

        public IzinTuruEnum IzinTuru { get; set; }

        public DateTime IzinBaslangicTarihi { get; set; }

        public DateTime IzinBitisTarihi { get; set; }

        public int IzinGunSayisi { get; set; }

        public DateTime TalepTarihi { get; set; }

        public DateTime? SonuclanmaTarihi { get; set; }

        public IzinOnayDurumuEnum IzinOnayDurumu { get; set; }

        
        [Required]
        [ForeignKey("Personel")]
        public string PersonelId { get; set; }
        public ApplicationUser Personel { get; set; }

    }
}
