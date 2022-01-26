using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Migrations
{
    public partial class eh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Kategoria_KategoriaId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Marka_MarkaId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marka",
                table: "Marka");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kategoria",
                table: "Kategoria");

            migrationBuilder.RenameTable(
                name: "Marka",
                newName: "Brands");

            migrationBuilder.RenameTable(
                name: "Kategoria",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "MarkaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "KategoriaId");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_MarkaId",
                table: "Products",
                column: "MarkaId",
                principalTable: "Brands",
                principalColumn: "MarkaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_KategoriaId",
                table: "Products",
                column: "KategoriaId",
                principalTable: "Categories",
                principalColumn: "KategoriaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_MarkaId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_KategoriaId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Kategoria");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Marka");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kategoria",
                table: "Kategoria",
                column: "KategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marka",
                table: "Marka",
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
    }
}
