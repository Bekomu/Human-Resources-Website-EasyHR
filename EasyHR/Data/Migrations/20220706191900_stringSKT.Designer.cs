﻿// <auto-generated />
using System;
using EasyHR.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasyHR.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220706191900_stringSKT")]
    partial class stringSKT
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EasyHR.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Cinsiyet")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FotografAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IseGirisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("IstenCikisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("IzinGuncellemeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("KanGrubu")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal>("Maas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MaksAvansHakki")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MedeniHali")
                        .HasColumnType("int");

                    b.Property<int>("MeslekId")
                        .HasColumnType("int");

                    b.Property<decimal>("MinAvansHakki")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SirketId")
                        .HasColumnType("int");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("TcNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<long>("Telefon")
                        .HasColumnType("bigint");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("Unvan")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("YillikIzinGunSayisi")
                        .HasColumnType("int");

                    b.Property<string>("YoneticiId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MeslekId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("SirketId");

                    b.HasIndex("YoneticiId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("EasyHR.Models.AvansTalep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasMaxLength(140)
                        .HasColumnType("nvarchar(140)");

                    b.Property<int>("AvansOnayDurumu")
                        .HasColumnType("int");

                    b.Property<decimal>("AvansTutari")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PersonelId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("SonuclanmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TalepTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PersonelId");

                    b.ToTable("AvansTalepleri");
                });

            modelBuilder.Entity("EasyHR.Models.Bakiye", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ParaBirimi")
                        .HasColumnType("int");

                    b.Property<decimal>("Tutar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("YukeleyenSirketAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YukleyenAdSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bakiyeler");
                });

            modelBuilder.Entity("EasyHR.Models.Cuzdan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SirketId")
                        .HasColumnType("int");

                    b.Property<decimal>("ToplamBakiyeEUR")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ToplamBakiyeTRY")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ToplamBakiyeUSD")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("SirketId");

                    b.ToTable("Cuzdanlar");
                });

            modelBuilder.Entity("EasyHR.Models.HarcamaTalep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasMaxLength(140)
                        .HasColumnType("nvarchar(140)");

                    b.Property<string>("DosyaAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HarcamaOnayDurumu")
                        .HasColumnType("int");

                    b.Property<int>("HarcamaTuru")
                        .HasColumnType("int");

                    b.Property<decimal>("HarcamaTutari")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PersonelId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("SonuclanmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TalepTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PersonelId");

                    b.ToTable("HarcamaTalepleri");
                });

            modelBuilder.Entity("EasyHR.Models.IzinTalep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("IzinBaslangicTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("IzinBitisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("IzinGunSayisi")
                        .HasColumnType("int");

                    b.Property<int>("IzinOnayDurumu")
                        .HasColumnType("int");

                    b.Property<int>("IzinTuru")
                        .HasColumnType("int");

                    b.Property<string>("PersonelId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("SonuclanmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TalepTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PersonelId");

                    b.ToTable("IzinTalepleri");
                });

            modelBuilder.Entity("EasyHR.Models.Kart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdSoyad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CVC2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KartIsmi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KartNumarasi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Limit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SKT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SirketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SirketId");

                    b.ToTable("Kartlar");
                });

            modelBuilder.Entity("EasyHR.Models.Meslek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MeslekAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MeslekKodu")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.HasKey("Id");

                    b.ToTable("Meslekler");
                });

            modelBuilder.Entity("EasyHR.Models.Paket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FotografAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KullaniciSayisi")
                        .HasColumnType("int");

                    b.Property<int>("KullanimSuresiGun")
                        .HasColumnType("int");

                    b.Property<DateTime>("OlusturulmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("ParaBirimiEnum")
                        .HasColumnType("int");

                    b.Property<bool>("SatistaMi")
                        .HasColumnType("bit");

                    b.Property<decimal>("Tutar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("YayimdanAlmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("YayimlanmaTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Paketler");
                });

            modelBuilder.Entity("EasyHR.Models.Sirket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DosyaAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("MersisNo")
                        .HasColumnType("bigint");

                    b.Property<int?>("PaketId")
                        .HasColumnType("int");

                    b.Property<int>("Sektor")
                        .HasColumnType("int");

                    b.Property<string>("SirketAdi")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("SirketAdres")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SirketEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SirketInfo")
                        .IsRequired()
                        .HasMaxLength(140)
                        .HasColumnType("nvarchar(140)");

                    b.Property<DateTime>("SirketKurulusTarihi")
                        .HasColumnType("datetime2");

                    b.Property<long>("SirketTelefonNo")
                        .HasColumnType("bigint");

                    b.Property<int>("SirketTuru")
                        .HasColumnType("int");

                    b.Property<DateTime>("SirketUyeOlmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("SirketWebSitesi")
                        .IsRequired()
                        .HasMaxLength(253)
                        .HasColumnType("nvarchar(253)");

                    b.Property<string>("VergiDairesi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("VergiNo")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PaketId");

                    b.ToTable("Sirketler");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EasyHR.Data.ApplicationUser", b =>
                {
                    b.HasOne("EasyHR.Models.Meslek", "Meslek")
                        .WithMany("Personel")
                        .HasForeignKey("MeslekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyHR.Models.Sirket", "Sirket")
                        .WithMany("Personeller")
                        .HasForeignKey("SirketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyHR.Data.ApplicationUser", "Yonetici")
                        .WithMany()
                        .HasForeignKey("YoneticiId");

                    b.Navigation("Meslek");

                    b.Navigation("Sirket");

                    b.Navigation("Yonetici");
                });

            modelBuilder.Entity("EasyHR.Models.AvansTalep", b =>
                {
                    b.HasOne("EasyHR.Data.ApplicationUser", "Personel")
                        .WithMany("AvansTalepleri")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("EasyHR.Models.Cuzdan", b =>
                {
                    b.HasOne("EasyHR.Models.Sirket", "Sirket")
                        .WithMany()
                        .HasForeignKey("SirketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sirket");
                });

            modelBuilder.Entity("EasyHR.Models.HarcamaTalep", b =>
                {
                    b.HasOne("EasyHR.Data.ApplicationUser", "Personel")
                        .WithMany("HarcamaTalepleri")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("EasyHR.Models.IzinTalep", b =>
                {
                    b.HasOne("EasyHR.Data.ApplicationUser", "Personel")
                        .WithMany("IzinTalepleri")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("EasyHR.Models.Kart", b =>
                {
                    b.HasOne("EasyHR.Models.Sirket", "Sirket")
                        .WithMany("Kartlar")
                        .HasForeignKey("SirketId");

                    b.Navigation("Sirket");
                });

            modelBuilder.Entity("EasyHR.Models.Sirket", b =>
                {
                    b.HasOne("EasyHR.Models.Paket", "Paket")
                        .WithMany("Sirketler")
                        .HasForeignKey("PaketId");

                    b.Navigation("Paket");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EasyHR.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EasyHR.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyHR.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EasyHR.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EasyHR.Data.ApplicationUser", b =>
                {
                    b.Navigation("AvansTalepleri");

                    b.Navigation("HarcamaTalepleri");

                    b.Navigation("IzinTalepleri");
                });

            modelBuilder.Entity("EasyHR.Models.Meslek", b =>
                {
                    b.Navigation("Personel");
                });

            modelBuilder.Entity("EasyHR.Models.Paket", b =>
                {
                    b.Navigation("Sirketler");
                });

            modelBuilder.Entity("EasyHR.Models.Sirket", b =>
                {
                    b.Navigation("Kartlar");

                    b.Navigation("Personeller");
                });
#pragma warning restore 612, 618
        }
    }
}
