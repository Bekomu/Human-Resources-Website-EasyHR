using System.Collections.Generic;

namespace EasyHR.Models.ViewModels
{
    public class YoneticiHomeViewModel
    {
        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string Email { get; set; }

        public string Unvan { get; set; }

        public List<IzinTalep> Izinlerim { get; set; }

        public List<AvansTalep> Avanslarim { get; set; }

        public List<HarcamaTalep> Harcamalarim { get; set; }
    }
}
