using EasyHR.Attributes;
using EasyHR.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models.ViewModels
{
    public class AvansTalepleriniYonetViewModel
    {
        public int Id { get; set; }

        [Zorunlu]
        public string TamAd { get; set; }

        [Zorunlu]
        public decimal AvansTutari { get; set; }

        [Zorunlu]
        public DateTime TalepTarihi { get; set; }


        public string AvansOnayDurumuStr { get; set; }

        [Zorunlu]
        public AvansOnayDurumuEnum AvansOnayDurumu { get; set; }

        [Zorunlu]
        public string Aciklama { get; set; }

        public DateTime? SonuclanmaTarihi { get; set; }
    }
}
