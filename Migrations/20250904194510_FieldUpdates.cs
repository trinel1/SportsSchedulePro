using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsScheduleProLibrary.Migrations
{
    public partial class FieldUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DailyGamesPerFieldSaturday",
                table: "Field",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DailyGamesPerFieldSunday",
                table: "Field",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DailyGamesPerFieldWeekday",
                table: "Field",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EarliestGameTimeHourSaturday",
                table: "Field",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EarliestGameTimeHourSunday",
                table: "Field",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EarliestGameTimeHourWeekday",
                table: "Field",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EarliestGameTimeMinuteSaturday",
                table: "Field",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EarliestGameTimeMinuteSunday",
                table: "Field",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EarliestGameTimeMinuteWeekday",
                table: "Field",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FieldGameLengthWindow",
                table: "Field",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Alert",
                keyColumn: "AlertId",
                keyValue: 1,
                column: "AlertDate",
                value: new DateTime(2025, 9, 4, 14, 45, 9, 664, DateTimeKind.Local).AddTicks(5645));

            migrationBuilder.UpdateData(
                table: "Field",
                keyColumn: "FieldId",
                keyValue: 1,
                columns: new[] { "DailyGamesPerFieldSaturday", "DailyGamesPerFieldSunday", "DailyGamesPerFieldWeekday", "EarliestGameTimeHourSaturday", "EarliestGameTimeHourSunday", "EarliestGameTimeHourWeekday", "EarliestGameTimeMinuteWeekday", "FieldGameLengthWindow" },
                values: new object[] { 3, 1, 1, 8, 13, 17, 45, 90 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyGamesPerFieldSaturday",
                table: "Field");

            migrationBuilder.DropColumn(
                name: "DailyGamesPerFieldSunday",
                table: "Field");

            migrationBuilder.DropColumn(
                name: "DailyGamesPerFieldWeekday",
                table: "Field");

            migrationBuilder.DropColumn(
                name: "EarliestGameTimeHourSaturday",
                table: "Field");

            migrationBuilder.DropColumn(
                name: "EarliestGameTimeHourSunday",
                table: "Field");

            migrationBuilder.DropColumn(
                name: "EarliestGameTimeHourWeekday",
                table: "Field");

            migrationBuilder.DropColumn(
                name: "EarliestGameTimeMinuteSaturday",
                table: "Field");

            migrationBuilder.DropColumn(
                name: "EarliestGameTimeMinuteSunday",
                table: "Field");

            migrationBuilder.DropColumn(
                name: "EarliestGameTimeMinuteWeekday",
                table: "Field");

            migrationBuilder.DropColumn(
                name: "FieldGameLengthWindow",
                table: "Field");

            migrationBuilder.UpdateData(
                table: "Alert",
                keyColumn: "AlertId",
                keyValue: 1,
                column: "AlertDate",
                value: new DateTime(2025, 2, 17, 20, 43, 37, 31, DateTimeKind.Local).AddTicks(9749));
        }
    }
}
