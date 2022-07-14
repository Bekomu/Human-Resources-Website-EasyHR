using EasyHR.Extensions;
using EasyHR.Models;
using EasyHR.Models.Context;
using EasyHR.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db;

        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            Personel deneme = new Personel("Samet Berkay", "Özışık");
            //Personel deneme = new Personel("Samet Berkay", "Özışık", "Özçalışanlar");
            deneme.Maas = 10000m;

            deneme.KanGrubu = KanGrubuEnum.AbPozitif;

            // TODO : Burda giriş yapan personelin bilgileri viewModel'a verilecek
            // Database'e Program.cs'de dummy bir veri aktarıldı.
            var girisYapanPersonel = _db.Personeller.Find(5);

            var vm = new PersonelOzetViewModel()
            {
                Ad = girisYapanPersonel.Ad,
                Soyad = girisYapanPersonel.Soyad,
                FotografAdi = girisYapanPersonel.FotografAdi,
                Unvan = girisYapanPersonel.Unvan.GetAttribute<DisplayAttribute>().Name,
                Email = girisYapanPersonel.Email
            };
            return View(vm);
        }

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
