using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models
{
    public class Meslek
    {
        public int Id { get; set; }

        [Required]
        public string MeslekAdi { get; set; }

        [Required]
        public string MeslekKodu { get; set; }

        public List<Personel> Personel { get; set; }

    }
}
