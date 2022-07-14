using System;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Attributes
{
    public class DogumTarihiAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dogumTarihi = (DateTime)value;

            if (dogumTarihi <= new DateTime(1922, 1, 1))
            {
                return new ValidationResult("Yakın bir tarih seçmelisiniz.");
            }

            if (dogumTarihi > DateTime.Now.AddYears(-18))
            {
                return new ValidationResult("18 yaşından küçük bir yaş girdiniz.");
            }

            return ValidationResult.Success;
        }
    }
}
