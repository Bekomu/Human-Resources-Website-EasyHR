using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyHR.Data.Migrations
{
    public partial class paket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParaBirimi",
                table: "Paketler");

            migrationBuilder.AddColumn<int>(
                name: "ParaBirimiEnum",
                table: "Paketler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParaBirimiEnum",
                table: "Paketler");

            migrationBuilder.AddColumn<string>(
                name: "ParaBirimi",
                table: "Paketler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
