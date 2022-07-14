using EasyHR.Models.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Attributes
{
    public class IseGirisTarihiAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime iseGirisTarihi = (DateTime)value;

            try
            {
                var vm = (PersonelEkleViewModel)validationContext.ObjectInstance;

                if (iseGirisTarihi <= new DateTime(1922, 1, 1))
                {
                    return new ValidationResult("Yakın bir tarih seçmelisiniz.");
                }

                if (iseGirisTarihi > DateTime.Now)
                {
                    return new ValidationResult("Personelin işe giriş tarihi bugün veya daha önceki bir tarih olmalı.");
                }

                if (iseGirisTarihi < vm.DogumTarihi.AddYears(18))
                {
                    return new ValidationResult("İşe giriş tarihi ile doğum tarihi arasında en az 18 yıl olması gerekir.");
                }

                return ValidationResult.Success;
            }
            catch (Exception)
            {
                try
                {
                    var vmo = (YoneticiEkleViewModel)validationContext.ObjectInstance;

                    if (iseGirisTarihi <= new DateTime(1922, 1, 1))
                    {
                        return new ValidationResult("Yakın bir tarih seçmelisiniz.");
                    }

                    if (iseGirisTarihi > DateTime.Now)
                    {
                        return new ValidationResult("Personelin işe giriş tarihi bugün veya daha önceki bir tarih olmalı.");
                    }

                    if (iseGirisTarihi < vmo.DogumTarihi.AddYears(18))
                    {
                        return new ValidationResult("İşe giriş tarihi ile doğum tarihi arasında en az 18 yıl olması gerekir.");
                    }

                    return ValidationResult.Success;
                }
                catch (Exception)
                {
                    return new ValidationResult("Geçersiz alan.");
                }
            }

        }
    }
}
