using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyHR.Data.Migrations
{
    public partial class stringSKT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ay",
                table: "Kartlar");

            migrationBuilder.DropColumn(
                name: "Yil",
                table: "Kartlar");

            migrationBuilder.AddColumn<string>(
                name: "SKT",
                table: "Kartlar",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SKT",
                table: "Kartlar");

            migrationBuilder.AddColumn<int>(
                name: "Ay",
                table: "Kartlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Yil",
                table: "Kartlar",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
