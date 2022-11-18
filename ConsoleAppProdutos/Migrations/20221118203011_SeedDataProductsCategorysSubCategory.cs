using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleAppProdutos.Migrations
{
    public partial class SeedDataProductsCategorysSubCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Bebidas ....", "Bebidas" });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Comidas ....", "Comida" });

            migrationBuilder.InsertData(
                table: "SubCategorys",
                columns: new[] { "Id", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Refrigentes ....", "Refrigentes" },
                    { 2, 1, "Aguas ....", "Aguas" },
                    { 3, 2, "Porco ....", "Porco" },
                    { 4, 2, "Frango ....", "Frango" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DateRegist", "Description", "Name", "Price", "Stock", "SubCategoryId" },
                values: new object[,]
                {
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sumol Ananas ....", "Sumol", 0.0, false, 1 },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agua Frize ....", "Agua Frize", 0.0, false, 2 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bifes... ....", "Bifes", 0.0, false, 4 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Costelas... ....", "Costelas", 0.0, false, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SubCategorys");

            migrationBuilder.DropTable(
                name: "Categorys");
        }
    }
}
