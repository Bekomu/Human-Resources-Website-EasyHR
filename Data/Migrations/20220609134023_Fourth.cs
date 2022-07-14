using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyHR.Data.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avanslar");

            migrationBuilder.CreateTable(
                name: "AvansTalep",
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
                    table.PrimaryKey("PK_AvansTalep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvansTalep_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvansTalep_PersonelId",
                table: "AvansTalep",
                column: "PersonelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvansTalep");

            migrationBuilder.CreateTable(
                name: "Avanslar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: false),
                    AvansDurumu = table.Column<int>(type: "int", nullable: false),
                    AvansTutari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    SonuclanmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TalepTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avanslar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avanslar_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avanslar_PersonelId",
                table: "Avanslar",
                column: "PersonelId");
        }
    }
}
