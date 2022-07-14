using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyHR.Data.Migrations
{
    public partial class sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IseGiris",
                table: "Personeller");

            migrationBuilder.RenameColumn(
                name: "IstenCikis",
                table: "Personeller",
                newName: "IseGirisTarihi");

            migrationBuilder.AlterColumn<long>(
                name: "Telefon",
                table: "Personeller",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "IstenCikisTarihi",
                table: "Personeller",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IstenCikisTarihi",
                table: "Personeller");

            migrationBuilder.RenameColumn(
                name: "IseGirisTarihi",
                table: "Personeller",
                newName: "IstenCikis");

            migrationBuilder.AlterColumn<int>(
                name: "Telefon",
                table: "Personeller",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<DateTime>(
                name: "IseGiris",
                table: "Personeller",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
