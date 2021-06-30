using Microsoft.EntityFrameworkCore.Migrations;

namespace Akij_Food_Crud_Operation_Api.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ColdDrinks",
                columns: new[] { "ColdDrinksId", "ColdDrinksName", "Quantity", "UnitPrice" },
                values: new object[] { 1, "Clemon", 450m, 20m });

            migrationBuilder.InsertData(
                table: "ColdDrinks",
                columns: new[] { "ColdDrinksId", "ColdDrinksName", "Quantity", "UnitPrice" },
                values: new object[] { 2, "Frutika", 500m, 25m });

            migrationBuilder.InsertData(
                table: "ColdDrinks",
                columns: new[] { "ColdDrinksId", "ColdDrinksName", "Quantity", "UnitPrice" },
                values: new object[] { 3, "Speed", 600m, 30m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ColdDrinks",
                keyColumn: "ColdDrinksId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ColdDrinks",
                keyColumn: "ColdDrinksId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ColdDrinks",
                keyColumn: "ColdDrinksId",
                keyValue: 3);
        }
    }
}
