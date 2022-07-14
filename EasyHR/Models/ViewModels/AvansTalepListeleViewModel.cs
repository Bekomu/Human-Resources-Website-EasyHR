using EasyHR.Attributes;
using EasyHR.Models.Enums;
using System;

namespace EasyHR.Models.ViewModels
{
    public class AvansTalepListeleViewModel
    {
        public int Id { get; set; }

        [Zorunlu]
        public decimal AvansTutari { get; set; }

        [Zorunlu]
        public DateTime TalepTarihi { get; set; }

        [Zorunlu]
        public string AvansOnayDurumuStr { get; set; }

        [Zorunlu]
        public AvansOnayDurumuEnum AvansOnayDurumu { get; set; }

        [Zorunlu]
        public string Aciklama { get; set; }

        [Zorunlu]
        public DateTime? SonuclanmaTarihi { get; set; }
    }
}
