using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsScheduleProLibrary.Migrations
{
    public partial class DBSeedDataAndDirector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DirectorPersonId",
                table: "Tournament",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClubId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ContactPhone = table.Column<string>(type: "TEXT", nullable: true),
                    ContactEmail = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Director_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Alert",
                columns: new[] { "AlertId", "AlertDate", "AlertType", "ClubId", "EndDate", "IsDeleted", "Message" },
                values: new object[] { 1, new DateTime(2025, 1, 24, 13, 48, 43, 879, DateTimeKind.Local).AddTicks(857), null, null, null, false, "Weather alert - Fields will be closed due to inclement weather." });

            migrationBuilder.InsertData(
                table: "AlertContact",
                columns: new[] { "PersonId", "ContactEmail", "ContactPhone", "IsDeleted", "Name", "PreferredContactMethod" },
                values: new object[] { 1, "timothylindsay.ns1@gmail.com", "3182451296", false, "Timothy Lindsay", 2 });

            migrationBuilder.InsertData(
                table: "Club",
                columns: new[] { "ClubId", "IsDeleted", "Name" },
                values: new object[] { 1, false, "NELSA" });

            migrationBuilder.InsertData(
                table: "Coach",
                columns: new[] { "PersonId", "ContactEmail", "ContactPhone", "IsDeleted", "Name" },
                values: new object[] { 1, "timothylindsay.ns1@gmail.com", "3182451296", false, "Timothy Lindsay" });

            migrationBuilder.InsertData(
                table: "Coach",
                columns: new[] { "PersonId", "ContactEmail", "ContactPhone", "IsDeleted", "Name" },
                values: new object[] { 2, null, null, false, "Doug Smith" });

            migrationBuilder.InsertData(
                table: "Director",
                columns: new[] { "PersonId", "ClubId", "ContactEmail", "ContactPhone", "IsDeleted", "Name" },
                values: new object[] { 1, null, null, null, false, "Nick Artigue" });

            migrationBuilder.InsertData(
                table: "Field",
                columns: new[] { "FieldId", "ClubId", "HasLights", "IsDeleted", "IsOpenFriday", "IsOpenMonday", "IsOpenSaturday", "IsOpenSunday", "IsOpenThursday", "IsOpenTuesday", "IsOpenWednesday", "LocationId", "Name" },
                values: new object[] { 1, null, false, false, true, true, true, true, true, true, true, null, "NELSA" });

            migrationBuilder.InsertData(
                table: "League",
                columns: new[] { "LeagueId", "AgeGroup", "AgeGroupEarliestDate", "AgeGroupLatestDate", "AlertId", "ClubId", "EndDate", "Gender", "IsDeleted", "Name", "StartDate" },
                values: new object[] { 1, "9-10", new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", false, "2015-2016 Boys Recreational", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "LocationId", "ClubId", "IsDeleted", "IsOpenFriday", "IsOpenMonday", "IsOpenSaturday", "IsOpenSunday", "IsOpenThursday", "IsOpenTuesday", "IsOpenWednesday", "Name" },
                values: new object[] { 1, null, false, true, true, true, true, true, true, true, "NELSA (Chennault)" });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "PersonId", "ContactEmail", "ContactPhone", "IsDeleted", "Name" },
                values: new object[] { 1, "timothylindsay.ns1@gmail.com", "3182451296", false, "Micah Lindsay" });

            migrationBuilder.InsertData(
                table: "Season",
                columns: new[] { "SeasonId", "ClubId", "EndDate", "IsDeleted", "IsOpenFriday", "IsOpenMonday", "IsOpenSaturday", "IsOpenSunday", "IsOpenThursday", "IsOpenTuesday", "IsOpenWednesday", "StartDate" },
                values: new object[] { 1, null, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, true, true, true, true, true, true, new DateTime(2025, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "TeamId", "IsDeleted", "LeagueId", "Name", "ShirtColorChosen", "ShortsColorChosen" },
                values: new object[] { 1, false, null, "Smith/Lindsay", "Navy Striped", "Black" });

            migrationBuilder.InsertData(
                table: "Tournament",
                columns: new[] { "TournamentId", "DirectorPersonId", "EndDate", "IsDeleted", "LocationId", "StartDate", "TournamentName" },
                values: new object[] { 1, null, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "End of Season Recreational" });

            migrationBuilder.CreateIndex(
                name: "IX_Tournament_DirectorPersonId",
                table: "Tournament",
                column: "DirectorPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Director_ClubId",
                table: "Director",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournament_Director_DirectorPersonId",
                table: "Tournament",
                column: "DirectorPersonId",
                principalTable: "Director",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_Director_DirectorPersonId",
                table: "Tournament");

            migrationBuilder.DropTable(
                name: "Director");

            migrationBuilder.DropIndex(
                name: "IX_Tournament_DirectorPersonId",
                table: "Tournament");

            migrationBuilder.DeleteData(
                table: "Alert",
                keyColumn: "AlertId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AlertContact",
                keyColumn: "PersonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Club",
                keyColumn: "ClubId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coach",
                keyColumn: "PersonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coach",
                keyColumn: "PersonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Field",
                keyColumn: "FieldId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "League",
                keyColumn: "LeagueId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "LocationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Player",
                keyColumn: "PersonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Season",
                keyColumn: "SeasonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Team",
                keyColumn: "TeamId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tournament",
                keyColumn: "TournamentId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "DirectorPersonId",
                table: "Tournament");
        }
    }
}
