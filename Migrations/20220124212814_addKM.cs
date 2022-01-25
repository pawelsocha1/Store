using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class addKM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Marka",
                table: "Products",
                newName: "MarkaId");

            migrationBuilder.RenameColumn(
                name: "Kategoria",
                table: "Products",
                newName: "KategoriaId");

            migrationBuilder.CreateTable(
                name: "Kategoria",
                columns: table => new
                {
                    KategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaKategorii = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoria", x => x.KategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Marka",
                columns: table => new
                {
                    MarkaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaMarki = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marka", x => x.MarkaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_KategoriaId",
                table: "Products",
                column: "KategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MarkaId",
                table: "Products",
                column: "MarkaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Kategoria_KategoriaId",
                table: "Products",
                column: "KategoriaId",
                principalTable: "Kategoria",
                principalColumn: "KategoriaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Marka_MarkaId",
                table: "Products",
                column: "MarkaId",
                principalTable: "Marka",
                principalColumn: "MarkaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Kategoria_KategoriaId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Marka_MarkaId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Kategoria");

            migrationBuilder.DropTable(
                name: "Marka");

            migrationBuilder.DropIndex(
                name: "IX_Products_KategoriaId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MarkaId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "MarkaId",
                table: "Products",
                newName: "Marka");

            migrationBuilder.RenameColumn(
                name: "KategoriaId",
                table: "Products",
                newName: "Kategoria");
        }
    }
}
