using EasyHR.Data;
using EasyHR.Models.Enums;
using EasyHR.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EasyHR.Controllers
{
    [Authorize(Roles = "Yonetici, Admin")]
    public class PersonelYonetController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly ApplicationDbContext _db;

        public PersonelYonetController(UserManager<ApplicationUser> userManager, IWebHostEnvironment env, ApplicationDbContext db)
        {
            _userManager = userManager;
            _env = env;
            _db = db;
        }

        public async Task<IActionResult> PersonelKayit()
        {
            PersonelEkleViewModel vm = new PersonelEkleViewModel();

            var user = await _userManager.GetUserAsync(User);

            vm.Meslekler = _db.Meslekler
                .Select(x => new SelectListItem()
                {
                    Text = x.MeslekAdi + " - (" + x.MeslekKodu + ")",
                    Value = x.Id.ToString()
                })
                .OrderBy(x => x.Text)
                .ToList();

            vm.Yoneticiler = _userManager.Users
                .Include(x => x.Sirket)
                .Where(x => x.Unvan == UnvanEnum.Yonetici && x.SirketId == user.SirketId)
                .Select(x => new SelectListItem() { Text = x.Ad + " " + x.Soyad, Value = x.Id.ToString() })
                .ToList();
            vm.Yoneticiler.Insert(0, new SelectListItem() { Text = "Yok", Value = "" });

            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> PersonelKayit(PersonelEkleViewModel vm)
        {
            var yonetici = await _userManager.GetUserAsync(User);
            var yoneticiSirketi = _db.Sirketler.Include(x => x.Paket).FirstOrDefault(x => x.Personeller.Contains(yonetici));

            if (yoneticiSirketi.Paket == null)
            {
                TempData["paketmesaj"] = "Personel eklemeniz için paket satın almanız gerekmektedir.";
                return RedirectToAction("Index","Home");
            }

                if (ModelState.IsValid)
                {
                    if (!string.IsNullOrEmpty(vm.Fotograf.FileName))
                    {
                        string kaydetmeYolu = "";
                        string dosyaAdi = "default.jpg";
                        if (vm.Fotograf.FileName != null)
                        {
                            string dosyaUzantisi = Path.GetExtension(vm.Fotograf.FileName);
                            dosyaAdi = Guid.NewGuid() + dosyaUzantisi;
                            kaydetmeYolu = Path.Combine(_env.WebRootPath, "personel\\fotolar", dosyaAdi);
                        }


                        if (vm.DogumTarihi > vm.IseGirisTarihi)
                        {
                            ModelState.AddModelError("ozelHata", "Doğum tarihi işe giriş tarihinden büyük olamaz.");
                        }

                        var yeniPersonel = new ApplicationUser
                        {
                            Ad = vm.Ad.Trim(),
                            Soyad = vm.Soyad.Trim(),
                            UserName = eMailOlustur(vm.Ad, vm.Soyad, yoneticiSirketi.SirketAdi),
                            Email = eMailOlustur(vm.Ad, vm.Soyad, yoneticiSirketi.SirketAdi),
                            EmailConfirmed = true,
                            DogumTarihi = vm.DogumTarihi,
                            Adres = vm.Adres.Trim(),
                            Telefon = vm.Telefon,
                            IseGirisTarihi = vm.IseGirisTarihi,
                            IzinGuncellemeTarihi = vm.IseGirisTarihi.AddYears(1),
                            TcNo = vm.TcNo, //31766185984
                            FotografAdi = dosyaAdi,
                            Maas = vm.Maas,

                            Cinsiyet = vm.Cinsiyet,
                            Unvan = vm.Unvan,
                            KanGrubu = vm.KanGrubu,
                            MedeniHali = vm.MedeniHali,

                            MeslekId = vm.MeslekId,
                            SirketId = yonetici.SirketId,
                            YoneticiId = vm.YoneticiId
                        };

                        string yeniPersonelParola = sifreOlustur();
                        string yeniPersonelOzelEmail = vm.OzelEmail.Trim();

                        await _userManager.CreateAsync(yeniPersonel, $"{yeniPersonelParola}");
                        await _userManager.AddToRoleAsync(yeniPersonel, "Personel");

                        eMailGonder(yeniPersonel, yeniPersonelParola, yeniPersonelOzelEmail);

                        if (vm.Fotograf.FileName != null)
                        {
                            using (var stream = System.IO.File.Create(kaydetmeYolu))
                            {
                                await vm.Fotograf.CopyToAsync(stream);
                            }
                        }

                        TempData["mesaj"] = "Personel Başarıyla Eklendi.";

                        return RedirectToAction("PersonelListele", "PersonelYonet");
                    }
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
            vm.Yoneticiler.Insert(0, new SelectListItem() { Text = "Yok", Value = "" });
            return View(vm);
        }

        public async Task<IActionResult> PersonelListele()
        {
            PersonelListeleViewModel vm = new PersonelListeleViewModel();
            vm.Personeller = new List<ApplicationUser>();

            var yonetici = await _userManager.GetUserAsync(User);
            var yoneticiSirketi = _db.Sirketler.FirstOrDefault(x => x.Personeller.Contains(yonetici));

            foreach (var personel in _userManager.Users
                .Include(x => x.Meslek)
                .Include(x => x.Sirket)
                .Include(x => x.Yonetici)
                .ToList()
                .OrderBy(x => x.Ad + x.Soyad)
                .Where(x => x.Sirket.SirketAdi == yoneticiSirketi.SirketAdi))
            {
                vm.Personeller.Add(personel);
            }

            ViewBag.mesaj = TempData["mesaj"];

            return View(vm);
        }

        private void eMailGonder(ApplicationUser personel, string parola, string ozelEmail)
        {
            string mailBasligi = "EasyHR üyelik bilgileriniz hakkında.";
            string mailIcerigi = $"Merhaba Sayın {personel.Ad}, <br/><br/> EasyHR.com insan kaynakları sistemine giriş bilgileriniz :<br/> Mail Adresi - Kullanıcı Adı : {personel.UserName} <br/> Parola : {parola} <br/><br/> easyhr3.azurewebsites.net <br/> İş hayatınızda başarılar dileriz :)";

            using (var smtp = new SmtpClient("berkayoz.com", 587))
            {
                smtp.Credentials = new NetworkCredential("no-reply@berkayoz.com", "ddA1g672_");
                MailMessage mail = new MailMessage("no-reply@berkayoz.com", ozelEmail, mailBasligi, mailIcerigi);
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
