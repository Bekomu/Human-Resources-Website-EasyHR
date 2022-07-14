using EasyHR.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyHR.Models
{
    public class Kart
    {
        public int Id { get; set; }

        public string KartIsmi { get; set; }
        
        public string AdSoyad { get; set; }

        [CreditCard]
        public string KartNumarasi { get; set; }

        public string SKT { get; set; }

        public string CVC2 { get; set; }

        public decimal Limit { get; set; }




        public Sirket Sirket { get; set; }
        public int? SirketId { get; set; }
    }
}
