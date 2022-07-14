﻿// <auto-generated />
using System;
using EasyHR.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EasyHR.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220616062252_11th")]
    partial class _11th
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<int>("PersonelId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SonuclanmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TalepTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PersonelId");

                    b.ToTable("AvansTalepleri");
                });

            modelBuilder.Entity("EasyHR.Models.HarcamaOnayTalep", b =>
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

                    b.Property<decimal>("HarcamaTutari")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PersonelId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SonucTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TalepTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PersonelId");

                    b.ToTable("HarcamaOnayTalep");
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

                    b.Property<int>("PersonelId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SonuclanmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TalepTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PersonelId");

                    b.ToTable("IzinTalep");
                });

            modelBuilder.Entity("EasyHR.Models.Meslek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MeslekAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeslekKodu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Meslekler");
                });

            modelBuilder.Entity("EasyHR.Models.Personel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotografAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IseGirisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("IstenCikisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("KanGrubu")
                        .HasColumnType("int");

                    b.Property<int>("KanGrubuId")
                        .HasColumnType("int");

                    b.Property<decimal>("Maas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MaksAvansHakki")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MedeniHali")
                        .HasColumnType("int");

                    b.Property<int>("MedeniHaliId")
                        .HasColumnType("int");

                    b.Property<string>("Meslek")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MeslekId")
                        .HasColumnType("int");

                    b.Property<decimal>("MinAvansHakki")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sirket")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SirketYoneticisiId")
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

                    b.Property<int>("Unvan")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MeslekId");

                    b.HasIndex("SirketYoneticisiId");

                    b.ToTable("Personeller");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Personel");
                });

            modelBuilder.Entity("EasyHR.Models.SirketYoneticisi", b =>
                {
                    b.HasBaseType("EasyHR.Models.Personel");

                    b.Property<string>("Parola")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("SirketYoneticisi");
                });

            modelBuilder.Entity("EasyHR.Models.AvansTalep", b =>
                {
                    b.HasOne("EasyHR.Models.Personel", "Personel")
                        .WithMany("AvansTalepleri")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("EasyHR.Models.HarcamaOnayTalep", b =>
                {
                    b.HasOne("EasyHR.Models.Personel", "Personel")
                        .WithMany("HarcamaOnayTalepleri")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("EasyHR.Models.IzinTalep", b =>
                {
                    b.HasOne("EasyHR.Models.Personel", "Personel")
                        .WithMany("IzinTalepleri")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("EasyHR.Models.Personel", b =>
                {
                    b.HasOne("EasyHR.Models.Meslek", null)
                        .WithMany("Personel")
                        .HasForeignKey("MeslekId");

                    b.HasOne("EasyHR.Models.SirketYoneticisi", null)
                        .WithMany("Personeller")
                        .HasForeignKey("SirketYoneticisiId");
                });

            modelBuilder.Entity("EasyHR.Models.Meslek", b =>
                {
                    b.Navigation("Personel");
                });

            modelBuilder.Entity("EasyHR.Models.Personel", b =>
                {
                    b.Navigation("AvansTalepleri");

                    b.Navigation("HarcamaOnayTalepleri");

                    b.Navigation("IzinTalepleri");
                });

            modelBuilder.Entity("EasyHR.Models.SirketYoneticisi", b =>
                {
                    b.Navigation("Personeller");
                });
#pragma warning restore 612, 618
        }
    }
}
