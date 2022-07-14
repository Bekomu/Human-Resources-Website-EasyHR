using EasyHR.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models.ViewModels
{
    public class IzinTalepleriniYonetViewModel
    {
        public int Id { get; set; }

        public string TamAd { get; set; }

        public string IzinTuru { get; set; }

        public IzinOnayDurumuEnum IzinOnayDurumuEnum { get; set; }

        public string IzinOnayDurumuStr { get; set; }

        public DateTime IzinBaslangicTarihi { get; set; }

        public DateTime IzinBitisTarihi { get; set; }

        public int IzinGunSayisi { get; set; }

        public DateTime TalepTarihi { get; set; }

        public DateTime? SonuclanmaTarihi { get; set; }
    }
}
