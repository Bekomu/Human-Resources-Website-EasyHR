using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyHR.Data.Migrations
{
    public partial class qweqweqweqweqwe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SonKullanmaTarihi",
                table: "Kartlar");

            migrationBuilder.AlterColumn<string>(
                name: "CVC2",
                table: "Kartlar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ay",
                table: "Kartlar");

            migrationBuilder.DropColumn(
                name: "Yil",
                table: "Kartlar");

            migrationBuilder.AlterColumn<string>(
                name: "CVC2",
                table: "Kartlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SonKullanmaTarihi",
                table: "Kartlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
