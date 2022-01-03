using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    public partial class fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Tile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ownerName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tile_Player_ownerName",
                        column: x => x.ownerName,
                        principalTable: "Player",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tile_ownerName",
                table: "Tile",
                column: "ownerName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tile");

            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
