using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyHR.Migrations
{
    public partial class twelveth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Sirketler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SirketAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SirketInfo = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sirketler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personeller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefon = table.Column<long>(type: "bigint", nullable: false),
                    IseGirisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IstenCikisTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TcNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    FotografAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Maas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinAvansHakki = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaksAvansHakki = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cinsiyet = table.Column<int>(type: "int", nullable: false),
                    Unvan = table.Column<int>(type: "int", nullable: false),
                    MedeniHaliId = table.Column<int>(type: "int", nullable: false),
                    MedeniHali = table.Column<int>(type: "int", nullable: false),
                    KanGrubuId = table.Column<int>(type: "int", nullable: false),
                    KanGrubu = table.Column<int>(type: "int", nullable: false),
                    Meslek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SirketId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeslekId = table.Column<int>(type: "int", nullable: true),
                    SirketYoneticisiId = table.Column<int>(type: "int", nullable: true),
                    Parola = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personeller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personeller_Meslekler_MeslekId",
                        column: x => x.MeslekId,
                        principalTable: "Meslekler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personeller_Personeller_SirketYoneticisiId",
                        column: x => x.SirketYoneticisiId,
                        principalTable: "Personeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personeller_Sirketler_SirketId",
                        column: x => x.SirketId,
                        principalTable: "Sirketler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvansTalepleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvansTutari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TalepTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvansOnayDurumu = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false),
                    SonuclanmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PersonelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvansTalepleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvansTalepleri_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IzinTalepleri",
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
                    table.PrimaryKey("PK_IzinTalepleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IzinTalepleri_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvansTalepleri_PersonelId",
                table: "AvansTalepleri",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_HarcamaOnayTalep_PersonelId",
                table: "HarcamaOnayTalep",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_IzinTalepleri_PersonelId",
                table: "IzinTalepleri",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_MeslekId",
                table: "Personeller",
                column: "MeslekId");

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_SirketId",
                table: "Personeller",
                column: "SirketId");

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_SirketYoneticisiId",
                table: "Personeller",
                column: "SirketYoneticisiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvansTalepleri");

            migrationBuilder.DropTable(
                name: "HarcamaOnayTalep");

            migrationBuilder.DropTable(
                name: "IzinTalepleri");

            migrationBuilder.DropTable(
                name: "Personeller");

            migrationBuilder.DropTable(
                name: "Meslekler");

            migrationBuilder.DropTable(
                name: "Sirketler");
        }
    }
}
