using EasyHR.Data;
using EasyHR.Extensions;
using EasyHR.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHR.Controllers
{
    public class ClientSideValidationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;

        public ClientSideValidationController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> AvansTutariValidation(decimal? avansTutari)
        {
            var personel = await _userManager.GetUserAsync(User);
            var personelId = personel.Id;

            var avansTalepleri = _db.AvansTalepleri.Where(x => x.PersonelId == personelId);

            // son bir yıldaki alınan toplam avans tutarı
            var sonBirYildakiOnaylananToplamTutar = avansTalepleri
                .Where(x => x.SonuclanmaTarihi >= DateTime.Now.AddYears(-1) && x.AvansOnayDurumu == AvansOnayDurumuEnum.Onaylandi)
                .Sum(x => x.AvansTutari);

            var talepYapilabilecekTarih = avansTalepleri
                .Where(x => x.SonuclanmaTarihi >= DateTime.Now.AddYears(-1) && x.AvansOnayDurumu == AvansOnayDurumuEnum.Onaylandi)
                .OrderBy(x => x.SonuclanmaTarihi).FirstOrDefault()?.SonuclanmaTarihi.Value.AddYears(1);


            var talepEdilebilecekMaksMiktar = personel.MaksAvansHakki - sonBirYildakiOnaylananToplamTutar;
            var talepEdilebilecekMinMiktar = personel.MinAvansHakki;

            if (talepEdilebilecekMaksMiktar < talepEdilebilecekMinMiktar) talepEdilebilecekMinMiktar = talepEdilebilecekMaksMiktar;


            if (avansTutari == null)
                return Json("Tutar kısmı boş bırakılamaz!");
            else if (avansTalepleri.Any(x => x.AvansOnayDurumu == AvansOnayDurumuEnum.Beklemede))
                return Json("Beklemede bir talebiniz olduğundan yeni avans talep edilemiyor.");
            else if (talepEdilebilecekMaksMiktar == 0)
                return Json($"Son bir yıl içindeki avans talebi kotanızı doldurdunuz.{talepYapilabilecekTarih.Value.ToShortDateString()} tarihine kadar yeni talepte bulunamazsınız.");
            else if (talepEdilebilecekMaksMiktar == talepEdilebilecekMinMiktar && avansTutari.Value <= 0)
                return Json($"₺{talepEdilebilecekMaksMiktar} veya daha düşük miktarda geçerli bir tutar giriniz!");
            else if (talepEdilebilecekMaksMiktar == talepEdilebilecekMinMiktar && avansTutari.Value > talepEdilebilecekMaksMiktar)
                return Json($"Talep edilebilecek tutar ₺{talepEdilebilecekMaksMiktar} den fazla olamaz!");
            else if (talepEdilebilecekMaksMiktar != talepEdilebilecekMinMiktar && avansTutari.Value > talepEdilebilecekMaksMiktar)
                return Json($"Talep edilebilecek tutar ₺{talepEdilebilecekMaksMiktar} den fazla olamaz!");
            else if (talepEdilebilecekMaksMiktar != talepEdilebilecekMinMiktar && avansTutari.Value < talepEdilebilecekMinMiktar)
                return Json($"Talep edilebilecek minimum tutar ₺{talepEdilebilecekMinMiktar} den az olamaz!");

            return Json(true);
        }


        [AcceptVerbs("GET", "POST")]
        public IActionResult AvansAciklamaValidation(string aciklama)
        {
            if (string.IsNullOrEmpty(aciklama))
                return Json("Açıklama kısmı boş bırakılamaz!");
            if (aciklama.Length > 140)
                return Json("140 karakterden fazla karakter girişi yapılamaz!");

            return Json(true);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult HarcamaAciklamaValidation(string aciklama)
        {
            if (string.IsNullOrEmpty(aciklama))
                return Json("Açıklama kısmı boş bırakılamaz!");
            if (aciklama.Length > 140)
                return Json("140 karakterden fazla karakter girişi yapılamaz!");

            return Json(true);
        }


        [AcceptVerbs("GET", "POST")]
        public IActionResult HarcamaTutariValidation(decimal? harcamaTutari)
        {
            if (harcamaTutari == null)
                return Json("Geçerli bir değer giriniz!");
            if (!(harcamaTutari > 0))
                return Json("Harcama tutarı sıfırdan büyük olmalıdır.");

            return Json(true);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult DosyaValidation(string dosya)
        {
            var dosyaUzantisi = dosya.Split('.')[1];

            var gecerliDosyaUzantilari = "doc,docx,pdf,png,jpg,jpeg,tiff,raw,psd,psb,webp,svg";

            if (!gecerliDosyaUzantilari.Split(',').Any(x => x == dosyaUzantisi))
                return Json("Lütfen .docx .doc .pdf veya image türünde bir dosya yükleyiniz!");

            return Json(true);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult IzinTalepTarihValidation(DateTime? baslangicTarihi, DateTime? bitisTarihi)
        {
            if (baslangicTarihi <= DateTime.Now)
                return Json("İzin başlangıç tarihi bugün ya da önceki bir tarih olamaz!!");
            else if (bitisTarihi < baslangicTarihi)
                return Json("İzin başlangıç tarihi bitiş tarihinden sonraki bir tarih olamaz!!");
            else if (baslangicTarihi == bitisTarihi)
                return Json("İzin başlangıç tarihi ve bitiş tarihi aynı gün olamaz!!");

            return Json(true);
        }


        [AcceptVerbs("GET", "POST")]
        public IActionResult PaketTarihValidation(DateTime? yayimlanmaBaslangic, DateTime? yayimlanmaBitis)
        {
            if (yayimlanmaBaslangic <= DateTime.Now)
                return Json("Yayımlanma tarihi bugün ya da önceki bir tarih olamaz!!");
            else if (yayimlanmaBaslangic > yayimlanmaBitis)
                return Json("Yayımlanma tarihi yayimdan kaldırma tarihinden sonraki bir tarih olamaz!!");
            else if (yayimlanmaBaslangic == yayimlanmaBitis)
                return Json("Yayımlanma tarihi ve yayımdan kaldırma tarihi aynı gün olamaz!");
            else if (yayimlanmaBitis < yayimlanmaBaslangic.Value.AddDays(7))
                return Json("Yayımlanma ve yayımdan kaldırma tarihleri arasında en az 7 gün olmalıdır.");

            return Json(true);
        }

    }
}
