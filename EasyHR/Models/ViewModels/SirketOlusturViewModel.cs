using EasyHR.Attributes;
using EasyHR.Models.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models.ViewModels
{
    public class SirketOlusturViewModel
    {
        [Zorunlu, MaxLength(70)]
        public string SirketAdi { get; set; }

        [Zorunlu, GecerliFoto]
        public IFormFile Logo { get; set; }

        [Zorunlu]
        public long MersisNo { get; set; }

        [Zorunlu, MaxLength(100)]
        public string VergiDairesi { get; set; }

        [Zorunlu]
        public long VergiNo { get; set; }

        [Zorunlu, MaxLength(100)]
        public string SirketAdres { get; set; }

        [Zorunlu]
        public long SirketTelefonNo { get; set; }

        [Zorunlu, MaxLength(100), EmailAddress]
        public string SirketEmail { get; set; }

        [Zorunlu, MaxLength(253)]
        public string SirketWebSitesi { get; set; }

        [Zorunlu]
        public SirketTuruEnum SirketTuru { get; set; }

        [Zorunlu]
        public SektorEnum Sektor { get; set; }

        [Zorunlu, MaxLength(140)]
        public string SirketInfo { get; set; }

        [Zorunlu]
        [DataType(DataType.Date)]
        public DateTime SirketUyeOlmaTarihi { get; set; }

        [Zorunlu, SirketKurulusTarihi]
        [DataType(DataType.Date)]
        public DateTime SirketKurulusTarihi { get; set; }
    }
}
