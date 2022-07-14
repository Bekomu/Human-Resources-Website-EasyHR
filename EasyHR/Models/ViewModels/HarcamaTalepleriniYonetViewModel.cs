using EasyHR.Attributes;
using EasyHR.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models.ViewModels
{
    public class HarcamaTalepleriniYonetViewModel
    {
        public int Id { get; set; }

        [Zorunlu]
        public string TamAd { get; set; }

        [Zorunlu]
        public decimal HarcamaTutari { get; set; }

        [Zorunlu]
        public string Aciklama { get; set; }

        [Zorunlu]
        public string DosyaAdi { get; set; }

        public HarcamaOnayDurumuEnum HarcamaOnayDurumu { get; set; }

        public string HarcamaOnayDurumuStr { get; set; }

        public DateTime TalepTarihi { get; set; }

        public DateTime? SonuclanmaTarihi { get; set; }
    }
}
