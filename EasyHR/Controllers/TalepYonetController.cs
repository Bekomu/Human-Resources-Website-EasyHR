using EasyHR.Data;
using EasyHR.Extensions;
using EasyHR.Models.Enums;
using EasyHR.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHR.Controllers
{
    [Authorize(Roles = "Yonetici, Admin")]
    public class TalepYonetController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public TalepYonetController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Izinler()
        {
            var personel = await _userManager.GetUserAsync(User);

            var vm = _db.IzinTalepleri
                .Include(x => x.Personel)
                .Where(x => x.Personel.YoneticiId == personel.Id)
                .Select(
                x => new IzinTalepleriniYonetViewModel()
                {
                    Id = x.Id,
                    IzinBaslangicTarihi = x.IzinBaslangicTarihi,
                    IzinBitisTarihi = x.IzinBitisTarihi,
                    IzinGunSayisi = x.IzinGunSayisi,
                    TalepTarihi = x.TalepTarihi,
                    IzinOnayDurumuEnum = x.IzinOnayDurumu,
                    IzinOnayDurumuStr = x.IzinOnayDurumu.GetAttribute<DisplayAttribute>().Name,
                    IzinTuru = x.IzinTuru.GetAttribute<DisplayAttribute>().Name,
                    SonuclanmaTarihi = x.SonuclanmaTarihi.Value,
                    TamAd = $"{x.Personel.Ad} {x.Personel.Soyad}"
                })
                .OrderByDescending(x => x.TalepTarihi)
                .ToList();

            return View(vm);
        }

        public async Task<IActionResult> Avanslar()
        {
            var personel = await _userManager.GetUserAsync(User);

            var vm = _db.AvansTalepleri
                .Include(x => x.Personel)
                .Where(x => x.Personel.YoneticiId == personel.Id)
                .Select(
                x => new AvansTalepleriniYonetViewModel()
                {
                    Id = x.Id,
                    TamAd = $"{x.Personel.Ad} {x.Personel.Soyad}",
                    Aciklama = x.Aciklama,
                    AvansOnayDurumu = x.AvansOnayDurumu,
                    AvansOnayDurumuStr = x.AvansOnayDurumu.GetAttribute<DisplayAttribute>().Name,
                    AvansTutari = x.AvansTutari,
                    TalepTarihi = x.TalepTarihi,
                    SonuclanmaTarihi = x.SonuclanmaTarihi.Value
                })
                .OrderByDescending(x => x.TalepTarihi)
                .ToList();

            return View(vm);
        }

        public async Task<IActionResult> Harcamalar()
        {
            var personel = await _userManager.GetUserAsync(User);

            var vm = _db.HarcamaTalepleri
                .Include(x => x.Personel)
                .Where(x => x.Personel.YoneticiId == personel.Id)
                .Select(
                x => new HarcamaTalepleriniYonetViewModel()
                {
                    Id = x.Id,
                    TamAd = $"{x.Personel.Ad} {x.Personel.Soyad}",
                    Aciklama = x.Aciklama,
                    DosyaAdi = x.DosyaAdi,
                    HarcamaOnayDurumu = x.HarcamaOnayDurumu,
                    HarcamaOnayDurumuStr = x.HarcamaOnayDurumu.GetAttribute<DisplayAttribute>().Name,
                    HarcamaTutari = x.HarcamaTutari,
                    TalepTarihi = x.TalepTarihi,
                    SonuclanmaTarihi = x.SonuclanmaTarihi.Value
                })
                .OrderByDescending(x => x.TalepTarihi)
                .ToList();

            return View(vm);
        }

        //Avans işlemleri


        [HttpPost]
        public IActionResult AvansOnayla(string avansId)
        {
            if (avansId != null)
            {
                var talepId = Convert.ToInt32(avansId);
                var onaylanacakAvansTalebi = _db.AvansTalepleri.FirstOrDefault(x => x.Id == talepId);

                if (onaylanacakAvansTalebi.AvansOnayDurumu != AvansOnayDurumuEnum.Beklemede) return BadRequest();

                onaylanacakAvansTalebi.AvansOnayDurumu = AvansOnayDurumuEnum.Onaylandi;
                onaylanacakAvansTalebi.SonuclanmaTarihi = DateTime.Now;
                _db.Update(onaylanacakAvansTalebi);
                _db.SaveChanges();
                return RedirectToAction("Avanslar", "TalepYonet");
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AvansReddet(string avansId)
        {
            if (avansId != null)
            {
                var talepId = Convert.ToInt32(avansId);
                var reddedilecekAvansTalebi = _db.AvansTalepleri.FirstOrDefault(x => x.Id == talepId);

                if (reddedilecekAvansTalebi.AvansOnayDurumu != AvansOnayDurumuEnum.Beklemede) return BadRequest();

                reddedilecekAvansTalebi.AvansOnayDurumu = AvansOnayDurumuEnum.Reddedildi;
                reddedilecekAvansTalebi.SonuclanmaTarihi = DateTime.Now;
                _db.Update(reddedilecekAvansTalebi);
                _db.SaveChanges();
                return RedirectToAction("Avanslar", "TalepYonet");
            }
            return NotFound();
        }

        //İzin işlemleri

        [HttpPost]
        public IActionResult IzinOnayla(string izinId)
        {
            if (izinId != null)
            {
                var talepId = Convert.ToInt32(izinId);
                var onaylanacakIzinTalebi = _db.IzinTalepleri.FirstOrDefault(x => x.Id == talepId);

                if (onaylanacakIzinTalebi.IzinOnayDurumu != IzinOnayDurumuEnum.Beklemede) return BadRequest();

                onaylanacakIzinTalebi.IzinOnayDurumu = IzinOnayDurumuEnum.Onaylandi;
                onaylanacakIzinTalebi.SonuclanmaTarihi = DateTime.Now;

                if (onaylanacakIzinTalebi.IzinTuru == IzinTuruEnum.YillikIzin)
                {
                    var talepteBulunanPersonel = _userManager.Users.FirstOrDefault(p => p.IzinTalepleri.Any(i => i.Id == talepId));
                    talepteBulunanPersonel.YillikIzinGunSayisi -= onaylanacakIzinTalebi.IzinGunSayisi;
                }

                _db.Update(onaylanacakIzinTalebi);
                _db.SaveChanges();
                return RedirectToAction("Izinler", "TalepYonet");
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult IzinReddet(string izinId)
        {
            if (izinId != null)
            {
                var talepId = Convert.ToInt32(izinId);
                var reddedilecekIzinTalebi = _db.IzinTalepleri.FirstOrDefault(x => x.Id == talepId);

                if (reddedilecekIzinTalebi.IzinOnayDurumu != IzinOnayDurumuEnum.Beklemede) return BadRequest();

                reddedilecekIzinTalebi.IzinOnayDurumu = IzinOnayDurumuEnum.Reddedildi;
                reddedilecekIzinTalebi.SonuclanmaTarihi = DateTime.Now;
                _db.Update(reddedilecekIzinTalebi);
                _db.SaveChanges();
                return RedirectToAction("Avanslar", "TalepYonet");
            }
            return NotFound();
        }

        //Harcama işlemleri
        [HttpPost]
        public IActionResult HarcamaOnayla(string harcamaId)
        {
            if (harcamaId != null)
            {
                var talepId = Convert.ToInt32(harcamaId);
                var onaylanacakHarcamaTalebi = _db.HarcamaTalepleri.FirstOrDefault(x => x.Id == talepId);

                if (onaylanacakHarcamaTalebi.HarcamaOnayDurumu != HarcamaOnayDurumuEnum.Beklemede) return BadRequest();

                onaylanacakHarcamaTalebi.HarcamaOnayDurumu = HarcamaOnayDurumuEnum.Onaylandi;
                onaylanacakHarcamaTalebi.SonuclanmaTarihi = DateTime.Now;
                _db.Update(onaylanacakHarcamaTalebi);
                _db.SaveChanges();
                return RedirectToAction("Harcamalar", "TalepYonet");
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult HarcamaReddet(string harcamaId)
        {
            if (harcamaId != null)
            {
                var talepId = Convert.ToInt32(harcamaId);
                var reddedilecekHarcamaTalebi = _db.HarcamaTalepleri.FirstOrDefault(x => x.Id == talepId);

                if (reddedilecekHarcamaTalebi.HarcamaOnayDurumu != HarcamaOnayDurumuEnum.Beklemede) return BadRequest();

                reddedilecekHarcamaTalebi.HarcamaOnayDurumu = HarcamaOnayDurumuEnum.Reddedildi;
                reddedilecekHarcamaTalebi.SonuclanmaTarihi = DateTime.Now;
                _db.Update(reddedilecekHarcamaTalebi);
                _db.SaveChanges();
                return RedirectToAction("Harcamalar", "TalepYonet");
            }
            return NotFound();
        }
    }
}
