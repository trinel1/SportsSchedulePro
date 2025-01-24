using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsScheduleProLibrary.Migrations
{
    public partial class CompleteDBRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alert_Clubs_ClubId",
                table: "Alert");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertContact_Alert_AlertId",
                table: "AlertContact");

            migrationBuilder.DropForeignKey(
                name: "FK_Coach_Team_TeamId",
                table: "Coach");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldLeague_Fields_FieldsFieldId",
                table: "FieldLeague");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldLeague_Leagues_LeaguesLeagueId",
                table: "FieldLeague");

            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Clubs_ClubId",
                table: "Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Locations_LocationId",
                table: "Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Tournament_TournamentId",
                table: "Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_Leagues_Alert_AlertId",
                table: "Leagues");

            migrationBuilder.DropForeignKey(
                name: "FK_Leagues_Clubs_ClubId",
                table: "Leagues");

            migrationBuilder.DropForeignKey(
                name: "FK_Leagues_Locations_LocationId",
                table: "Leagues");

            migrationBuilder.DropForeignKey(
                name: "FK_LeagueSeason_Leagues_LeaguesLeagueId",
                table: "LeagueSeason");

            migrationBuilder.DropForeignKey(
                name: "FK_LeagueSeason_Seasons_SeasonsSeasonId",
                table: "LeagueSeason");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Clubs_ClubId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player");

            migrationBuilder.DropForeignKey(
                name: "FK_Referee_Leagues_LeagueId",
                table: "Referee");

            migrationBuilder.DropForeignKey(
                name: "FK_Referee_Seasons_SeasonId",
                table: "Referee");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Clubs_ClubId",
                table: "Seasons");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Leagues_LeagueId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_Seasons_SeasonId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_Clubs_ClubId",
                table: "Tournament");

            migrationBuilder.DropIndex(
                name: "IX_Team_SeasonId",
                table: "Team");

            migrationBuilder.DropIndex(
                name: "IX_Referee_LeagueId",
                table: "Referee");

            migrationBuilder.DropIndex(
                name: "IX_Referee_SeasonId",
                table: "Referee");

            migrationBuilder.DropIndex(
                name: "IX_Player_TeamId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Coach_TeamId",
                table: "Coach");

            migrationBuilder.DropIndex(
                name: "IX_AlertContact_AlertId",
                table: "AlertContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seasons",
                table: "Seasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leagues",
                table: "Leagues");

            migrationBuilder.DropIndex(
                name: "IX_Leagues_LocationId",
                table: "Leagues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fields",
                table: "Fields");

            migrationBuilder.DropIndex(
                name: "IX_Fields_TournamentId",
                table: "Fields");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clubs",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "LeagueId",
                table: "Referee");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Referee");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Coach");

            migrationBuilder.DropColumn(
                name: "AlertId",
                table: "AlertContact");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Leagues");

            migrationBuilder.DropColumn(
                name: "TournamentId",
                table: "Fields");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Clubs");

            migrationBuilder.RenameTable(
                name: "Seasons",
                newName: "Season");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.RenameTable(
                name: "Leagues",
                newName: "League");

            migrationBuilder.RenameTable(
                name: "Fields",
                newName: "Field");

            migrationBuilder.RenameTable(
                name: "Clubs",
                newName: "Club");

            migrationBuilder.RenameColumn(
                name: "ClubId",
                table: "Tournament",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Tournament_ClubId",
                table: "Tournament",
                newName: "IX_Tournament_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Seasons_ClubId",
                table: "Season",
                newName: "IX_Season_ClubId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_ClubId",
                table: "Location",
                newName: "IX_Location_ClubId");

            migrationBuilder.RenameIndex(
                name: "IX_Leagues_ClubId",
                table: "League",
                newName: "IX_League_ClubId");

            migrationBuilder.RenameIndex(
                name: "IX_Leagues_AlertId",
                table: "League",
                newName: "IX_League_AlertId");

            migrationBuilder.RenameIndex(
                name: "IX_Fields_LocationId",
                table: "Field",
                newName: "IX_Field_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Fields_ClubId",
                table: "Field",
                newName: "IX_Field_ClubId");

            migrationBuilder.AddColumn<string>(
                name: "TournamentName",
                table: "Tournament",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Season",
                table: "Season",
                column: "SeasonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_League",
                table: "League",
                column: "LeagueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Field",
                table: "Field",
                column: "FieldId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Club",
                table: "Club",
                column: "ClubId");

            migrationBuilder.CreateTable(
                name: "AlertAlertContact",
                columns: table => new
                {
                    AlertContactsPersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    AlertsAlertId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertAlertContact", x => new { x.AlertContactsPersonId, x.AlertsAlertId });
                    table.ForeignKey(
                        name: "FK_AlertAlertContact_Alert_AlertsAlertId",
                        column: x => x.AlertsAlertId,
                        principalTable: "Alert",
                        principalColumn: "AlertId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlertAlertContact_AlertContact_AlertContactsPersonId",
                        column: x => x.AlertContactsPersonId,
                        principalTable: "AlertContact",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoachTeam",
                columns: table => new
                {
                    CoachesPersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamsTeamId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachTeam", x => new { x.CoachesPersonId, x.TeamsTeamId });
                    table.ForeignKey(
                        name: "FK_CoachTeam_Coach_CoachesPersonId",
                        column: x => x.CoachesPersonId,
                        principalTable: "Coach",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoachTeam_Team_TeamsTeamId",
                        column: x => x.TeamsTeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldTournament",
                columns: table => new
                {
                    FieldsFieldId = table.Column<int>(type: "INTEGER", nullable: false),
                    TournamentsTournamentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldTournament", x => new { x.FieldsFieldId, x.TournamentsTournamentId });
                    table.ForeignKey(
                        name: "FK_FieldTournament_Field_FieldsFieldId",
                        column: x => x.FieldsFieldId,
                        principalTable: "Field",
                        principalColumn: "FieldId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldTournament_Tournament_TournamentsTournamentId",
                        column: x => x.TournamentsTournamentId,
                        principalTable: "Tournament",
                        principalColumn: "TournamentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeagueReferee",
                columns: table => new
                {
                    LeaguesLeagueId = table.Column<int>(type: "INTEGER", nullable: false),
                    RefereesPersonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueReferee", x => new { x.LeaguesLeagueId, x.RefereesPersonId });
                    table.ForeignKey(
                        name: "FK_LeagueReferee_League_LeaguesLeagueId",
                        column: x => x.LeaguesLeagueId,
                        principalTable: "League",
                        principalColumn: "LeagueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeagueReferee_Referee_RefereesPersonId",
                        column: x => x.RefereesPersonId,
                        principalTable: "Referee",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTeam",
                columns: table => new
                {
                    PlayersPersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamsTeamId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTeam", x => new { x.PlayersPersonId, x.TeamsTeamId });
                    table.ForeignKey(
                        name: "FK_PlayerTeam_Player_PlayersPersonId",
                        column: x => x.PlayersPersonId,
                        principalTable: "Player",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerTeam_Team_TeamsTeamId",
                        column: x => x.TeamsTeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefereeSeason",
                columns: table => new
                {
                    RefereesPersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    SeasonsSeasonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefereeSeason", x => new { x.RefereesPersonId, x.SeasonsSeasonId });
                    table.ForeignKey(
                        name: "FK_RefereeSeason_Referee_RefereesPersonId",
                        column: x => x.RefereesPersonId,
                        principalTable: "Referee",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RefereeSeason_Season_SeasonsSeasonId",
                        column: x => x.SeasonsSeasonId,
                        principalTable: "Season",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeasonTeam",
                columns: table => new
                {
                    SeasonsSeasonId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamsTeamId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonTeam", x => new { x.SeasonsSeasonId, x.TeamsTeamId });
                    table.ForeignKey(
                        name: "FK_SeasonTeam_Season_SeasonsSeasonId",
                        column: x => x.SeasonsSeasonId,
                        principalTable: "Season",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeasonTeam_Team_TeamsTeamId",
                        column: x => x.TeamsTeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlertAlertContact_AlertsAlertId",
                table: "AlertAlertContact",
                column: "AlertsAlertId");

            migrationBuilder.CreateIndex(
                name: "IX_CoachTeam_TeamsTeamId",
                table: "CoachTeam",
                column: "TeamsTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldTournament_TournamentsTournamentId",
                table: "FieldTournament",
                column: "TournamentsTournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueReferee_RefereesPersonId",
                table: "LeagueReferee",
                column: "RefereesPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeam_TeamsTeamId",
                table: "PlayerTeam",
                column: "TeamsTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_RefereeSeason_SeasonsSeasonId",
                table: "RefereeSeason",
                column: "SeasonsSeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonTeam_TeamsTeamId",
                table: "SeasonTeam",
                column: "TeamsTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alert_Club_ClubId",
                table: "Alert",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "ClubId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Field_Club_ClubId",
                table: "Field",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "ClubId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Field_Location_LocationId",
                table: "Field",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldLeague_Field_FieldsFieldId",
                table: "FieldLeague",
                column: "FieldsFieldId",
                principalTable: "Field",
                principalColumn: "FieldId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldLeague_League_LeaguesLeagueId",
                table: "FieldLeague",
                column: "LeaguesLeagueId",
                principalTable: "League",
                principalColumn: "LeagueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_League_Alert_AlertId",
                table: "League",
                column: "AlertId",
                principalTable: "Alert",
                principalColumn: "AlertId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_League_Club_ClubId",
                table: "League",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "ClubId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueSeason_League_LeaguesLeagueId",
                table: "LeagueSeason",
                column: "LeaguesLeagueId",
                principalTable: "League",
                principalColumn: "LeagueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueSeason_Season_SeasonsSeasonId",
                table: "LeagueSeason",
                column: "SeasonsSeasonId",
                principalTable: "Season",
                principalColumn: "SeasonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Club_ClubId",
                table: "Location",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "ClubId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Season_Club_ClubId",
                table: "Season",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "ClubId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_League_LeagueId",
                table: "Team",
                column: "LeagueId",
                principalTable: "League",
                principalColumn: "LeagueId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournament_Location_LocationId",
                table: "Tournament",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alert_Club_ClubId",
                table: "Alert");

            migrationBuilder.DropForeignKey(
                name: "FK_Field_Club_ClubId",
                table: "Field");

            migrationBuilder.DropForeignKey(
                name: "FK_Field_Location_LocationId",
                table: "Field");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldLeague_Field_FieldsFieldId",
                table: "FieldLeague");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldLeague_League_LeaguesLeagueId",
                table: "FieldLeague");

            migrationBuilder.DropForeignKey(
                name: "FK_League_Alert_AlertId",
                table: "League");

            migrationBuilder.DropForeignKey(
                name: "FK_League_Club_ClubId",
                table: "League");

            migrationBuilder.DropForeignKey(
                name: "FK_LeagueSeason_League_LeaguesLeagueId",
                table: "LeagueSeason");

            migrationBuilder.DropForeignKey(
                name: "FK_LeagueSeason_Season_SeasonsSeasonId",
                table: "LeagueSeason");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_Club_ClubId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Season_Club_ClubId",
                table: "Season");

            migrationBuilder.DropForeignKey(
                name: "FK_Team_League_LeagueId",
                table: "Team");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournament_Location_LocationId",
                table: "Tournament");

            migrationBuilder.DropTable(
                name: "AlertAlertContact");

            migrationBuilder.DropTable(
                name: "CoachTeam");

            migrationBuilder.DropTable(
                name: "FieldTournament");

            migrationBuilder.DropTable(
                name: "LeagueReferee");

            migrationBuilder.DropTable(
                name: "PlayerTeam");

            migrationBuilder.DropTable(
                name: "RefereeSeason");

            migrationBuilder.DropTable(
                name: "SeasonTeam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Season",
                table: "Season");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_League",
                table: "League");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Field",
                table: "Field");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Club",
                table: "Club");

            migrationBuilder.DropColumn(
                name: "TournamentName",
                table: "Tournament");

            migrationBuilder.RenameTable(
                name: "Season",
                newName: "Seasons");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.RenameTable(
                name: "League",
                newName: "Leagues");

            migrationBuilder.RenameTable(
                name: "Field",
                newName: "Fields");

            migrationBuilder.RenameTable(
                name: "Club",
                newName: "Clubs");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Tournament",
                newName: "ClubId");

            migrationBuilder.RenameIndex(
                name: "IX_Tournament_LocationId",
                table: "Tournament",
                newName: "IX_Tournament_ClubId");

            migrationBuilder.RenameIndex(
                name: "IX_Season_ClubId",
                table: "Seasons",
                newName: "IX_Seasons_ClubId");

            migrationBuilder.RenameIndex(
                name: "IX_Location_ClubId",
                table: "Locations",
                newName: "IX_Locations_ClubId");

            migrationBuilder.RenameIndex(
                name: "IX_League_ClubId",
                table: "Leagues",
                newName: "IX_Leagues_ClubId");

            migrationBuilder.RenameIndex(
                name: "IX_League_AlertId",
                table: "Leagues",
                newName: "IX_Leagues_AlertId");

            migrationBuilder.RenameIndex(
                name: "IX_Field_LocationId",
                table: "Fields",
                newName: "IX_Fields_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Field_ClubId",
                table: "Fields",
                newName: "IX_Fields_ClubId");

            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "Team",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeagueId",
                table: "Referee",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "Referee",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Player",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Coach",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlertId",
                table: "AlertContact",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Leagues",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TournamentId",
                table: "Fields",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Clubs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seasons",
                table: "Seasons",
                column: "SeasonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leagues",
                table: "Leagues",
                column: "LeagueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fields",
                table: "Fields",
                column: "FieldId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clubs",
                table: "Clubs",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_SeasonId",
                table: "Team",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Referee_LeagueId",
                table: "Referee",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_Referee_SeasonId",
                table: "Referee",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamId",
                table: "Player",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Coach_TeamId",
                table: "Coach",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertContact_AlertId",
                table: "AlertContact",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_LocationId",
                table: "Leagues",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_TournamentId",
                table: "Fields",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alert_Clubs_ClubId",
                table: "Alert",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "ClubId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AlertContact_Alert_AlertId",
                table: "AlertContact",
                column: "AlertId",
                principalTable: "Alert",
                principalColumn: "AlertId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coach_Team_TeamId",
                table: "Coach",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldLeague_Fields_FieldsFieldId",
                table: "FieldLeague",
                column: "FieldsFieldId",
                principalTable: "Fields",
                principalColumn: "FieldId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldLeague_Leagues_LeaguesLeagueId",
                table: "FieldLeague",
                column: "LeaguesLeagueId",
                principalTable: "Leagues",
                principalColumn: "LeagueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Clubs_ClubId",
                table: "Fields",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "ClubId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Locations_LocationId",
                table: "Fields",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Tournament_TournamentId",
                table: "Fields",
                column: "TournamentId",
                principalTable: "Tournament",
                principalColumn: "TournamentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Leagues_Alert_AlertId",
                table: "Leagues",
                column: "AlertId",
                principalTable: "Alert",
                principalColumn: "AlertId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Leagues_Clubs_ClubId",
                table: "Leagues",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "ClubId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Leagues_Locations_LocationId",
                table: "Leagues",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueSeason_Leagues_LeaguesLeagueId",
                table: "LeagueSeason",
                column: "LeaguesLeagueId",
                principalTable: "Leagues",
                principalColumn: "LeagueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeagueSeason_Seasons_SeasonsSeasonId",
                table: "LeagueSeason",
                column: "SeasonsSeasonId",
                principalTable: "Seasons",
                principalColumn: "SeasonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Clubs_ClubId",
                table: "Locations",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "ClubId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Referee_Leagues_LeagueId",
                table: "Referee",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "LeagueId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Referee_Seasons_SeasonId",
                table: "Referee",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "SeasonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Clubs_ClubId",
                table: "Seasons",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "ClubId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Leagues_LeagueId",
                table: "Team",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "LeagueId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Seasons_SeasonId",
                table: "Team",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "SeasonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournament_Clubs_ClubId",
                table: "Tournament",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "ClubId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
