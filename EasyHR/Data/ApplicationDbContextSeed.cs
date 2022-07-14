using EasyHR.Models;
using EasyHR.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace EasyHR.Data
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            var roles = new string[] { "Admin", "Personel", "Yonetici" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            if (!await userManager.Users.AnyAsync())
            {
                var admin = new ApplicationUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    EmailConfirmed = true,
                    Ad = "Admin",
                    Soyad = "Admin",
                    DogumTarihi = new DateTime(1994, 02, 02),
                    Adres = "Kızılırmak Mah. No:40/2 Yenimahalle/Ankara",
                    Telefon = 9673532325,
                    IseGirisTarihi = new DateTime(2010, 11, 20),
                    TcNo = "63003338406",
                    FotografAdi = "default.jpg",
                    Maas = 30000,
                    Cinsiyet = CinsiyetEnum.Kadin,
                    Unvan = UnvanEnum.Yonetici,
                    KanGrubu = KanGrubuEnum.SifirPozitif,
                    MedeniHali = MedeniHalEnum.Evli,
                    MeslekId = 1,
                    SirketId = 1,
                };

                var yonetici = new ApplicationUser
                {
                    UserName = "berkay.ozisik@easyhr.com",
                    Email = "berkay.ozisik@easyhr.com",
                    EmailConfirmed = true,
                    Ad = "Berkay",
                    Soyad = "Özışık",
                    DogumTarihi = new DateTime(1995, 03, 03),
                    Adres = "Kışlalı Mah. No:30/2 Çankaya/Ankara",
                    Telefon = 5965323273,
                    IseGirisTarihi = new DateTime(2015, 12, 31),
                    TcNo = "33384066300",
                    FotografAdi = "berkay.jpg",
                    Maas = 20000,
                    Cinsiyet = CinsiyetEnum.Erkek,
                    Unvan = UnvanEnum.Yonetici,
                    KanGrubu = KanGrubuEnum.SifirPozitif,
                    MedeniHali = MedeniHalEnum.Bekar,
                    MeslekId = 1,
                    SirketId = 1,
                };

                var personel = new ApplicationUser
                {
                    UserName = "ahmet.sarikaya@easyhr.com",
                    Email = "ahmet.sarikaya@easyhr.com",
                    EmailConfirmed = true,
                    Ad = "Ahmet",
                    Soyad = "Sarıkaya",
                    DogumTarihi = new DateTime(1996, 01, 01),
                    Adres = "Burç mah. 712.cad. No:7/21 Yenimahalle/Ankara",
                    Telefon = 53122228514,
                    IseGirisTarihi = new DateTime(2022, 08, 01),
                    TcNo = "40663003338",
                    FotografAdi = "ahmet.jpg",
                    Maas = 10000,
                    Cinsiyet = CinsiyetEnum.Erkek,
                    Unvan = UnvanEnum.Calisan,
                    KanGrubu = KanGrubuEnum.APozitif,
                    MedeniHali = MedeniHalEnum.Bekar,
                    MeslekId = 1,
                    SirketId = 1,
                };

                await userManager.CreateAsync(admin, "Ankara1.");
                await userManager.AddToRoleAsync(admin, "Admin");

                await userManager.CreateAsync(yonetici, "Ankara1.");
                await userManager.AddToRoleAsync(yonetici, "Yonetici");

                await userManager.CreateAsync(personel, "Ankara1.");
                await userManager.AddToRoleAsync(personel, "Personel");
            }
        }

        public static async Task<IHost> SeedDbAsync(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                await SeedAsync(roleManager, userManager);
            }
            return host;
        }
    }
}