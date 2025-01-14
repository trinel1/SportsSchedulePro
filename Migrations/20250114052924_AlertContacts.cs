using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsScheduleProLibrary.Migrations
{
    public partial class AlertContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlertContactPlayer_People_AlertContactsPersonId",
                table: "AlertContactPlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertContactPlayer_People_PlayersPersonId",
                table: "AlertContactPlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_CoachPlayer_People_CoachesPersonId",
                table: "CoachPlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_CoachPlayer_People_PlayersPersonId",
                table: "CoachPlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Alert_AlertId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Leagues_LeagueId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Seasons_SeasonId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Team_Player_TeamId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Team_TeamId",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_AlertId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_Player_TeamId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_TeamId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "AlertId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Player_TeamId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PreferredContactMethod",
                table: "People");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Referee");

            migrationBuilder.RenameIndex(
                name: "IX_People_SeasonId",
                table: "Referee",
                newName: "IX_Referee_SeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_People_LeagueId",
                table: "Referee",
                newName: "IX_Referee_LeagueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Referee",
                table: "Referee",
                column: "PersonId");

            migrationBuilder.CreateTable(
                name: "AlertContact",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PreferredContactMethod = table.Column<int>(type: "INTEGER", nullable: false),
                    AlertId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ContactPhone = table.Column<string>(type: "TEXT", nullable: true),
                    ContactEmail = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertContact", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_AlertContact_Alert_AlertId",
                        column: x => x.AlertId,
                        principalTable: "Alert",
                        principalColumn: "AlertId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Coach",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ContactPhone = table.Column<string>(type: "TEXT", nullable: true),
                    ContactEmail = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coach", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Coach_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ContactPhone = table.Column<string>(type: "TEXT", nullable: true),
                    ContactEmail = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Player_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlertContact_AlertId",
                table: "AlertContact",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_Coach_TeamId",
                table: "Coach",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamId",
                table: "Player",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertContactPlayer_AlertContact_AlertContactsPersonId",
                table: "AlertContactPlayer",
                column: "AlertContactsPersonId",
                principalTable: "AlertContact",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlertContactPlayer_Player_PlayersPersonId",
                table: "AlertContactPlayer",
                column: "PlayersPersonId",
                principalTable: "Player",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoachPlayer_Coach_CoachesPersonId",
                table: "CoachPlayer",
                column: "CoachesPersonId",
                principalTable: "Coach",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoachPlayer_Player_PlayersPersonId",
                table: "CoachPlayer",
                column: "PlayersPersonId",
                principalTable: "Player",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlertContactPlayer_AlertContact_AlertContactsPersonId",
                table: "AlertContactPlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertContactPlayer_Player_PlayersPersonId",
                table: "AlertContactPlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_CoachPlayer_Coach_CoachesPersonId",
                table: "CoachPlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_CoachPlayer_Player_PlayersPersonId",
                table: "CoachPlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_Referee_Leagues_LeagueId",
                table: "Referee");

            migrationBuilder.DropForeignKey(
                name: "FK_Referee_Seasons_SeasonId",
                table: "Referee");

            migrationBuilder.DropTable(
                name: "AlertContact");

            migrationBuilder.DropTable(
                name: "Coach");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Referee",
                table: "Referee");

            migrationBuilder.RenameTable(
                name: "Referee",
                newName: "People");

            migrationBuilder.RenameIndex(
                name: "IX_Referee_SeasonId",
                table: "People",
                newName: "IX_People_SeasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Referee_LeagueId",
                table: "People",
                newName: "IX_People_LeagueId");

            migrationBuilder.AddColumn<int>(
                name: "AlertId",
                table: "People",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "People",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Player_TeamId",
                table: "People",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreferredContactMethod",
                table: "People",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "People",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_People_AlertId",
                table: "People",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_People_Player_TeamId",
                table: "People",
                column: "Player_TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_People_TeamId",
                table: "People",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertContactPlayer_People_AlertContactsPersonId",
                table: "AlertContactPlayer",
                column: "AlertContactsPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlertContactPlayer_People_PlayersPersonId",
                table: "AlertContactPlayer",
                column: "PlayersPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoachPlayer_People_CoachesPersonId",
                table: "CoachPlayer",
                column: "CoachesPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CoachPlayer_People_PlayersPersonId",
                table: "CoachPlayer",
                column: "PlayersPersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Alert_AlertId",
                table: "People",
                column: "AlertId",
                principalTable: "Alert",
                principalColumn: "AlertId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Leagues_LeagueId",
                table: "People",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "LeagueId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Seasons_SeasonId",
                table: "People",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "SeasonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Team_Player_TeamId",
                table: "People",
                column: "Player_TeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Team_TeamId",
                table: "People",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
