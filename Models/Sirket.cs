using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models
{
    public class Sirket
    {
        public int Id { get; set; }


        [Required]
        public string SirketAdi { get; set; }


        [Required]
        public string TelefonNo { get; set; }

        [Required, MaxLength(140)]
        public string SirketInfo { get; set; }

        // Nav prop
        public List<Personel> Personeller { get; set; }
    }
}
