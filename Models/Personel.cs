using EasyHR.Attributes;
using EasyHR.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models
{
    public class Personel
    {
        //public Personel(string ad, string soyad, string sirketAdi)
        public Personel(string ad, string soyad)
        {
            Ad = ad.Trim();
            Soyad = soyad.Trim();
            //Sirket.SirketAdi = sirketAdi.Trim();

            eMailOlustur(ad.ToLower(), soyad.ToLower(), Sirket.SirketAdi.ToLower());

            // todo : sirket sınıfı geldiğinde değişmesi gerek. ctor a sirket girip sirket adi cekilip email oluşturulmalı.
        }

        // ad, soyad ve şirket adı ile gelen email adresini ingilizce karaktere çeviren private
        // metod
        private void eMailOlustur(string ad, string soyad, string sirket)
        {
            string email = ad.Replace(" ", "") + "." + soyad.Replace(" ", "") + $"@{sirket}.com";
            string turkceKarakterler = "ıçöğüş";
            string ingilizceKarakterler = "icogus";

            for (int i = 0; i < turkceKarakterler.Length; i++)
            {
                email = email.Replace(turkceKarakterler[i], ingilizceKarakterler[i]);
            }
            Email = email;
        }

        public int Id { get; set; }

        [Required, MaxLength(25)]
        public string Ad { get; set; }

        [Required, MaxLength(25)]
        public string Soyad { get; set; }

        [Required]  // todo : ileri tarihli seçilemez yapılmalı.
        public DateTime DogumTarihi { get; set; }

        [Required]
        public string Email { get; private set; }

        [Required, MaxLength(100)]
        public string Adres { get; set; }

        [Required]
        public long Telefon { get; set; }

        public DateTime IseGirisTarihi { get; set; }

        public DateTime? IstenCikisTarihi { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "TC kimlik no 11 haneden fazla olamaz.")]
        [KimlikNo]
        public string TcNo { get; set; }

        [Required]
        public string FotografAdi { get; set; }

        private decimal maas;

        [Required]
        public decimal Maas
        {
            get { return maas; }
            set
            {
                maas = value;
                MinAvansHakki = maas * 12 * 0.1m;
                MaksAvansHakki = maas * 12 * 0.3m;
            }
        }
        public decimal MinAvansHakki { get; private set; }
        public decimal MaksAvansHakki { get; private set; }

        [Required]
        public CinsiyetEnum Cinsiyet { get; set; }

        /* enum değerlerini kolayca çekmek için enumlara karşılık gelen integer değerlerden bir Id prop oluşturduk. Bu Id database üzerinde tutulacak ve gerekli enumlar bu Id den get set methodları ile çağırılacak.
        */

        [EnumDataType(typeof(UnvanEnum))]
        public UnvanEnum Unvan { get; set; }
        //public string Unvan { get; set; }

        [Required]
        public virtual int MedeniHaliId
        {
            get
            {
                return (int)this.MedeniHali;
            }
            set
            {
                MedeniHali = (MedeniHalEnum)value;
            }
        }

        [EnumDataType(typeof(MedeniHalEnum))]
        public MedeniHalEnum MedeniHali { get; set; }

        [Required]
        public virtual int KanGrubuId
        {
            get
            {
                return (int)this.KanGrubu;
            }
            set
            {
                KanGrubu = (KanGrubuEnum)value;
            }
        }
        [EnumDataType(typeof(KanGrubuEnum))]
        public KanGrubuEnum KanGrubu { get; set; }

        [Required]
        public string Meslek { get; set; }

        // Navigation properties ( sınıflar oluşmadığı için string olarak tutuluyor )

        public List<AvansTalep> AvansTalepleri { get; set; }

        public List<IzinTalep> IzinTalepleri { get; set; }

        public List<HarcamaOnayTalep> HarcamaOnayTalepleri { get; set; }


        // Nav prop şirket
        public Sirket Sirket { get; set; }

        // FK Şirket
        public int SirketId { get; set; }



    }
}
