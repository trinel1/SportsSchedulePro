using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsScheduleProLibrary.Migrations
{
    public partial class NumberOfGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GamesPerSeason",
                table: "League",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Alert",
                keyColumn: "AlertId",
                keyValue: 1,
                column: "AlertDate",
                value: new DateTime(2025, 2, 17, 20, 43, 37, 31, DateTimeKind.Local).AddTicks(9749));

            migrationBuilder.UpdateData(
                table: "League",
                keyColumn: "LeagueId",
                keyValue: 1,
                column: "GamesPerSeason",
                value: 8);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GamesPerSeason",
                table: "League");

            migrationBuilder.UpdateData(
                table: "Alert",
                keyColumn: "AlertId",
                keyValue: 1,
                column: "AlertDate",
                value: new DateTime(2025, 2, 17, 20, 41, 28, 724, DateTimeKind.Local).AddTicks(9819));
        }
    }
}
