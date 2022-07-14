using EasyHR.Attributes;
using EasyHR.Data;
using EasyHR.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyHR.Models.ViewModels
{
    public class PersonelEkleViewModel
    {
        [Zorunlu, MaxLength(25)]
        public string Ad { get; set; }

        [Zorunlu, MaxLength(25)]
        public string Soyad { get; set; }

        [Zorunlu, DogumTarihi]
        public DateTime DogumTarihi { get; set; }

        [Zorunlu, MaxLength(100), EmailAddress]
        public string OzelEmail { get; set; }

        [Zorunlu, MaxLength(100)]
        public string Adres { get; set; }

        [Zorunlu]
        public long Telefon { get; set; }

        [Zorunlu, IseGirisTarihi]
        public DateTime IseGirisTarihi { get; set; }

        [Zorunlu]
        [MaxLength(11, ErrorMessage = "TC kimlik no 11 haneden fazla olamaz.")]
        [KimlikNo]
        public string TcNo { get; set; }

        [Zorunlu, Maas]
        public decimal Maas { get; set; }

        [Zorunlu]
        public CinsiyetEnum Cinsiyet { get; set; }

        [Zorunlu]
        public UnvanEnum Unvan { get; set; }

        [Zorunlu]
        public MedeniHalEnum MedeniHali { get; set; }

        [Zorunlu]
        public KanGrubuEnum KanGrubu { get; set; }

        [Zorunlu, GecerliFoto]
        public IFormFile Fotograf { get; set; }

        [Zorunlu]
        public int SirketId { get; set; }

        [Zorunlu]
        public int MeslekId { get; set; }

        [Zorunlu]
        public string YoneticiId { get; set; }

        public List<SelectListItem> Meslekler { get; set; }

        public List<SelectListItem> Yoneticiler { get; set; }
    }
}
