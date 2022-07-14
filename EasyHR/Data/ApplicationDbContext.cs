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
    }
}

