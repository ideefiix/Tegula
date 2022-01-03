using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class fk2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tile_Player_ownerName",
                table: "Tile");

            migrationBuilder.DropIndex(
                name: "IX_Tile_ownerName",
                table: "Tile");

            migrationBuilder.DropColumn(
                name: "ownerName",
                table: "Tile");

            migrationBuilder.AddColumn<string>(
                name: "ownerId",
                table: "Tile",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Player",
                column: "Name",
                value: "Larsson");

            migrationBuilder.InsertData(
                table: "Tile",
                columns: new[] { "Id", "ownerId" },
                values: new object[] { 1, "Larsson" });

            migrationBuilder.CreateIndex(
                name: "IX_Tile_ownerId",
                table: "Tile",
                column: "ownerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tile_Player_ownerId",
                table: "Tile",
                column: "ownerId",
                principalTable: "Player",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tile_Player_ownerId",
                table: "Tile");

            migrationBuilder.DropIndex(
                name: "IX_Tile_ownerId",
                table: "Tile");

            migrationBuilder.DeleteData(
                table: "Tile",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "Name",
                keyValue: "Larsson");

            migrationBuilder.DropColumn(
                name: "ownerId",
                table: "Tile");

            migrationBuilder.AddColumn<string>(
                name: "ownerName",
                table: "Tile",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tile_ownerName",
                table: "Tile",
                column: "ownerName");

            migrationBuilder.AddForeignKey(
                name: "FK_Tile_Player_ownerName",
                table: "Tile",
                column: "ownerName",
                principalTable: "Player",
                principalColumn: "Name");
        }
    }
}
