using EasyHR.Data;
using EasyHR.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyHR.Models
{
    public class HarcamaTalep
    {
        public HarcamaTalep()
        {
            TalepTarihi = DateTime.Now;
        }

        public int Id { get; set; }

        public decimal HarcamaTutari { get; set; }

        [Required, MaxLength(140)]
        public string Aciklama { get; set; }

        public string DosyaAdi { get; set; }

        public HarcamaOnayDurumuEnum HarcamaOnayDurumu { get; set; }

        public HarcamaTuruEnum HarcamaTuru { get; set; }
        
        public DateTime TalepTarihi { get; set; }

        public DateTime? SonuclanmaTarihi { get; set; }


        [Required]
        [ForeignKey("Personel")]
        public string PersonelId { get; set; }
        public ApplicationUser Personel { get; set; } 


    }
}
