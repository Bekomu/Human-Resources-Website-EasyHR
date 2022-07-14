using EasyHR.Extensions;
using EasyHR.Models;
using EasyHR.Models.Context;
using EasyHR.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EasyHR.Controllers
{
    public class PersonelController : Controller
    {
        private readonly AppDbContext _db;

        public PersonelController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult AvansTalep()
        {
            // todo : burada giriş yapan personelin maaşını göndermemiz gerek.

            var vm = new AvansTalepEkleViewModel();
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AvansTalep(AvansTalepEkleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                // todo : giris yapan personeli çek
                Personel personel = _db.Personeller.Include(x => x.AvansTalepleri).FirstOrDefault(x => x.Id == 5);

                string avansKontrolu = AvansUygunlukKontrolu(personel, vm.AvansTutari);

                if (avansKontrolu != null)
                {
                    ViewBag.Hata = avansKontrolu;
                    ModelState.AddModelError("Hata", ViewBag.Hata);
                    return View(vm);
                }

                // todo : giriş yapan personelin avanstaleplerine ekle
                _db.AvansTalepleri.Add(new AvansTalep()
                {
                    AvansTutari = vm.AvansTutari,
                    Aciklama = vm.Aciklama,
                    PersonelId = 5, // giriş yapan personelin ID'si
                }
                    );
                _db.SaveChanges();
                TempData["mesaj"] = "Avans talebiniz başarıyla oluşturuldu.";
                return RedirectToAction("AvansListele", "Personel");
            }
            return View(vm);
        }

        [HttpGet]
        public IActionResult AvansListele()
        {
            // Database'e Program.cs'de dummy bir veri aktarıldı.
            // Todo : identity veya session ile giriş yapan kullanıcı çekilecek.

            var vm = _db.AvansTalepleri
                .Where(x => x.PersonelId == 5)
                .Select(
                x => new AvansTalepListeleViewModel()
                {
                    Id = x.Id,
                    Aciklama = x.Aciklama,
                    AvansOnayDurumuStr = x.AvansOnayDurumu.GetAttribute<DisplayAttribute>().Name,
                    AvansOnayDurumu = x.AvansOnayDurumu,
                    AvansTutari = x.AvansTutari,
                    TalepTarihi = x.TalepTarihi,
                    SonuclanmaTarihi = x.SonuclanmaTarihi.Value,
                }
                )
                .ToList();

            return View(vm);
        }

        private string AvansUygunlukKontrolu(Personel girisYapanPersonel, decimal talepEdilenAvansTutari)
        {
            decimal maksAvansHakki = girisYapanPersonel.MaksAvansHakki;
            decimal minAvansHakki = girisYapanPersonel.MinAvansHakki;
            decimal verilmisAvans = girisYapanPersonel.AvansTalepleri.Where(x => x.AvansOnayDurumu == AvansOnayDurumuEnum.Onaylandi).Sum(x => x.AvansTutari);

            if (talepEdilenAvansTutari > maksAvansHakki)
            {
                return $"Avans talebiniz yıllık ücretinizin %30'undan (₺{maksAvansHakki}) fazla olamaz.";
            }
            else if (talepEdilenAvansTutari < minAvansHakki)
            {
                return $"Avans talebiniz yıllık ücretinizin %10'undan (₺{minAvansHakki}) az olamaz.";
            }
            else if (verilmisAvans + talepEdilenAvansTutari > maksAvansHakki)
            {
                return $"Bu talebinizle toplam avans hakkınızı (₺{maksAvansHakki}) geçiyorsunuz, talebiniz ₺{maksAvansHakki - verilmisAvans} veya daha az olmalıdır.";
            }
            return null;
        }
    }
}
