using System;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Attributes
{
    public class SirketKurulusTarihiAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime sirketKurulusTarihi = (DateTime)value;

            if (sirketKurulusTarihi > DateTime.Now)
            {
                return new ValidationResult("Şirketin kuruluş tarihi bugün veya daha önceki bir tarih olmalı.");
            }

            return ValidationResult.Success;
        }
    }
}
