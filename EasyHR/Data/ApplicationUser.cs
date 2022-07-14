using EasyHR.Attributes;
using EasyHR.Models;
using EasyHR.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyHR.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(25)]
        public string Ad { get; set; }

        [Required, MaxLength(25)]
        public string Soyad { get; set; }

        // todo : ileri tarihli seçilemez yapılmalı.
        public DateTime DogumTarihi { get; set; }


        [Required(ErrorMessage ="E-posta alanı zorunludur."), Display(Name ="E-posta")]
        public override string Email { get; set; }


        [Required, MaxLength(100)]
        public string Adres { get; set; }

        public long Telefon { get; set; }

        public DateTime IseGirisTarihi { get; set; }
        public DateTime IzinGuncellemeTarihi { get; set; }
        public DateTime? IstenCikisTarihi { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "TC kimlik no 11 haneden fazla olamaz.")]
        [KimlikNo]
        public string TcNo { get; set; }

        [Required]
        public string FotografAdi { get; set; }

        private decimal maas;

        public decimal Maas
        {
            get { return maas; }
            set
            {
                maas = value;
                MinAvansHakki = maas * 0.5m;
                MaksAvansHakki = maas * 12 * 0.3m;
            }
        }
        public decimal MinAvansHakki { get; private set; }
        public decimal MaksAvansHakki { get; private set; }

        public CinsiyetEnum Cinsiyet { get; set; }

        public UnvanEnum Unvan { get; set; }

        public MedeniHalEnum MedeniHali { get; set; }

        public KanGrubuEnum KanGrubu { get; set; }

        [Display(Name ="Yıllık İzin (gün)")]
        public int YillikIzinGunSayisi { get; set; }

        // Navs -----------------------------------------------------

        public List<AvansTalep> AvansTalepleri { get; set; }
        public List<IzinTalep> IzinTalepleri { get; set; }
        public List<HarcamaTalep> HarcamaTalepleri { get; set; }

        public int SirketId { get; set; }
        public Sirket Sirket { get; set; }

        public int MeslekId { get; set; }
        public Meslek Meslek { get; set; }

       

        [ForeignKey("Yonetici")]
        public string YoneticiId { get; set; }
        public ApplicationUser Yonetici { get; set; }
    }
}
