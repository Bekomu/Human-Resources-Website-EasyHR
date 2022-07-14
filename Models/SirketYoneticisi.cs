using EasyHR.Attributes;
using EasyHR.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models
{
    public class SirketYoneticisi : Personel
    {
        //public SirketYoneticisi(string ad, string soyad, string sirket) : base(ad, soyad, sirket)
        public SirketYoneticisi(string ad, string soyad) : base(ad, soyad)
        {

        }

        // Geçici olarak Parola property'si eklendi.
        public string Parola { get; set; }

        public List<Personel> Personeller { get; set; }
    }
}
