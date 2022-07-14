using EasyHR.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models
{
    public class Meslek
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string MeslekAdi { get; set; }

        [Required, MaxLength(7)]
        public string MeslekKodu { get; set; }

        public List<ApplicationUser> Personel { get; set; }
    }
}
