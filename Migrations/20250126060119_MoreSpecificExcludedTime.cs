using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsScheduleProLibrary.Migrations
{
    public partial class MoreSpecificExcludedTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExcludedTime",
                table: "ExcludedGameDate",
                newName: "ExcludedTimeStart");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExcludedTimeEnd",
                table: "ExcludedGameDate",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Alert",
                keyColumn: "AlertId",
                keyValue: 1,
                column: "AlertDate",
                value: new DateTime(2025, 1, 26, 0, 1, 18, 289, DateTimeKind.Local).AddTicks(3512));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExcludedTimeEnd",
                table: "ExcludedGameDate");

            migrationBuilder.RenameColumn(
                name: "ExcludedTimeStart",
                table: "ExcludedGameDate",
                newName: "ExcludedTime");

            migrationBuilder.UpdateData(
                table: "Alert",
                keyColumn: "AlertId",
                keyValue: 1,
                column: "AlertDate",
                value: new DateTime(2025, 1, 25, 23, 36, 39, 637, DateTimeKind.Local).AddTicks(3709));
        }
    }
}
