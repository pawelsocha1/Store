using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class size : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoriesCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoriesCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoriesCategoryId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Products",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesCategoryId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesCategoryId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoriesCategoryId",
                table: "Products",
                column: "CategoriesCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoriesCategoryId",
                table: "Products",
                column: "CategoriesCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
