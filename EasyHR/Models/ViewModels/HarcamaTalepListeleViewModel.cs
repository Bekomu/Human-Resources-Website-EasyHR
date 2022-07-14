using EasyHR.Attributes;
using EasyHR.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models.ViewModels
{
    public class HarcamaTalepListeleViewModel
    {
        public int Id { get; set; }

        public decimal HarcamaTutari { get; set; }

        public string Aciklama { get; set; }

        public string DosyaAdi { get; set; }

        public HarcamaOnayDurumuEnum HarcamaOnayDurumu { get; set; }

        public string HarcamaOnayDurumuStr { get; set; }

        public DateTime TalepTarihi { get; set; }

        public DateTime? SonuclanmaTarihi { get; set; }
    }
}
