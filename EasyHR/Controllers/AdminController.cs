using EasyHR.Data;
using EasyHR.Extensions;
using EasyHR.Models;
using EasyHR.Models.Enums;
using EasyHR.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EasyHR.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _env;

        public AdminController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext db, IWebHostEnvironment env)
        {
            _logger = logger;
            _userManager = userManager;
            _db = db;
            _env = env;
        }

        public IActionResult SirketOlustur()
        {
            SirketOlusturViewModel vm = new SirketOlusturViewModel();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> SirketOlustur(SirketOlusturViewModel vm)
        {
            if (ModelState.IsValid)
            {
                string kaydetmeYolu = "";
                string dosyaAdi = "default.jpg";
                if (vm.Logo.FileName != null)
                {
                    string dosyaUzantisi = Path.GetExtension(vm.Logo.FileName);
                    dosyaAdi = Guid.NewGuid() + dosyaUzantisi;
                    kaydetmeYolu = Path.Combine(_env.WebRootPath, "sirket\\logo", dosyaAdi);
                }

                if (_db.Sirketler.Select(x => x.SirketAdi).Contains(vm.SirketAdi.Trim()))
                {
                    ViewBag.Hata = "Benzer isimde bir şirket zaten var.";
                    ModelState.AddModelError("Hata", ViewBag.Hata);
                    return View(vm);
                }

                Sirket yeniSirket = new Sirket()
                {
                    DosyaAdi = dosyaAdi,
                    MersisNo = vm.MersisNo,
                    Sektor = vm.Sektor,
                    SirketAdi = vm.SirketAdi,
                    SirketAdres = vm.SirketAdres,
                    SirketEmail = vm.SirketEmail,
                    SirketInfo = vm.SirketInfo,
                    SirketTuru = vm.SirketTuru,
                    SirketTelefonNo = vm.SirketTelefonNo,
                    SirketKurulusTarihi = vm.SirketKurulusTarihi,
                    SirketUyeOlmaTarihi = DateTime.Now,
                    SirketWebSitesi = vm.SirketWebSitesi,
                    VergiDairesi = vm.VergiDairesi,
                    VergiNo = vm.VergiNo
                };

                _db.Sirketler.Add(yeniSirket);
                _db.SaveChanges();

                if (vm.Logo.FileName != null)
                {
                    using (var stream = System.IO.File.Create(kaydetmeYolu))
                    {
                        await vm.Logo.CopyToAsync(stream);
                    }
                }

                TempData["Mesaj"] = $"{vm.SirketAdi} isimli şirket başarıyla eklendi.";
                return RedirectToAction("SirketListele", "Admin");
            }
            return View();
        }

        public IActionResult SirketListele()
        {
            SirketListeleViewModel vm = new SirketListeleViewModel();
            vm.Sirketler = new List<Sirket>();

            // detaylı bilgi istenmesi durumunda aşağıdaki gibi verildi. sadeleştirilebilir.
            var liste = _db.Sirketler.Include(x => x.Personeller).ThenInclude(x => x.Meslek).ToList();
            vm.Sirketler.AddRange(liste);
            ViewBag.mesaj = TempData["Mesaj"];
            return View(vm);
        }

        public IActionResult YoneticiEkle()
        {
            YoneticiEkleViewModel vm = new YoneticiEkleViewModel();

            vm.Meslekler = _db.Meslekler
                .Select(x => new SelectListItem()
                {
                    Text = x.MeslekAdi + " - (" + x.MeslekKodu + ")",
                    Value = x.Id.ToString()
                })
                .OrderBy(x => x.Text)
                .ToList();

            vm.Yoneticiler = _userManager.Users
                .Where(x => x.Unvan == UnvanEnum.Yonetici)
                .Select(x => new SelectListItem()
                {
                    Text = x.Ad + " " + x.Soyad,
                    Value = x.Id.ToString()
                })
                .ToList();

            vm.Sirketler = _db.Sirketler
                .Select(x => new SelectListItem()
                {
                    Text = x.SirketAdi,
                    Value = x.Id.ToString()
                })
                .OrderBy(x => x.Text)
                .ToList();

            vm.Yoneticiler.Insert(0, new SelectListItem() { Text = "Yok", Value = "" });

            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> YoneticiEkle(YoneticiEkleViewModel vm)
        {

            if (ModelState.IsValid)
            {
                string kaydetmeYolu = "";
                string dosyaAdi = "default.jpg";
                if (vm.Fotograf.FileName != null)
                {
                    string dosyaUzantisi = Path.GetExtension(vm.Fotograf.FileName);
                    dosyaAdi = Guid.NewGuid() + dosyaUzantisi;
                    kaydetmeYolu = Path.Combine(_env.WebRootPath, "personel\\fotolar", dosyaAdi);
                }

                var yeniYoneticiSirket = await _db.Sirketler.FirstAsync(x => x.Id == vm.SirketId);

                if (vm.DogumTarihi > vm.IseGirisTarihi)
                {
                    ModelState.AddModelError("ozelHata", "Doğum tarihi işe giriş tarihinden büyük olamaz.");
                }

                var yeniYonetici = new ApplicationUser
                {
                    Ad = vm.Ad.Trim(),
                    Soyad = vm.Soyad.Trim(),
                    UserName = eMailOlustur(vm.Ad, vm.Soyad, yeniYoneticiSirket.SirketAdi),
                    Email = eMailOlustur(vm.Ad, vm.Soyad, yeniYoneticiSirket.SirketAdi),
                    EmailConfirmed = true,
                    DogumTarihi = vm.DogumTarihi,
                    Adres = vm.Adres.Trim(),
                    FotografAdi = dosyaAdi,
                    Telefon = vm.Telefon,
                    IseGirisTarihi = vm.IseGirisTarihi,
                    IzinGuncellemeTarihi = vm.IseGirisTarihi.AddYears(1),
                    TcNo = vm.TcNo, //31766185984
                    Maas = vm.Maas,

                    Cinsiyet = vm.Cinsiyet,
                    Unvan = vm.Unvan,
                    KanGrubu = vm.KanGrubu,
                    MedeniHali = vm.MedeniHali,

                    MeslekId = vm.MeslekId,
                    SirketId = vm.SirketId,
                    YoneticiId = vm.YoneticiId
                };

                string yeniYoneticiParola = sifreOlustur();
                string yeniYoneticiOzelEmail = vm.OzelEmail.Trim();

                await _userManager.CreateAsync(yeniYonetici, $"{yeniYoneticiParola}");
                await _userManager.AddToRoleAsync(yeniYonetici, "Yonetici");

                eMailGonder(yeniYonetici, yeniYoneticiParola, yeniYoneticiOzelEmail);

                if (vm.Fotograf.FileName != null)
                {
                    using (var stream = System.IO.File.Create(kaydetmeYolu))
                    {
                        await vm.Fotograf.CopyToAsync(stream);
                    }
                }

                TempData["mesaj"] = "Personel Başarıyla Eklendi.";
                return RedirectToAction("YoneticiListele", "Admin");
            }

            vm.Meslekler = _db.Meslekler
                .Select(x => new SelectListItem()
                {
                    Text = x.MeslekAdi + " - (" + x.MeslekKodu + ")",
                    Value = x.Id.ToString()
                })
                .OrderBy(x => x.Text)
                .ToList();

            vm.Yoneticiler = _userManager.Users
                .Where(x => x.Unvan == UnvanEnum.Yonetici)
                .Select(x => new SelectListItem()
                {
                    Text = x.Ad + " " + x.Soyad,
                    Value = x.Id.ToString()
                })
                .ToList();

            vm.Sirketler = _db.Sirketler
                .Select(x => new SelectListItem()
                {
                    Text = x.SirketAdi,
                    Value = x.Id.ToString()
                })
                .OrderBy(x => x.Text)
                .ToList();

            vm.Yoneticiler.Insert(0, new SelectListItem() { Text = "Yok", Value = "" });
            return View(vm);
        }

        public async Task<IActionResult> YoneticiListele()
        {
            PersonelListeleViewModel vm = new PersonelListeleViewModel();
            vm.Personeller = new List<ApplicationUser>();

            foreach (var yonetici in _userManager.Users.Include(x => x.Sirket).ToList())
            {
                if (await _userManager.IsInRoleAsync(yonetici, "Yonetici"))
                {
                    vm.Personeller.Add(yonetici);
                }
            }
            ViewBag.mesaj = TempData["mesaj"];
            return View(vm);
        }

        public IActionResult PaketListele()
        {
            var vm = _db.Paketler.Select(x =>
            new PaketListeleViewModel()
            {
                Id = x.Id,
                Ad = x.Ad,
                FotografAdi = x.FotografAdi,
                KullaniciSayisi = x.KullaniciSayisi,
                 KullanimSuresiGun = x.KullanimSuresiGun,
                 OlusturulmaTarihi = x.OlusturulmaTarihi,
                 ParaBirimiStr = x.ParaBirimiEnum.GetAttribute<DisplayAttribute>().Name,
                 SatistaMi = x.SatistaMi,
                 Tutar = x.Tutar,
                 YayimlanmaTarihi = x.YayimlanmaTarihi,
                 YayimdanAlmaTarihi = x.YayimdanAlmaTarihi
            }).ToList();

            return View(vm);
        }


        public IActionResult PaketEkle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PaketEkle(PaketEkleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                string kaydetmeYolu = "";
                string dosyaAdi = "default.jpg";
                if (vm.PaketFotografi != null)
                {
                    string dosyaUzantisi = Path.GetExtension(vm.PaketFotografi.FileName);
                    dosyaAdi = Guid.NewGuid() + dosyaUzantisi;
                    kaydetmeYolu = Path.Combine(_env.WebRootPath, "admin\\paket", dosyaAdi);
                }

                Paket yeniPaket = new Paket()
                {
                    Ad = vm.Ad,
                    FotografAdi = dosyaAdi,
                    KullaniciSayisi = vm.KullaniciSayisi,
                    OlusturulmaTarihi = DateTime.Now,
                    ParaBirimiEnum = vm.ParaBirimiEnum,
                    SatistaMi = false,
                    Tutar = vm.Tutar,
                    YayimlanmaTarihi = vm.YayimlanmaBaslangic.Value,
                    YayimdanAlmaTarihi = vm.YayimlanmaBitis.Value,
                    KullanimSuresiGun = vm.KullanilmaSuresi,
                };

                _db.Paketler.Add(yeniPaket);
                _db.SaveChanges();

                if (vm.PaketFotografi != null)
                {
                    using (var stream = System.IO.File.Create(kaydetmeYolu))
                    {
                        await vm.PaketFotografi.CopyToAsync(stream);
                    }
                }

                TempData["mesaj"] = "Paket Başarıyla Eklendi.";
                return RedirectToAction("PaketListele", "Admin");
            }
            return View(vm);
        }

        //private void eMailGonder(ApplicationUser personel, string parola, string ozelEmail)
        //{
        //    string mailBasligi = "EasyHR üyelik bilgileriniz hakkında.";
        //    string mailIcerigi = $"Merhaba Sayın {personel.Ad}, <br/><br/> EasyHR.com insan kaynakları sistemine giriş bilgileriniz :<br/> Mail Adresi - Kullanıcı Adı : {personel.UserName} <br/> Parola : {parola} <br/><br/> easyhr3.azurewebsites.net <br/>İş hayatınızda başarılar dileriz :)";

        //    using (var smtp = new SmtpClient("berkayoz.com", 587))
        //    {
        //        smtp.Credentials = new NetworkCredential("no-reply@berkayoz.com", "ddA1g672_");
        //        MailMessage mail = new MailMessage("no-reply@berkayoz.com", ozelEmail, mailBasligi, mailIcerigi);
        //        mail.IsBodyHtml = true;
        //        smtp.EnableSsl = true;
        //        smtp.Send(mail);
        //    }
        //}

        private void eMailGonder(ApplicationUser personel, string parola, string ozelEmail)
        {
            string mailBasligi = "EasyHR üyelik bilgileriniz hakkında.";
            string mailIcerigi = $"Merhaba Sayın {personel.Ad}, <br/><br/> EasyHR.com insan kaynakları sistemine giriş bilgileriniz :<br/> Mail Adresi - Kullanıcı Adı : {personel.UserName} <br/> Parola : {parola} <br/><br/> easyhr3.azurewebsites.net <br/>İş hayatınızda başarılar dileriz :)";

            using (var smtp = new SmtpClient("smtp-mail.outlook.com", 587))
            {
                smtp.Credentials = new NetworkCredential("bozisik93@hotmail.com", "sbbo1993--");
                MailMessage mail = new MailMessage("bozisik93@hotmail.com", ozelEmail, mailBasligi, mailIcerigi);
                mail.IsBodyHtml = true;
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
        }

        private string sifreOlustur()
        {
            Random rnd = new Random();
            List<char> dizi = new List<char>();

            for (int i = 0; i < 11; i++)
            {
                char buyukHarf = (char)rnd.Next(65, 90);
                char karakter = (char)rnd.Next(35, 38);
                char kucukHarf = (char)rnd.Next(97, 122);
                char sayi = (char)rnd.Next(48, 57);
                switch (i)
                {
                    case 0: dizi.Add(buyukHarf); break;
                    case 1:
                    case 2:
                    case 3: dizi.Add(sayi); break;
                    case 4:
                    case 5:
                    case 6: dizi.Add(kucukHarf); break;
                    case 7:
                    case 8:
                    case 9: dizi.Add(sayi); break;
                    case 10: dizi.Add(karakter); break;
                }
            }

            return String.Join("", dizi);
        }

        private string eMailOlustur(string ad, string soyad, string sirketAdi)
        {
            string email = ad.Replace(" ", "") + "." + soyad.Replace(" ", "") + $"@{sirketAdi.Replace(" ", "")}.com";
            email = email.ToLower();
            string turkceKarakterler = "ıçöğüş";
            string ingilizceKarakterler = "icogus";

            for (int i = 0; i < turkceKarakterler.Length; i++)
            {
                email = email.Replace(turkceKarakterler[i], ingilizceKarakterler[i]);
            }
            return email.ToLower();
        }
    }
}
