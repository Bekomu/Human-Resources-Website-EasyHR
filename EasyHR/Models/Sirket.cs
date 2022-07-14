using EasyHR.Attributes;
using EasyHR.Data;
using EasyHR.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyHR.Models
{
    public class Sirket
    {
        public int Id { get; set; }

        [Required, MaxLength(70)]
        public string SirketAdi { get; set; }

        [Required]
        public string DosyaAdi { get; set; }

        [Required]
        public long MersisNo { get; set; }

        [Required, MaxLength(100)]
        public string VergiDairesi { get; set; }

        [Required]
        public long VergiNo { get; set; }

        [Required, MaxLength(100)]
        public string SirketAdres { get; set; }

        [Required]
        public long SirketTelefonNo { get; set; }

        [Required]
        public string SirketEmail { get; set; }

        [Required, MaxLength(253)]
        public string SirketWebSitesi { get; set; }

        [Required]
        public SirketTuruEnum SirketTuru { get; set; }

        [Required]
        public SektorEnum Sektor { get; set; }

        [Required, MaxLength(140)]
        public string SirketInfo { get; set; }

        [Required]
        public DateTime SirketKurulusTarihi { get; set; }

        [Required]
        public DateTime SirketUyeOlmaTarihi { get; set; }

        public List<ApplicationUser> Personeller { get; set; }
        

        // Nav prop
        [ForeignKey("Paket")]
        public int? PaketId { get; set; }
        public Paket Paket { get; set; }


        [ForeignKey("Cuzdan")]
        public int? CuzdanId { get; set; }
        public Cuzdan Cuzdan { get; set; }


        public List<Kart> Kartlar { get; set; }
    }
}
