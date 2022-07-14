using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyHR.Data.Migrations
{
    public partial class _11th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Personeller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MeslekId",
                table: "Personeller",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parola",
                table: "Personeller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SirketYoneticisiId",
                table: "Personeller",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HarcamaOnayTalep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HarcamaTutari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false),
                    DosyaAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TalepTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SonucTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PersonelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HarcamaOnayTalep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HarcamaOnayTalep_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IzinTalep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IzinTuru = table.Column<int>(type: "int", nullable: false),
                    IzinBaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IzinBitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IzinGunSayisi = table.Column<int>(type: "int", nullable: false),
                    TalepTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SonuclanmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IzinOnayDurumu = table.Column<int>(type: "int", nullable: false),
                    PersonelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzinTalep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IzinTalep_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meslekler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeslekAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeslekKodu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meslekler", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_MeslekId",
                table: "Personeller",
                column: "MeslekId");

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_SirketYoneticisiId",
                table: "Personeller",
                column: "SirketYoneticisiId");

            migrationBuilder.CreateIndex(
                name: "IX_HarcamaOnayTalep_PersonelId",
                table: "HarcamaOnayTalep",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_IzinTalep_PersonelId",
                table: "IzinTalep",
                column: "PersonelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personeller_Meslekler_MeslekId",
                table: "Personeller",
                column: "MeslekId",
                principalTable: "Meslekler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personeller_Personeller_SirketYoneticisiId",
                table: "Personeller",
                column: "SirketYoneticisiId",
                principalTable: "Personeller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personeller_Meslekler_MeslekId",
                table: "Personeller");

            migrationBuilder.DropForeignKey(
                name: "FK_Personeller_Personeller_SirketYoneticisiId",
                table: "Personeller");

            migrationBuilder.DropTable(
                name: "HarcamaOnayTalep");

            migrationBuilder.DropTable(
                name: "IzinTalep");

            migrationBuilder.DropTable(
                name: "Meslekler");

            migrationBuilder.DropIndex(
                name: "IX_Personeller_MeslekId",
                table: "Personeller");

            migrationBuilder.DropIndex(
                name: "IX_Personeller_SirketYoneticisiId",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "MeslekId",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "Parola",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "SirketYoneticisiId",
                table: "Personeller");
        }
    }
}
