using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnEFRunRawQuery.Module.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AdultProducts",
                columns: new[] { "Id", "Name", "Price", "Stok" },
                values: new object[,]
                {
                    { 1, "Kaos Pevita", 50000.0, 51L },
                    { 2, "Kaos John Wick", 40000.0, 101L },
                    { 3, "Kaos Dwyne Johnson", 80000.0, 151L }
                });

            migrationBuilder.InsertData(
                table: "ChildProducts",
                columns: new[] { "Id", "Name", "Price", "Stok" },
                values: new object[,]
                {
                    { 1, "Kaos Spiderman", 50000.0, 5L },
                    { 2, "Kaos Superman", 40000.0, 10L },
                    { 3, "Kaos Iron Man", 80000.0, 15L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdultProducts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AdultProducts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AdultProducts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ChildProducts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ChildProducts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ChildProducts",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
