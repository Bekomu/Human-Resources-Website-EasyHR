using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyHR.Data.Migrations
{
    public partial class cuzdanSirket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToplamBakiyeEUR",
                table: "Cuzdanlar");

            migrationBuilder.DropColumn(
                name: "ToplamBakiyeTRY",
                table: "Cuzdanlar");

            migrationBuilder.RenameColumn(
                name: "ToplamBakiyeUSD",
                table: "Cuzdanlar",
                newName: "ToplamBakiye");

            migrationBuilder.AddColumn<int>(
                name: "CuzdanId",
                table: "Sirketler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sirketler_CuzdanId",
                table: "Sirketler",
                column: "CuzdanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sirketler_Cuzdanlar_CuzdanId",
                table: "Sirketler",
                column: "CuzdanId",
                principalTable: "Cuzdanlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sirketler_Cuzdanlar_CuzdanId",
                table: "Sirketler");

            migrationBuilder.DropIndex(
                name: "IX_Sirketler_CuzdanId",
                table: "Sirketler");

            migrationBuilder.DropColumn(
                name: "CuzdanId",
                table: "Sirketler");

            migrationBuilder.RenameColumn(
                name: "ToplamBakiye",
                table: "Cuzdanlar",
                newName: "ToplamBakiyeUSD");

            migrationBuilder.AddColumn<decimal>(
                name: "ToplamBakiyeEUR",
                table: "Cuzdanlar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ToplamBakiyeTRY",
                table: "Cuzdanlar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
