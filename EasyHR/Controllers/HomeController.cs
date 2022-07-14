using EasyHR.Extensions;
using EasyHR.Data;
using EasyHR.Models;
using EasyHR.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EasyHR.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EasyHR.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _logger = logger;
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (User.IsInRole("Personel"))
            {
                var avansTalepleri = _db.AvansTalepleri
                    .Include(x => x.Personel)
                    .Where(x => x.Personel.Id == user.Id)
                    .OrderByDescending(x => x.TalepTarihi)
                    .Take(5)
                    .ToList();

                var izinTalepleri = _db.IzinTalepleri
                    .Include(x => x.Personel)
                    .Where(x => x.Personel.Id == user.Id)
                    .OrderByDescending(x => x.TalepTarihi)
                    .Take(5)
                    .ToList();

                var harcamaTalepleri = _db.HarcamaTalepleri
                    .Include(x => x.Personel)
                    .Where(x => x.Personel.Id == user.Id)
                    .OrderByDescending(x => x.TalepTarihi)
                    .Take(5)
                    .ToList();

                var vm = new HomeViewModel()
                {
                    Ad = user.Ad,
                    Soyad = user.Soyad,
                    Email = user.UserName,
                    Unvan = user.Unvan.GetAttribute<DisplayAttribute>().Name,
                    AvansTalepleri = new List<AvansTalep>(),
                    IzinTalepleri = new List<IzinTalep>(),
                    HarcamaTalepleri = new List<HarcamaTalep>(),
                };

                vm.AvansTalepleri.AddRange(avansTalepleri);
                vm.IzinTalepleri.AddRange(izinTalepleri);
                vm.HarcamaTalepleri.AddRange(harcamaTalepleri);

                return View(vm);

            }
            else if (User.IsInRole("Yonetici") || User.IsInRole("Admin"))
            {
                var avansTalepleri = _db.AvansTalepleri
                    .Include(x => x.Personel)
                    .Where(x => x.Personel.Id == user.Id)
                    .OrderByDescending(x => x.TalepTarihi)
                    .Take(5)
                    .ToList();

                var izinTalepleri = _db.IzinTalepleri
                    .Include(x => x.Personel)
                    .Where(x => x.Personel.Id == user.Id)
                    .OrderByDescending(x => x.TalepTarihi)
                    .Take(5)
                    .ToList();

                var harcamaTalepleri = _db.HarcamaTalepleri
                    .Include(x => x.Personel)
                    .Where(x => x.Personel.Id == user.Id)
                    .OrderByDescending(x => x.TalepTarihi)
                    .Take(5)
                    .ToList();

                var personelAvansTalepleri = _db.AvansTalepleri
                    .Include(x => x.Personel)
                    .Where(x => x.Personel.YoneticiId == user.Id)
                    .OrderByDescending(x => x.TalepTarihi)
                    .Take(5)
                    .ToList();

                var personelIzinTalepleri = _db.IzinTalepleri
                    .Include(x => x.Personel)
                    .Where(x => x.Personel.YoneticiId == user.Id)
                    .OrderByDescending(x => x.TalepTarihi)
                    .Take(5)
                    .ToList();

                var personelHarcamaTalepleri = _db.HarcamaTalepleri
                    .Include(x => x.Personel)
                    .Where(x => x.Personel.YoneticiId == user.Id)
                    .OrderByDescending(x => x.TalepTarihi)
                    .Take(5)
                    .ToList();

                var satistakiPaketler = _db.Paketler
                    .Where(x => x.SatistaMi == true)
                    .OrderBy(x => x.YayimlanmaTarihi)
                    .ToList();

                //var satistaOlmayanPaketler = _db.Paketler
                //    .Where(x => x.SatistaMi == false)
                //    .OrderBy(x => x.YayimlanmaTarihi)
                //    .ToList();

                //if (satistaOlmayanPaketler != null)
                //{
                //    foreach (var paket in satistaOlmayanPaketler)
                //    {
                //        if (paket.YayimlanmaTarihi <= DateTime.Now)
                //        {
                //            paket.SatistaMi = true;
                //            satistakiPaketler.Add(paket);
                //        }
                //    }
                //}

                var vm = new HomeViewModel()
                {
                    Ad = user.Ad,
                    Soyad = user.Soyad,
                    Email = user.UserName,
                    Unvan = user.Unvan.GetAttribute<DisplayAttribute>().Name,
                    AvansTalepleri = new List<AvansTalep>(),
                    IzinTalepleri = new List<IzinTalep>(),
                    HarcamaTalepleri = new List<HarcamaTalep>(),
                    PersonelAvansTalepleri = new List<AvansTalep>(),
                    PersonelIzinTalepleri = new List<IzinTalep>(),
                    PersonelHarcamaTalepleri = new List<HarcamaTalep>(),
                    SatistakiPaketler = new List<Paket>()

                };

                vm.AvansTalepleri.AddRange(avansTalepleri);
                vm.IzinTalepleri.AddRange(izinTalepleri);
                vm.HarcamaTalepleri.AddRange(harcamaTalepleri);

                vm.PersonelAvansTalepleri.AddRange(personelAvansTalepleri);
                vm.PersonelIzinTalepleri.AddRange(personelIzinTalepleri);
                vm.PersonelHarcamaTalepleri.AddRange(personelHarcamaTalepleri);

                vm.SatistakiPaketler.AddRange(satistakiPaketler);

                return View(vm);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> PaketSatinAl(int paketId)
        {
            var satinAlinanPaket = _db.Paketler.FirstOrDefault(x => x.Id == paketId);
            var yonetici = await _userManager.GetUserAsync(User);
            var yoneticiSirketi = _db.Sirketler.Include(x => x.Paket).Include(x => x.Cuzdan).FirstOrDefault(x => x.Personeller.Contains(yonetici));
            var sirketCuzdani = yoneticiSirketi.Cuzdan;

            // TODO : TOKAT !!!!! ŞİRKET CÜZDANINDA YETERLİ BAKİYE VAR MI ? VARSA VE YOKSA İF LERİ
            if (sirketCuzdani.ToplamBakiye < satinAlinanPaket.Tutar)
            {
                TempData["mesaj"] = "Yetersiz bakiye! Lütfen bakiye yükleyiniz!";
                return RedirectToAction("Cuzdan");
            }

            sirketCuzdani.ToplamBakiye -= satinAlinanPaket.Tutar;

            yoneticiSirketi.PaketId = paketId;
            _db.Update(yoneticiSirketi);
            _db.SaveChanges();

            if (true)
            {
                TempData["mesaj"] = $"{satinAlinanPaket.Ad} paketini başarıyla satın aldınız.";
                //return Json(new { redirectToUrl = Url.Action("MevcutPaket", "Home") });
                return RedirectToAction("MevcutPaket", "Home");
            }
            else
            {
                TempData["mesaj"] = $"{satinAlinanPaket.Ad} paketini yeterli bakiyeniz olmadığı için satın alma işlemi başarısız. Paket tutarı : {satinAlinanPaket.Tutar}";
                return RedirectToAction("MevcutPaket", "Home");
                // TODO : TOKAT !!!!! ŞİRKET CÜZDANINDA YETERLİ BAKİYE VAR MI ? VARSA VE YOKSA İF LERİ
            }
        }


        public async Task<IActionResult> MevcutPaket()
        {
            var yonetici = await _userManager.GetUserAsync(User);
            var yoneticiSirketi = _db.Sirketler.Include(x => x.Paket).FirstOrDefault(x => x.Personeller.Contains(yonetici));
            var mevcutPaket = yoneticiSirketi.Paket;

            if (mevcutPaket != null)
            {
                PaketListeleViewModel vm = new PaketListeleViewModel()
                {
                    Ad = mevcutPaket.Ad,
                    FotografAdi = mevcutPaket.FotografAdi,
                    KullaniciSayisi = mevcutPaket.KullaniciSayisi,
                    KullanimSuresiGun = mevcutPaket.KullanimSuresiGun,
                    Tutar = mevcutPaket.Tutar,
                    ParaBirimiStr = mevcutPaket.ParaBirimiEnum.GetAttribute<DisplayAttribute>().Name.Substring(0, 2),
                    YayimlanmaTarihi = mevcutPaket.YayimlanmaTarihi,
                    YayimdanAlmaTarihi = mevcutPaket.YayimdanAlmaTarihi
                };

                ViewBag.mesaj = TempData["mesaj"];
                return View(vm);
            }
            else
            {
                ViewBag.mesaj = "AKTİF OLAN BİR PAKETİNİZ BULUNMUYOR.";
                return View();
            }
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
