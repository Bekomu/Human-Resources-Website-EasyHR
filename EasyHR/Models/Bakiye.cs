using EasyHR.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models
{
    public class Bakiye
    {
        public int Id { get; set; }

        [Required]
        public decimal Tutar { get; set; }
        
        [Required]
        public ParaBirimiEnum ParaBirimi { get; set; }

        [Required]
        public string YukleyenAdSoyad { get; set; }

        [Required]
        public string YukeleyenSirketAdi { get; set; }
    }
}
