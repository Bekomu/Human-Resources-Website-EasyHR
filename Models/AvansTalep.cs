using EasyHR.Attributes;
using EasyHR.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models
{
    public class AvansTalep
    {
        // ctor içindeki gereksiz parametre kaldırıldı.
        public AvansTalep()
        {
            TalepTarihi = DateTime.Now;
            AvansOnayDurumu = AvansOnayDurumuEnum.Beklemede;
        }
        
        public int Id { get; set; }
        
        [Required, AvansTutari]
        public decimal AvansTutari { get; set; }
       
        [Required]
        public DateTime TalepTarihi { get; set; }
        
        public AvansOnayDurumuEnum AvansOnayDurumu { get; private set; }
        
        [Required, MaxLength(140)]
        public string Aciklama { get; set; }
        
        // Sonuçlanma tarihi nullable olmalıdır.
        public DateTime? SonuclanmaTarihi { get; set; }
       
        // Personel için navigasyon özelliği
        [Required]
        public Personel Personel { get; set; }
       
        // Personel için yabancı anahtar
        public int PersonelId { get; set; }
    }
}
