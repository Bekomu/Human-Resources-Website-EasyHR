using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyHR.Data.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaketId",
                table: "Sirketler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cuzdanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToplamBakiyeTRY = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToplamBakiyeUSD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToplamBakiyeEUR = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SirketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuzdanlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuzdanlar_Sirketler_SirketId",
                        column: x => x.SirketId,
                        principalTable: "Sirketler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paketler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ParaBirimi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciSayisi = table.Column<int>(type: "int", nullable: false),
                    YayimlanmaBaslangic = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YayimlanmaBitis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaketSatistaMi = table.Column<int>(type: "int", nullable: false),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KullanilmaSuresi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaketFotografi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paketler", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sirketler_PaketId",
                table: "Sirketler",
                column: "PaketId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuzdanlar_SirketId",
                table: "Cuzdanlar",
                column: "SirketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sirketler_Paketler_PaketId",
                table: "Sirketler",
                column: "PaketId",
                principalTable: "Paketler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sirketler_Paketler_PaketId",
                table: "Sirketler");

            migrationBuilder.DropTable(
                name: "Cuzdanlar");

            migrationBuilder.DropTable(
                name: "Paketler");

            migrationBuilder.DropIndex(
                name: "IX_Sirketler_PaketId",
                table: "Sirketler");

            migrationBuilder.DropColumn(
                name: "PaketId",
                table: "Sirketler");
        }
    }
}
