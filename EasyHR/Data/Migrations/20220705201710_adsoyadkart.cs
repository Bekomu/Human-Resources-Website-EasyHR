using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyHR.Data.Migrations
{
    public partial class adsoyadkart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SahipAdi",
                table: "Kartlar");

            migrationBuilder.RenameColumn(
                name: "SahipSoyadi",
                table: "Kartlar",
                newName: "AdSoyad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdSoyad",
                table: "Kartlar",
                newName: "SahipSoyadi");

            migrationBuilder.AddColumn<string>(
                name: "SahipAdi",
                table: "Kartlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
