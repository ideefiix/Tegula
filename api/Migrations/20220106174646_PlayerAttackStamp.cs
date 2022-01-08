using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class PlayerAttackStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "prevAttack",
                table: "Player",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Player",
                keyColumn: "Name",
                keyValue: "Larsson",
                column: "prevAttack",
                value: new DateTime(2022, 1, 6, 17, 46, 46, 803, DateTimeKind.Utc).AddTicks(1152));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "prevAttack",
                table: "Player");
        }
    }
}
