using EasyHR.Data;
using EasyHR.Models;
using EasyHR.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EasyHR.Controllers
{
    public class YoneticiController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public YoneticiController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Cuzdan()
        {
            KartlariGetir();
            var personel = _userManager.GetUserAsync(User);
            var sirketId = personel.Result.SirketId;
            var cuzdan = _db.Cuzdanlar.FirstOrDefault(c => c.SirketId == sirketId);

            if (cuzdan == null)
            {
                var yeniCuzdan = new Cuzdan() { SirketId = sirketId, ToplamBakiye = 0 };
                _db.Cuzdanlar.Add(yeniCuzdan);
                _db.SaveChanges();

                _db.Sirketler.Include(x => x.Cuzdan).FirstOrDefault(x => x.Id == sirketId).CuzdanId = yeniCuzdan.Id;
                _db.SaveChanges();
            }

            return View(new CuzdanViewModel() { CuzdandakiMevcutPara = _db.Cuzdanlar.FirstOrDefault(c => c.SirketId == sirketId).ToplamBakiye });
        }

        private void KartlariGetir()
        {
            var personel = _userManager.GetUserAsync(User);
            var sirketId = personel.Result.SirketId;
            var kartlar = _db.Kartlar.Where(k => k.SirketId == sirketId).ToList();
            ViewData["Kartlar"] = kartlar.Select(x => new SelectListItem
            {
                Text = x.KartIsmi,
                Value = x.Id.ToString()
            }).ToList();
        }

        public IActionResult KartEkle()
        {
            return View();
        }


        [HttpPost]
        public IActionResult KartEkle(KartEkleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var personel = _userManager.GetUserAsync(User);
                var sirketId = personel.Result.SirketId;

                _db.Kartlar.Add(new Kart()
                {
                    AdSoyad = vm.AdSoyad,
                    KartNumarasi = vm.KartNumarasi,
                    SKT = vm.SKT,
                    KartIsmi = vm.KartIsmi,
                    CVC2 = vm.CVC2,
                    Limit = 10000,
                    SirketId = sirketId
                });

                _db.SaveChanges();

                // TODO: ViewBag.mesaj eklenecek
                return RedirectToAction("Cuzdan");
            }
            return View(vm);
        }

        [HttpPost]
        public IActionResult BakiyeEkle(CuzdanViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var kart = _db.Kartlar.FirstOrDefault(x => x.Id == vm.KartId.Value);
                kart.Limit -= vm.EklenecekBakiye.Value;

                var personel = _userManager.GetUserAsync(User);
                var sirketId = personel.Result.SirketId;
                var cuzdan = _db.Cuzdanlar.FirstOrDefault(c => c.SirketId == sirketId);

                cuzdan.ToplamBakiye += vm.EklenecekBakiye.Value;

                _db.SaveChanges();

                return RedirectToAction("Cuzdan");
            }
            return RedirectToAction("Cuzdan", vm);
        }
    }
}
