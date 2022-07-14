using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Mime;

namespace EasyHR.Attributes
{
    public class GecerliDosyaAttribute : ValidationAttribute
    {
        public string izinVerilenTurler { get; set; } =
            "application/msword,application/pdf,image,application/vnd.openxmlformats-officedocument.wordprocessingml.document";

        private int maksimumDosyaBoyutu = 2048;

        public override bool IsValid(object value)
        {
            var dosya = value as IFormFile;

            if (dosya == null) return true;

            if (dosya.Length > maksimumDosyaBoyutu * 1024)
            {
                ErrorMessage = $"İzin verilen maximum dosya boyutu {maksimumDosyaBoyutu}kb.";
                return false;
            }

            var gecerliDosyaTipleri = izinVerilenTurler.Split(',');

            if (!gecerliDosyaTipleri.Any(x => dosya.ContentType.StartsWith(x)))
            {
                ErrorMessage = "Lütfen .docx .doc .pdf veya image türünde bir dosya yükleyiniz!";
                return false;
            }

            return true;
        }
    }
}
