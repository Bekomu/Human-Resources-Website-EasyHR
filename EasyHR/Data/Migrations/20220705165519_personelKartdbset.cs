using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyHR.Data.Migrations
{
    public partial class personelKartdbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kart_AspNetUsers_PersonelId",
                table: "Kart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kart",
                table: "Kart");

            migrationBuilder.RenameTable(
                name: "Kart",
                newName: "Kartlar");

            migrationBuilder.RenameIndex(
                name: "IX_Kart_PersonelId",
                table: "Kartlar",
                newName: "IX_Kartlar_PersonelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kartlar",
                table: "Kartlar",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kartlar_AspNetUsers_PersonelId",
                table: "Kartlar",
                column: "PersonelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kartlar_AspNetUsers_PersonelId",
                table: "Kartlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kartlar",
                table: "Kartlar");

            migrationBuilder.RenameTable(
                name: "Kartlar",
                newName: "Kart");

            migrationBuilder.RenameIndex(
                name: "IX_Kartlar_PersonelId",
                table: "Kart",
                newName: "IX_Kart_PersonelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kart",
                table: "Kart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kart_AspNetUsers_PersonelId",
                table: "Kart",
                column: "PersonelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
