using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyHR.Data.Migrations
{
    public partial class Fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvansTalep_Personeller_PersonelId",
                table: "AvansTalep");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AvansTalep",
                table: "AvansTalep");

            migrationBuilder.RenameTable(
                name: "AvansTalep",
                newName: "AvansTalepleri");

            migrationBuilder.RenameIndex(
                name: "IX_AvansTalep_PersonelId",
                table: "AvansTalepleri",
                newName: "IX_AvansTalepleri_PersonelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AvansTalepleri",
                table: "AvansTalepleri",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AvansTalepleri_Personeller_PersonelId",
                table: "AvansTalepleri",
                column: "PersonelId",
                principalTable: "Personeller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvansTalepleri_Personeller_PersonelId",
                table: "AvansTalepleri");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AvansTalepleri",
                table: "AvansTalepleri");

            migrationBuilder.RenameTable(
                name: "AvansTalepleri",
                newName: "AvansTalep");

            migrationBuilder.RenameIndex(
                name: "IX_AvansTalepleri_PersonelId",
                table: "AvansTalep",
                newName: "IX_AvansTalep_PersonelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AvansTalep",
                table: "AvansTalep",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AvansTalep_Personeller_PersonelId",
                table: "AvansTalep",
                column: "PersonelId",
                principalTable: "Personeller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
