using EasyHR.Models.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace EasyHR.Attributes
{
    public class PaketYayimlanmaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var vm = (PaketEkleViewModel)validationContext.ObjectInstance;

            if (vm != null)
            {
                if (value == null) return ValidationResult.Success;


                if (vm.YayimlanmaBaslangic.Value < DateTime.Now)
                {
                    return new ValidationResult("Yayımlanma tarihi bugünden önceki bir tarih olamaz.");
                }
                else if (vm.YayimlanmaBaslangic.Value > vm.YayimlanmaBitis.Value)
                {
                    return new ValidationResult("Yayımlanma tarihi, yayımlanma bitiş tarihinden büyük olamaz.");
                }
                else if (vm.YayimlanmaBitis.Value < vm.YayimlanmaBaslangic.Value.AddDays(7))
                {
                    return new ValidationResult("Yayımlanma başlangıç ve bitiş tarihleri arasında en az 7 gün olmalıdır.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
