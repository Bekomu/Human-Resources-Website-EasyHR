using EasyHR.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EasyHR.Models.ViewModels
{
    public class HomeViewModel
    {
        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string Email { get; set; }

        public string Unvan { get; set; }

        public List<IzinTalep> IzinTalepleri { get; set; }

        public List<AvansTalep> AvansTalepleri { get; set; }

        public List<HarcamaTalep> HarcamaTalepleri { get; set; }


        public List<IzinTalep> PersonelIzinTalepleri { get; set; }

        public List<AvansTalep> PersonelAvansTalepleri { get; set; }

        public List<HarcamaTalep> PersonelHarcamaTalepleri { get; set; }

        public List<Paket> SatistakiPaketler { get; set; }
    }
}
