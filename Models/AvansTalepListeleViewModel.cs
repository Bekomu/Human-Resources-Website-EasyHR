using EasyHR.Models.Enums;
using System;

namespace EasyHR.Models
{
    public class AvansTalepListeleViewModel
    {
        public int Id { get; set; }

        public decimal AvansTutari { get; set; }

        public DateTime TalepTarihi { get; set; }

        public string AvansOnayDurumuStr { get; set; }
        public AvansOnayDurumuEnum AvansOnayDurumu { get; set; }

        public string Aciklama { get; set; }

        public DateTime? SonuclanmaTarihi { get; set; }
    }
}
