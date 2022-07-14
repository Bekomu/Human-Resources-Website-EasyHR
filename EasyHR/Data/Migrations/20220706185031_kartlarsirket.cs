using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyHR.Data.Migrations
{
    public partial class kartlarsirket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kartlar_AspNetUsers_PersonelId",
                table: "Kartlar");

            migrationBuilder.DropIndex(
                name: "IX_Kartlar_PersonelId",
                table: "Kartlar");

            migrationBuilder.DropColumn(
                name: "PersonelId",
                table: "Kartlar");

            migrationBuilder.AddColumn<int>(
                name: "SirketId",
                table: "Kartlar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kartlar_SirketId",
                table: "Kartlar",
                column: "SirketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kartlar_Sirketler_SirketId",
                table: "Kartlar",
                column: "SirketId",
                principalTable: "Sirketler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kartlar_Sirketler_SirketId",
                table: "Kartlar");

            migrationBuilder.DropIndex(
                name: "IX_Kartlar_SirketId",
                table: "Kartlar");

            migrationBuilder.DropColumn(
                name: "SirketId",
                table: "Kartlar");

            migrationBuilder.AddColumn<string>(
                name: "PersonelId",
                table: "Kartlar",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kartlar_PersonelId",
                table: "Kartlar",
                column: "PersonelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kartlar_AspNetUsers_PersonelId",
                table: "Kartlar",
                column: "PersonelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
