using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyHR.Data.Migrations
{
    public partial class personelKart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SahipAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SahipSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SonKullanmaTarihi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVC2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonelId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kart_AspNetUsers_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kart_PersonelId",
                table: "Kart",
                column: "PersonelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kart");
        }
    }
}
