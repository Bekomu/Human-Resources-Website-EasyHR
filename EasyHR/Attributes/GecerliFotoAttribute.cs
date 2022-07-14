using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace EasyHR.Attributes
{
    public class GecerliFotoAttribute : ValidationAttribute
    {

        public int maksimumFotoBoyutu = 2048;

        public override bool IsValid(object value)
        {
            IFormFile formFile = value as IFormFile; // geçersiz gelirse null atsın diye böyle cast

            if (formFile == null)
                return true;

            if (!formFile.ContentType.StartsWith("image/"))
            {
                ErrorMessage = "Geçersiz dosya.";
                return false;
            }
            else if (formFile.Length > maksimumFotoBoyutu * 1024)
            {
                ErrorMessage = $"Dosya boyutu çok büyük. Maksimum boyut : {maksimumFotoBoyutu}kb.";
                return false;
            }
            else
                return true;
        }
    }
}
