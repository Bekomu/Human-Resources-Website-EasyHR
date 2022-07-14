using EasyHR.Extensions;
using EasyHR.Models;
using EasyHR.Models.Context;
using EasyHR.Models.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                if (!db.Sirketler.Any())
                {
                    db.Sirketler.Add(new Sirket()
                    {
                        SirketAdi = "easyhr",
                        SirketInfo = "makes hr easier",
                        TelefonNo = "03123307856"
                    });
                    db.SaveChanges();
                }

                if (!db.Personeller.Any())
                {
                    db.Personeller.Add(new Personel("Ahmet", "Sarıkaya")
                    {
                        FotografAdi = "ahmet.jpg",
                        Unvan = UnvanEnum.Calisan,
                        DogumTarihi = new DateTime(1996, 08, 09),
                        Adres = "Kızılırmak Mah. 8.Cad. No:40/2 Çankaya",
                        Telefon = 5312228514,
                        IseGirisTarihi = DateTime.Now.AddMonths(-5),
                        TcNo = "40663003338",
                        Maas = 10000,
                        Meslek = "Software Developer",
                        SirketId = 1
                    });
                    db.SaveChanges();
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
