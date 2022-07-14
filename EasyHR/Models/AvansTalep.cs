using EasyHR.Data;
using EasyHR.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyHR.Models
{
    public class AvansTalep
    {
        public AvansTalep()
        {
            TalepTarihi = DateTime.Now;
            AvansOnayDurumu = AvansOnayDurumuEnum.Beklemede;
        }
        public int Id { get; set; }

        [Required]
        public decimal AvansTutari { get; set; }

        [Required]
        public DateTime TalepTarihi { get; set; }

        public AvansOnayDurumuEnum AvansOnayDurumu { get; set; }

        [Required, MaxLength(140)]
        public string Aciklama { get; set; }
        public DateTime? SonuclanmaTarihi { get; set; }


        [Required]
        [ForeignKey("Personel")]
        public string PersonelId { get; set; }
        public ApplicationUser Personel { get; set; } 

    }
}
