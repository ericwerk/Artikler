using Microsoft.EntityFrameworkCore.Migrations;

namespace Artikler.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artikler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Forfatter = table.Column<string>(nullable: true),
                    Overskrift = table.Column<string>(nullable: true),
                    Tekst = table.Column<string>(nullable: true),
                    Årstal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikler", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artikler");
        }
    }
}
