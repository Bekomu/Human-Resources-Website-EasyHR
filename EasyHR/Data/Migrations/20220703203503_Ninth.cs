using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyHR.Data.Migrations
{
    public partial class Ninth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KullanilmaSuresi",
                table: "Paketler");

            migrationBuilder.RenameColumn(
                name: "YayimlanmaBitis",
                table: "Paketler",
                newName: "YayimlanmaTarihi");

            migrationBuilder.RenameColumn(
                name: "YayimlanmaBaslangic",
                table: "Paketler",
                newName: "YayimdanAlmaTarihi");

            migrationBuilder.RenameColumn(
                name: "PaketSatistaMi",
                table: "Paketler",
                newName: "KullanimSuresiGun");

            migrationBuilder.RenameColumn(
                name: "PaketFotografi",
                table: "Paketler",
                newName: "FotografAdi");

            migrationBuilder.AddColumn<bool>(
                name: "SatistaMi",
                table: "Paketler",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SatistaMi",
                table: "Paketler");

            migrationBuilder.RenameColumn(
                name: "YayimlanmaTarihi",
                table: "Paketler",
                newName: "YayimlanmaBitis");

            migrationBuilder.RenameColumn(
                name: "YayimdanAlmaTarihi",
                table: "Paketler",
                newName: "YayimlanmaBaslangic");

            migrationBuilder.RenameColumn(
                name: "KullanimSuresiGun",
                table: "Paketler",
                newName: "PaketSatistaMi");

            migrationBuilder.RenameColumn(
                name: "FotografAdi",
                table: "Paketler",
                newName: "PaketFotografi");

            migrationBuilder.AddColumn<DateTime>(
                name: "KullanilmaSuresi",
                table: "Paketler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
