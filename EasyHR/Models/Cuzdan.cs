using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyHR.Models
{
    public class Cuzdan
    {
        public int Id { get; set; }

        public decimal ToplamBakiye { get; set; }

        // Nav prop
        public Sirket Sirket { get; set; }

        [Required]
        [ForeignKey("Sirket")]
        public int SirketId { get; set; }
    }
}
