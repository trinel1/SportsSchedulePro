using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsScheduleProLibrary.Migrations
{
    public partial class ExcludeGameDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExcludedGameDate",
                columns: table => new
                {
                    ExcludedGameDateId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExcludedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExcludedTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcludedGameDate", x => x.ExcludedGameDateId);
                    table.ForeignKey(
                        name: "FK_ExcludedGameDate_Team_TeamId",
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
                value: new DateTime(2025, 1, 25, 23, 36, 39, 637, DateTimeKind.Local).AddTicks(3709));

            migrationBuilder.InsertData(
                table: "ExcludedGameDate",
                columns: new[] { "ExcludedGameDateId", "ExcludedDate", "ExcludedTime", "IsDeleted", "TeamId" },
                values: new object[] { 1, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null });

            migrationBuilder.UpdateData(
                table: "League",
                keyColumn: "LeagueId",
                keyValue: 1,
                column: "EarliestGameTimeHourWeekday",
                value: 17);

            migrationBuilder.CreateIndex(
                name: "IX_ExcludedGameDate_TeamId",
                table: "ExcludedGameDate",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExcludedGameDate");

            migrationBuilder.UpdateData(
                table: "Alert",
                keyColumn: "AlertId",
                keyValue: 1,
                column: "AlertDate",
                value: new DateTime(2025, 1, 24, 15, 59, 19, 210, DateTimeKind.Local).AddTicks(6325));

            migrationBuilder.UpdateData(
                table: "League",
                keyColumn: "LeagueId",
                keyValue: 1,
                column: "EarliestGameTimeHourWeekday",
                value: 5);
        }
    }
}
