using EasyHR.Models;
using EasyHR.Models.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EasyHR.Controllers
{
    public class SirketYoneticisiLoginController : Controller
    {
        private readonly AppDbContext _db;
        public SirketYoneticisiLoginController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Login(SirketYoneticisiLoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                SirketYoneticisi sirketYoneticisi = _db.SirketYoneticileri.FirstOrDefault(x => x.Email.ToLower() == vm.Email.ToLower() && x.Parola == vm.Parola);
                if (sirketYoneticisi != null)
                {
                    // Şirket Yöneticisi Anasayfası yapılınca giriş yap'a basınca Şirket Yöneticisi Anasayfasına yönlendirecek
                    return RedirectToAction("Index", "Home", new { message = "Giriş Başarılı" });
                }

                else
                {
                    TempData["Message"] = "Email veya parola yanlış!";
                }
            }
            return View(vm);
        }
    }
}
