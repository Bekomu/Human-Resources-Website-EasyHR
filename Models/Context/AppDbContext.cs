using Microsoft.EntityFrameworkCore;

namespace EasyHR.Models.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Personel> Personeller { get; set; }

        public DbSet<Sirket> Sirketler { get; set; }

        public DbSet<AvansTalep> AvansTalepleri { get; set; }

        public DbSet<Meslek> Meslekler { get; set; }

        public DbSet<SirketYoneticisi> SirketYoneticileri { get; set; }
    }
}
