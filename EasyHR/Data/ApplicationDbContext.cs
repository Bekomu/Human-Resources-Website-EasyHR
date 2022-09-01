using EasyHR.Data;
using EasyHR.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyHR.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<HarcamaTalep> HarcamaTalepleri { get; set; }
        public DbSet<IzinTalep> IzinTalepleri { get; set; }
        public DbSet<Sirket> Sirketler { get; set; }
        public DbSet<Meslek> Meslekler { get; set; }
        public DbSet<AvansTalep> AvansTalepleri { get; set; }
        public DbSet<Paket> Paketler { get; set; }
        public DbSet<Cuzdan> Cuzdanlar { get; set; }
        public DbSet<Bakiye> Bakiyeler { get; set; }
        public DbSet<Kart> Kartlar { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Meslek[] meslekSeed = { new Meslek() { Id = 1, MeslekAdi = "Yazılım Mühendisi", MeslekKodu = "2512.01" } };

            builder.Entity<Meslek>().HasData(meslekSeed);

            Sirket[] sirketSeed = { new Sirket() { Id = 1, SirketAdi = "EasyHr", DosyaAdi = "easyhr.png", SirketKurulusTarihi = new DateTime(2022, 01, 17), VergiDairesi = "Çankaya Vergi Dairesi", VergiNo = 0123456789, MersisNo = 0123456789, SirketTuru = Models.Enums.SirketTuruEnum.Limited, Sektor = Models.Enums.SektorEnum.Teknoloji, SirketUyeOlmaTarihi = DateTime.Now, SirketEmail = "info@easyhr.com", SirketTelefonNo = 03120000000, SirketAdres = "Çankaya-Ankara", SirketInfo = " ", SirketWebSitesi = " " } };

            builder.Entity<Sirket>().HasData(sirketSeed);

            base.OnModelCreating(builder);
        }
    }
}

