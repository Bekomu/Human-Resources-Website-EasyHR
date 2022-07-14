using System.ComponentModel.DataAnnotations;

namespace EasyHR.Models
{
    public class SirketYoneticisiLoginViewModel
    {
        [Required, MaxLength(30), MinLength(6)]
        public string Parola { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
