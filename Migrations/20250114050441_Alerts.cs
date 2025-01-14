using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsScheduleProLibrary.Migrations
{
    public partial class Alerts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    ClubId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.ClubId);
                });

            migrationBuilder.CreateTable(
                name: "Alert",
                columns: table => new
                {
                    AlertId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    ClubId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alert", x => x.AlertId);
                    table.ForeignKey(
                        name: "FK_Alert_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    IsOpenSunday = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOpenMonday = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOpenTuesday = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOpenWednesday = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOpenThursday = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOpenFriday = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOpenSaturday = table.Column<bool>(type: "INTEGER", nullable: false),
                    ClubId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    SeasonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsOpenSunday = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOpenMonday = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOpenTuesday = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOpenWednesday = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOpenThursday = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOpenFriday = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOpenSaturday = table.Column<bool>(type: "INTEGER", nullable: false),
                    ClubId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.SeasonId);
                    table.ForeignKey(
                        name: "FK_Seasons_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tournament",
                columns: table => new
                {
                    TournamentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ClubId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.TournamentId);
                    table.ForeignKey(
                        name: "FK_Tournament_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    LeagueId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    AgeGroup = table.Column<string>(type: "TEXT", nullable: true),
                    AgeGroupEarliestDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AgeGroupLatestDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ClubId = table.Column<int>(type: "INTEGER", nullable: true),
                    AlertId = table.Column<int>(type: "INTEGER", nullable: true),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.LeagueId);
                    table.ForeignKey(
                        name: "FK_Leagues_Alert_AlertId",
                        column: x => x.AlertId,
                        principalTable: "Alert",
                        principalColumn: "AlertId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Leagues_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Leagues_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    FieldId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    IsOpenSunday = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOpenMonday = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOpenTuesday = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOpenWednesday = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOpenThursday = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOpenFriday = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOpenSaturday = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasLights = table.Column<bool>(type: "INTEGER", nullable: false),
                    ClubId = table.Column<int>(type: "INTEGER", nullable: true),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: true),
                    TournamentId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.FieldId);
                    table.ForeignKey(
                        name: "FK_Fields_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fields_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fields_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeagueSeason",
                columns: table => new
                {
                    LeaguesLeagueId = table.Column<int>(type: "INTEGER", nullable: false),
                    SeasonsSeasonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueSeason", x => new { x.LeaguesLeagueId, x.SeasonsSeasonId });
                    table.ForeignKey(
                        name: "FK_LeagueSeason_Leagues_LeaguesLeagueId",
                        column: x => x.LeaguesLeagueId,
                        principalTable: "Leagues",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeagueSeason_Seasons_SeasonsSeasonId",
                        column: x => x.SeasonsSeasonId,
                        principalTable: "Seasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ShirtColorChosen = table.Column<string>(type: "TEXT", nullable: true),
                    ShortsColorChosen = table.Column<string>(type: "TEXT", nullable: true),
                    LeagueId = table.Column<int>(type: "INTEGER", nullable: true),
                    SeasonId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Team_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Team_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FieldLeague",
                columns: table => new
                {
                    FieldsFieldId = table.Column<int>(type: "INTEGER", nullable: false),
                    LeaguesLeagueId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldLeague", x => new { x.FieldsFieldId, x.LeaguesLeagueId });
                    table.ForeignKey(
                        name: "FK_FieldLeague_Fields_FieldsFieldId",
                        column: x => x.FieldsFieldId,
                        principalTable: "Fields",
                        principalColumn: "FieldId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldLeague_Leagues_LeaguesLeagueId",
                        column: x => x.LeaguesLeagueId,
                        principalTable: "Leagues",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ContactPhone = table.Column<string>(type: "TEXT", nullable: true),
                    ContactEmail = table.Column<string>(type: "TEXT", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    PreferredContactMethod = table.Column<int>(type: "INTEGER", nullable: true),
                    AlertId = table.Column<int>(type: "INTEGER", nullable: true),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: true),
                    Player_TeamId = table.Column<int>(type: "INTEGER", nullable: true),
                    SeasonId = table.Column<int>(type: "INTEGER", nullable: true),
                    LeagueId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_People_Alert_AlertId",
                        column: x => x.AlertId,
                        principalTable: "Alert",
                        principalColumn: "AlertId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_People_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_People_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_People_Team_Player_TeamId",
                        column: x => x.Player_TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_People_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamTournament",
                columns: table => new
                {
                    TeamsTeamId = table.Column<int>(type: "INTEGER", nullable: false),
                    TournamentsTournamentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamTournament", x => new { x.TeamsTeamId, x.TournamentsTournamentId });
                    table.ForeignKey(
                        name: "FK_TeamTournament_Team_TeamsTeamId",
                        column: x => x.TeamsTeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamTournament_Tournament_TournamentsTournamentId",
                        column: x => x.TournamentsTournamentId,
                        principalTable: "Tournament",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlertContactPlayer",
                columns: table => new
                {
                    AlertContactsPersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayersPersonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertContactPlayer", x => new { x.AlertContactsPersonId, x.PlayersPersonId });
                    table.ForeignKey(
                        name: "FK_AlertContactPlayer_People_AlertContactsPersonId",
                        column: x => x.AlertContactsPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlertContactPlayer_People_PlayersPersonId",
                        column: x => x.PlayersPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoachPlayer",
                columns: table => new
                {
                    CoachesPersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlayersPersonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachPlayer", x => new { x.CoachesPersonId, x.PlayersPersonId });
                    table.ForeignKey(
                        name: "FK_CoachPlayer_People_CoachesPersonId",
                        column: x => x.CoachesPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoachPlayer_People_PlayersPersonId",
                        column: x => x.PlayersPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alert_ClubId",
                table: "Alert",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertContactPlayer_PlayersPersonId",
                table: "AlertContactPlayer",
                column: "PlayersPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_CoachPlayer_PlayersPersonId",
                table: "CoachPlayer",
                column: "PlayersPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldLeague_LeaguesLeagueId",
                table: "FieldLeague",
                column: "LeaguesLeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_ClubId",
                table: "Fields",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_LocationId",
                table: "Fields",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_TournamentId",
                table: "Fields",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_AlertId",
                table: "Leagues",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_ClubId",
                table: "Leagues",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_LocationId",
                table: "Leagues",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueSeason_SeasonsSeasonId",
                table: "LeagueSeason",
                column: "SeasonsSeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ClubId",
                table: "Locations",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_People_AlertId",
                table: "People",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_People_LeagueId",
                table: "People",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_People_Player_TeamId",
                table: "People",
                column: "Player_TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_People_SeasonId",
                table: "People",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_People_TeamId",
                table: "People",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_ClubId",
                table: "Seasons",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_LeagueId",
                table: "Team",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_SeasonId",
                table: "Team",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamTournament_TournamentsTournamentId",
                table: "TeamTournament",
                column: "TournamentsTournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tournament_ClubId",
                table: "Tournament",
                column: "ClubId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlertContactPlayer");

            migrationBuilder.DropTable(
                name: "CoachPlayer");

            migrationBuilder.DropTable(
                name: "FieldLeague");

            migrationBuilder.DropTable(
                name: "LeagueSeason");

            migrationBuilder.DropTable(
                name: "TeamTournament");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Tournament");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Alert");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Clubs");
        }
    }
}
