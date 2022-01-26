using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class ee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NazwaProduktu",
                table: "Issue",
                newName: "ProductName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Issue",
                newName: "NazwaProduktu");
        }
    }
}
