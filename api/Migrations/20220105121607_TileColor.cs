using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class TileColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "Tile",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Tile",
                keyColumn: "Id",
                keyValue: 1,
                column: "color",
                value: "#fcba03");

            migrationBuilder.UpdateData(
                table: "Tile",
                keyColumn: "Id",
                keyValue: 2,
                column: "color",
                value: "#fc4e03");

            migrationBuilder.UpdateData(
                table: "Tile",
                keyColumn: "Id",
                keyValue: 3,
                column: "color",
                value: "#035afc");

            migrationBuilder.UpdateData(
                table: "Tile",
                keyColumn: "Id",
                keyValue: 4,
                column: "color",
                value: "#c203fc");

            migrationBuilder.UpdateData(
                table: "Tile",
                keyColumn: "Id",
                keyValue: 5,
                column: "color",
                value: "#691c46");

            migrationBuilder.UpdateData(
                table: "Tile",
                keyColumn: "Id",
                keyValue: 6,
                column: "color",
                value: "#2f732f");

            migrationBuilder.UpdateData(
                table: "Tile",
                keyColumn: "Id",
                keyValue: 7,
                column: "color",
                value: "#5a947f");

            migrationBuilder.UpdateData(
                table: "Tile",
                keyColumn: "Id",
                keyValue: 8,
                column: "color",
                value: "#bf7ca1");

            migrationBuilder.UpdateData(
                table: "Tile",
                keyColumn: "Id",
                keyValue: 9,
                column: "color",
                value: "#de142c");

            migrationBuilder.UpdateData(
                table: "Tile",
                keyColumn: "Id",
                keyValue: 10,
                column: "color",
                value: "#665758");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "color",
                table: "Tile");
        }
    }
}
