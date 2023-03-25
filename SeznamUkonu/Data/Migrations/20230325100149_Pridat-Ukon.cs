using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeznamUkonu.Data.Migrations
{
    public partial class PridatUkon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeznamCinnosti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kdy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JmenoCinnosti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Podrobnosti = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeznamCinnosti", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeznamCinnosti");
        }
    }
}
