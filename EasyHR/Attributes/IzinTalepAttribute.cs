using EasyHR.Data;
using EasyHR.Models.Enums;
using EasyHR.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace EasyHR.Attributes
{
    public class IzinTalepAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var vm = (IzinTalepEkleViewModel)validationContext.ObjectInstance;

            if (vm == null) return ValidationResult.Success;

            var httpContextAccessor = (IHttpContextAccessor)validationContext.GetService(typeof(IHttpContextAccessor));
            var user = httpContextAccessor.HttpContext.User;

            var cinsiyet = user.FindFirstValue("Cinsiyet");
            var yillikIzinGunSayisi = Convert.ToInt32(user.FindFirstValue("YillikIzinGunSayisi"));

            var talepEdilenIzinGunSayisi = (int)(vm.BitisTarihi - vm.BaslangicTarihi).Value.TotalDays;

            if (vm.BaslangicTarihi <= DateTime.Now)
                return new ValidationResult("İzin başlangıç tarihi bugün ya da önceki bir tarih olamaz!!");

            else if (vm.BitisTarihi <= DateTime.Now)
                return new ValidationResult("İzin bitiş tarihi bugün ya da önceki bir tarih olamaz!!");

            else if (vm.BaslangicTarihi > vm.BitisTarihi)
                return new ValidationResult("İzin başlangıç tarihi bitiş tarihinden sonraki bir tarih olamaz!!");

            else if (vm.BaslangicTarihi == vm.BitisTarihi)
                return new ValidationResult("İzin başlangıç tarihi ve bitiş tarihi aynı gün olamaz!!");

            else if (cinsiyet == "Erkek" && (vm.IzinTuruEnum == IzinTuruEnum.DogumSonrasiIzin || vm.IzinTuruEnum == IzinTuruEnum.DogumIzni))
                return new ValidationResult("Erkek personel kadın personele özel olan izinleri seçemez!");
            else if (cinsiyet == "Kadin" && vm.IzinTuruEnum == IzinTuruEnum.BabalikIzni)
                return new ValidationResult("Kadın personel erkek personele özel olan izinleri seçemez!");
            else if (vm.IzinTuruEnum == IzinTuruEnum.YillikIzin && yillikIzinGunSayisi < talepEdilenIzinGunSayisi)
                return new ValidationResult($"{yillikIzinGunSayisi} günden fazla yıllık izin talebinde bulunamazsınız!");
            else if (vm.IzinTuruEnum == IzinTuruEnum.DogumIzni && talepEdilenIzinGunSayisi != 56)
                return new ValidationResult("Doğum izni 8 hafta (56 gün) olmalıdır!");
            else if (vm.IzinTuruEnum == IzinTuruEnum.DogumSonrasiIzin && talepEdilenIzinGunSayisi != 56)
                return new ValidationResult("Doğum sonrası izin talebi 8 hafta (56 gün) olmalıdır!");
            else if (vm.IzinTuruEnum == IzinTuruEnum.HastalikIzni && talepEdilenIzinGunSayisi > 2)
                return new ValidationResult("2 günden fazla hastalık izni talep edilemez!");
            else if (vm.IzinTuruEnum == IzinTuruEnum.BabalikIzni && talepEdilenIzinGunSayisi > 5)
                return new ValidationResult("5 günden fazla babalık izni talep edilemez!");
            else if (vm.IzinTuruEnum == IzinTuruEnum.MazeretIzni && talepEdilenIzinGunSayisi > 3)
                return new ValidationResult("3 günden fazla mazeret izni talep edilemez!");

            return ValidationResult.Success;
        }
    }
}