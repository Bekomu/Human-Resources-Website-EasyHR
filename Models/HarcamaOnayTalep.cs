using System;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models
{
    public class HarcamaOnayTalep
    {
        public HarcamaOnayTalep()
        {
            TalepTarihi = DateTime.Now;
        }

        public int Id { get; set; }

        public decimal HarcamaTutari { get; set; }

        [Required, MaxLength(140)]
        public string Aciklama { get; set; }

        public string DosyaAdi { get; set; }

        public DateTime TalepTarihi { get; set; }

        public DateTime? SonucTarihi { get; set; }

        // Nav prop
        public Personel Personel { get; set; }

        // FK
        public int PersonelId { get; set; }
    }
}
