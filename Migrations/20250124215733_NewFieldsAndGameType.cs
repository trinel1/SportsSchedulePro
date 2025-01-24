using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsScheduleProLibrary.Migrations
{
    public partial class NewFieldsAndGameType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DailyGamesPerFieldSaturday",
                table: "League",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DailyGamesPerFieldSunday",
                table: "League",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DailyGamesPerFieldWeekday",
                table: "League",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EarliestGameTimeHourSaturday",
                table: "League",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EarliestGameTimeHourSunday",
                table: "League",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EarliestGameTimeHourWeekday",
                table: "League",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EarliestGameTimeMinuteSaturday",
                table: "League",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EarliestGameTimeMinuteSunday",
                table: "League",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EarliestGameTimeMinuteWeekday",
                table: "League",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GameLengthWindow",
                table: "League",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayEachTimeCount",
                table: "League",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    HomeTeamId = table.Column<int>(type: "INTEGER", nullable: false),
                    AwayTeamId = table.Column<int>(type: "INTEGER", nullable: false),
                    FieldId = table.Column<int>(type: "INTEGER", nullable: true),
                    ChosenScheduleTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LeagueId = table.Column<int>(type: "INTEGER", nullable: true),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Game_Field_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Field",
                        principalColumn: "FieldId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_League_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "League",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Alert",
                keyColumn: "AlertId",
                keyValue: 1,
                column: "AlertDate",
                value: new DateTime(2025, 1, 24, 15, 57, 32, 980, DateTimeKind.Local).AddTicks(1177));

            migrationBuilder.UpdateData(
                table: "League",
                keyColumn: "LeagueId",
                keyValue: 1,
                columns: new[] { "DailyGamesPerFieldSaturday", "DailyGamesPerFieldSunday", "DailyGamesPerFieldWeekday", "EarliestGameTimeHourSaturday", "EarliestGameTimeHourSunday", "EarliestGameTimeHourWeekday", "EarliestGameTimeMinuteWeekday", "GameLengthWindow", "PlayEachTimeCount" },
                values: new object[] { 3, 1, 1, 9, 13, 5, 45, 90, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Game_FieldId",
                table: "Game",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_LeagueId",
                table: "Game",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_TeamId",
                table: "Game",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropColumn(
                name: "DailyGamesPerFieldSaturday",
                table: "League");

            migrationBuilder.DropColumn(
                name: "DailyGamesPerFieldSunday",
                table: "League");

            migrationBuilder.DropColumn(
                name: "DailyGamesPerFieldWeekday",
                table: "League");

            migrationBuilder.DropColumn(
                name: "EarliestGameTimeHourSaturday",
                table: "League");

            migrationBuilder.DropColumn(
                name: "EarliestGameTimeHourSunday",
                table: "League");

            migrationBuilder.DropColumn(
                name: "EarliestGameTimeHourWeekday",
                table: "League");

            migrationBuilder.DropColumn(
                name: "EarliestGameTimeMinuteSaturday",
                table: "League");

            migrationBuilder.DropColumn(
                name: "EarliestGameTimeMinuteSunday",
                table: "League");

            migrationBuilder.DropColumn(
                name: "EarliestGameTimeMinuteWeekday",
                table: "League");

            migrationBuilder.DropColumn(
                name: "GameLengthWindow",
                table: "League");

            migrationBuilder.DropColumn(
                name: "PlayEachTimeCount",
                table: "League");

            migrationBuilder.UpdateData(
                table: "Alert",
                keyColumn: "AlertId",
                keyValue: 1,
                column: "AlertDate",
                value: new DateTime(2025, 1, 24, 13, 48, 43, 879, DateTimeKind.Local).AddTicks(857));
        }
    }
}
