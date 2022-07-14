using EasyHR.Data;
using EasyHR.Models;
using EasyHR.Models.Enums;
using EasyHR.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;

namespace EasyHR.Attributes
{
    public class AvansTalepAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var vm = (AvansTalepEkleViewModel)validationContext.ObjectInstance;

            if (vm != null)
            {
                var httpContextAccessor = (IHttpContextAccessor)validationContext.GetService(typeof(IHttpContextAccessor));
                var user = httpContextAccessor.HttpContext.User;
                var personelId = user.FindFirstValue("Id");
                // maks - son bir yılda talep edilen toplam = talep edilebilecek maksimum miktar
                var _db = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
                var avansTalepleri = _db.AvansTalepleri.Where(x => x.PersonelId == personelId);

                // son bir yıldaki alınan toplam avans miktarı
                var sonBirYildakiOnaylananToplamTutar = _db.AvansTalepleri
                    .Where(x => x.SonuclanmaTarihi >= DateTime.Now.AddYears(-1) && x.AvansOnayDurumu == AvansOnayDurumuEnum.Onaylandi)
                    .Sum(x => x.AvansTutari);

                var talepYapilabilecekTarih = _db.AvansTalepleri
                    .Where(x => x.SonuclanmaTarihi >= DateTime.Now.AddYears(-1) && x.AvansOnayDurumu == AvansOnayDurumuEnum.Onaylandi)
                    .OrderBy(x => x.SonuclanmaTarihi).FirstOrDefault()?.SonuclanmaTarihi.Value.AddYears(1);


                var talepEdilebilecekMaksMiktar = Convert.ToDecimal(user.FindFirstValue("MaksAvansHakki")) - sonBirYildakiOnaylananToplamTutar;
                var talepEdilebilecekMinMiktar = Convert.ToDecimal(user.FindFirstValue("MinAvansHakki"));

                if (talepEdilebilecekMaksMiktar < talepEdilebilecekMinMiktar) talepEdilebilecekMinMiktar = talepEdilebilecekMaksMiktar;


                if (avansTalepleri.Any(x => x.AvansOnayDurumu == AvansOnayDurumuEnum.Beklemede))
                    return new ValidationResult("Beklemede bir talebiniz olduğundan yeni avans talep edilemiyor.");
                //else if (avansTalepleri.Any(x => !(x.AvansOnayDurumu == AvansOnayDurumuEnum.Onaylandi)))
                //    return new ValidationResult("Beklemede bir talebiniz olduğundan yeni avans talep edilemiyor.");
                else if (talepEdilebilecekMaksMiktar == 0)
                    return new ValidationResult($"Son bir yıl içindeki avans talebi kotanızı doldurdunuz.{talepYapilabilecekTarih.Value.ToShortDateString()} tarihine kadar yeni talepte bulunamazsınız.");
                else if (talepEdilebilecekMaksMiktar == talepEdilebilecekMinMiktar && vm.AvansTutari <= 0)
                    return new ValidationResult($"₺{talepEdilebilecekMaksMiktar} veya daha düşük miktarda geçerli bir tutar giriniz!");
                else if (talepEdilebilecekMaksMiktar == talepEdilebilecekMinMiktar && vm.AvansTutari > talepEdilebilecekMaksMiktar)
                    return new ValidationResult($"Talep edilebilecek tutar ₺{talepEdilebilecekMaksMiktar} den fazla olamaz!");
                else if (talepEdilebilecekMaksMiktar != talepEdilebilecekMinMiktar && vm.AvansTutari > talepEdilebilecekMaksMiktar)
                    return new ValidationResult($"Talep edilebilecek tutar ₺{talepEdilebilecekMaksMiktar} den fazla olamaz!");
                else if (talepEdilebilecekMaksMiktar != talepEdilebilecekMinMiktar && vm.AvansTutari < talepEdilebilecekMinMiktar)
                    return new ValidationResult($"Talep edilebilecek minimum tutar ₺{talepEdilebilecekMinMiktar} den az olamaz!");

            }
            return ValidationResult.Success;
        }
    }
}
