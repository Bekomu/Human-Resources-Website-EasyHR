using EasyHR.Data;
using EasyHR.Extensions;
using EasyHR.Models;
using EasyHR.Models.Enums;
using EasyHR.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHR.Controllers
{
    [Authorize]
    public class PersonelController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _env;


        public PersonelController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, IWebHostEnvironment env)
        {
            _db = db;
            _userManager = userManager;
            _env = env;
        }

        public IActionResult AvansTalep()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AvansTalep(AvansTalepEkleViewModel vm)
        {
            

            if (ModelState.IsValid)
            {
                ApplicationUser personel = await personelGetir();


                personel.AvansTalepleri.Add(new AvansTalep()
                {
                    AvansTutari = vm.AvansTutari.Value,
                    Aciklama = vm.Aciklama,
                    PersonelId = personel.Id
                });

                _db.SaveChanges();
                TempData["mesaj"] = "Avans talebiniz başarıyla oluşturuldu.";
                return RedirectToAction("AvansTalepListele", "Personel");
            }

            return View(vm);
        }

        public async Task<IActionResult> AvansTalepListele()
        {
            ApplicationUser personel = await personelGetir();

            var vm = _db.AvansTalepleri
                .Where(x => x.PersonelId == personel.Id)
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
                })
                .OrderByDescending(x => x.TalepTarihi)
                .ToList();

            ViewBag.mesaj = TempData["mesaj"];

            return View(vm);
        }

        [HttpPost]
        public IActionResult AvansTalepSil(string avansId)
        {
            if (avansId != null)
            {
                var talepId = Convert.ToInt32(avansId);
                var silinecekAvansTalebi = _db.AvansTalepleri.FirstOrDefault(x => x.Id == talepId);
                if (silinecekAvansTalebi.AvansOnayDurumu != AvansOnayDurumuEnum.Beklemede) return BadRequest();
                _db.AvansTalepleri.Remove(silinecekAvansTalebi);
                _db.SaveChanges();
                return RedirectToAction("AvansTalepListele", "Personel");
            }

            return NotFound();
        }

        public IActionResult HarcamaTalep()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> HarcamaTalep(HarcamaTalepEkleViewModel vm)
        {
            ApplicationUser personel = await personelGetir();

            if (ModelState.IsValid)
            {
                string dosyaUzantisi = Path.GetExtension(vm.Dosya.FileName);
                string dosyaAdi = Guid.NewGuid() + dosyaUzantisi;
                string kaydetmeYolu = Path.Combine(_env.WebRootPath, "personel\\dosyalar", dosyaAdi);

                using (var stream = System.IO.File.Create(kaydetmeYolu))
                {
                    await vm.Dosya.CopyToAsync(stream);
                }

                if (personel.HarcamaTalepleri == null)
                {
                    personel.HarcamaTalepleri = new List<HarcamaTalep>();
                }
                personel.HarcamaTalepleri.Add(new Models.HarcamaTalep()
                {
                    Aciklama = vm.Aciklama,
                    HarcamaTutari = vm.HarcamaTutari,
                    DosyaAdi = dosyaAdi,
                    TalepTarihi = DateTime.Now,
                    HarcamaOnayDurumu = HarcamaOnayDurumuEnum.Beklemede,
                    HarcamaTuru = vm.HarcamaTuru
                });
                _db.SaveChanges();
                TempData["mesaj"] = "Harcama talebiniz başarıyla oluşturuldu.";
                return RedirectToAction("HarcamaTalepListele", "Personel");
            }
            return View(vm);
        }

        public async Task<IActionResult> HarcamaTalepListele()
        {
            ApplicationUser personel = await personelGetir();

            var vm = _db.HarcamaTalepleri
                .Where(x => x.PersonelId == personel.Id)
                .Select(x => new HarcamaTalepListeleViewModel()
                {
                    Id = x.Id,
                    Aciklama = x.Aciklama,
                    HarcamaOnayDurumuStr = x.HarcamaOnayDurumu.GetAttribute<DisplayAttribute>().Name,
                    HarcamaOnayDurumu = x.HarcamaOnayDurumu,
                    HarcamaTutari = x.HarcamaTutari,
                    TalepTarihi = x.TalepTarihi,
                    SonuclanmaTarihi = x.SonuclanmaTarihi,
                    DosyaAdi = x.DosyaAdi
                })
                .OrderByDescending(x => x.TalepTarihi)
                .ToList();

            return View(vm);
        }

        [HttpPost]
        public IActionResult HarcamaTalepSil(string harcamaId)
        {
            if (harcamaId != null)
            {
                var talepId = Convert.ToInt32(harcamaId);
                var silinecekHarcamaTalebi = _db.HarcamaTalepleri.FirstOrDefault(x => x.Id == talepId);
                if (silinecekHarcamaTalebi.HarcamaOnayDurumu != HarcamaOnayDurumuEnum.Beklemede) return BadRequest();
                
               
                string silmeYolu = Path.Combine(_env.WebRootPath, "personel\\dosyalar", silinecekHarcamaTalebi.DosyaAdi);


                _db.HarcamaTalepleri.Remove(silinecekHarcamaTalebi);
                _db.SaveChanges();
                
                if (System.IO.File.Exists(silmeYolu))
                    System.IO.File.Delete(silmeYolu);
                
                return RedirectToAction("HarcamaTalepListele", "Personel");
            }

            return NotFound();
        }

        public IActionResult IzinTalep()
        {
            IzinTurleriniYukle();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> IzinTalep(IzinTalepEkleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var personel = await _userManager.GetUserAsync(User);

                await _db.IzinTalepleri.AddAsync(new IzinTalep()
                {
                    IzinBaslangicTarihi = vm.BaslangicTarihi.Value,
                    IzinBitisTarihi = vm.BitisTarihi.Value,
                    IzinTuru = vm.IzinTuruEnum,
                    IzinGunSayisi = Convert.ToInt32((vm.BitisTarihi - vm.BaslangicTarihi).Value.TotalDays),
                    PersonelId = personel.Id,
                });

                await _db.SaveChangesAsync();

                TempData["mesaj"] = "İzin talebiniz başarıyla oluşturuldu.";
                return RedirectToAction("IzinTalepListele", "Personel"); // Izin talep listeleme sayfası
            }
            IzinTurleriniYukle();
            return View(vm);
        }

        public async Task<IActionResult> IzinTalepListele()
        {
            var personel = await _userManager.GetUserAsync(User);

            var vm = _db.IzinTalepleri
                .Where(x => x.PersonelId == personel.Id)
                .Select(x => new IzinTalepListeleViewModel()
                {
                    Id = x.Id,
                    IzinBaslangicTarihi = x.IzinBaslangicTarihi,
                    IzinBitisTarihi = x.IzinBitisTarihi,
                    IzinGunSayisi = x.IzinGunSayisi,
                    IzinOnayDurumuEnum = x.IzinOnayDurumu,
                    IzinOnayDurumuStr = x.IzinOnayDurumu.GetAttribute<DisplayAttribute>().Name,
                    IzinTuru = x.IzinTuru.GetAttribute<DisplayAttribute>().Name,
                    SonuclanmaTarihi = x.SonuclanmaTarihi,
                    TalepTarihi = x.TalepTarihi
                })
                .OrderByDescending(x => x.TalepTarihi)
                .ToList();

            return View(vm);
        }

        [HttpPost]
        public IActionResult IzinTalepSil(string izinId)
        {
            if (izinId != null)
            {
                var talepId = Convert.ToInt32(izinId);
                var silinecekIzinTalebi = _db.IzinTalepleri.FirstOrDefault(x => x.Id == talepId);
                if (silinecekIzinTalebi.IzinOnayDurumu != IzinOnayDurumuEnum.Beklemede) return BadRequest();
                _db.IzinTalepleri.Remove(silinecekIzinTalebi);
                _db.SaveChanges();
                return RedirectToAction("IzinTalepListele", "Personel");
            }

            return NotFound();
        }

        private async Task<ApplicationUser> personelGetir()
        {
            var personeller = _userManager.Users.Include(x => x.AvansTalepleri).ToList();
            var personel = await _userManager.GetUserAsync(User);
            return personeller.FirstOrDefault(x => x.Id == personel.Id);
        }
        private void IzinTurleriniYukle()
        {
            ViewData["IzinTurleri"] = Enum.GetValues(typeof(IzinTuruEnum)).Cast<IzinTuruEnum>().Select(x => new SelectListItem
            {
                Text = x.GetAttribute<DisplayAttribute>().Name,
                Value = ((int)x).ToString()
            }).ToList();
        }
    }
}
