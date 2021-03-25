using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiction.Migrations
{
    public partial class Addstories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Adventure Time" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Futurama" });

            migrationBuilder.InsertData(
                table: "Stories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "LOTR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stories");
        }
    }
}
