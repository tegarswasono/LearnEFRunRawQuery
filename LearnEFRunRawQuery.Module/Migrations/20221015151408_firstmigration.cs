using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnEFRunRawQuery.Module.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdultProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stok = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdultProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChildProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stok = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildProducts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdultProducts_Id",
                table: "AdultProducts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChildProducts_Id",
                table: "ChildProducts",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdultProducts");

            migrationBuilder.DropTable(
                name: "ChildProducts");
        }
    }
}
