using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyHR.Data.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TelefonNo",
                table: "Sirketler",
                newName: "SirketEmail");

            migrationBuilder.AlterColumn<string>(
                name: "SirketAdi",
                table: "Sirketler",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DosyaAdi",
                table: "Sirketler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "MersisNo",
                table: "Sirketler",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Sektor",
                table: "Sirketler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SirketAdres",
                table: "Sirketler",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "SirketKurulusTarihi",
            //    table: "Sirketler",
            //    type: "datetime2",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "SirketTelefonNo",
                table: "Sirketler",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "SirketTuru",
                table: "Sirketler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "SirketUyeOlmaTarihi",
            //    table: "Sirketler",
            //    type: "datetime2",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SirketWebSitesi",
                table: "Sirketler",
                type: "nvarchar(253)",
                maxLength: 253,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VergiDairesi",
                table: "Sirketler",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "VergiNo",
                table: "Sirketler",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DosyaAdi",
                table: "Sirketler");

            migrationBuilder.DropColumn(
                name: "MersisNo",
                table: "Sirketler");

            migrationBuilder.DropColumn(
                name: "Sektor",
                table: "Sirketler");

            migrationBuilder.DropColumn(
                name: "SirketAdres",
                table: "Sirketler");

            //migrationBuilder.DropColumn(
            //    name: "SirketKurulusTarihi",
            //    table: "Sirketler");

            migrationBuilder.DropColumn(
                name: "SirketTelefonNo",
                table: "Sirketler");

            migrationBuilder.DropColumn(
                name: "SirketTuru",
                table: "Sirketler");

            //migrationBuilder.DropColumn(
            //    name: "SirketUyeOlmaTarihi",
            //    table: "Sirketler");

            migrationBuilder.DropColumn(
                name: "SirketWebSitesi",
                table: "Sirketler");

            migrationBuilder.DropColumn(
                name: "VergiDairesi",
                table: "Sirketler");

            migrationBuilder.DropColumn(
                name: "VergiNo",
                table: "Sirketler");

            migrationBuilder.RenameColumn(
                name: "SirketEmail",
                table: "Sirketler",
                newName: "TelefonNo");

            migrationBuilder.AlterColumn<string>(
                name: "SirketAdi",
                table: "Sirketler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);
        }
    }
}
