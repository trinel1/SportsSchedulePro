﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportsScheduleProLibrary.Data;

namespace SportsScheduleProLibrary.Migrations
{
    [DbContext(typeof(SportsScheduleProDataContext))]
    partial class SportsScheduleProDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AlertAlertContact", b =>
                {
                    b.Property<int>("AlertContactsPersonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlertsAlertId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AlertContactsPersonId", "AlertsAlertId");

                    b.HasIndex("AlertsAlertId");

                    b.ToTable("AlertAlertContact");
                });

            modelBuilder.Entity("AlertContactPlayer", b =>
                {
                    b.Property<int>("AlertContactsPersonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayersPersonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AlertContactsPersonId", "PlayersPersonId");

                    b.HasIndex("PlayersPersonId");

                    b.ToTable("AlertContactPlayer");
                });

            modelBuilder.Entity("CoachPlayer", b =>
                {
                    b.Property<int>("CoachesPersonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayersPersonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CoachesPersonId", "PlayersPersonId");

                    b.HasIndex("PlayersPersonId");

                    b.ToTable("CoachPlayer");
                });

            modelBuilder.Entity("CoachTeam", b =>
                {
                    b.Property<int>("CoachesPersonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamsTeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CoachesPersonId", "TeamsTeamId");

                    b.HasIndex("TeamsTeamId");

                    b.ToTable("CoachTeam");
                });

            modelBuilder.Entity("FieldLeague", b =>
                {
                    b.Property<int>("FieldsFieldId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LeaguesLeagueId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FieldsFieldId", "LeaguesLeagueId");

                    b.HasIndex("LeaguesLeagueId");

                    b.ToTable("FieldLeague");
                });

            modelBuilder.Entity("FieldTournament", b =>
                {
                    b.Property<int>("FieldsFieldId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TournamentsTournamentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FieldsFieldId", "TournamentsTournamentId");

                    b.HasIndex("TournamentsTournamentId");

                    b.ToTable("FieldTournament");
                });

            modelBuilder.Entity("LeagueReferee", b =>
                {
                    b.Property<int>("LeaguesLeagueId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RefereesPersonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LeaguesLeagueId", "RefereesPersonId");

                    b.HasIndex("RefereesPersonId");

                    b.ToTable("LeagueReferee");
                });

            modelBuilder.Entity("LeagueSeason", b =>
                {
                    b.Property<int>("LeaguesLeagueId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SeasonsSeasonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LeaguesLeagueId", "SeasonsSeasonId");

                    b.HasIndex("SeasonsSeasonId");

                    b.ToTable("LeagueSeason");
                });

            modelBuilder.Entity("PlayerTeam", b =>
                {
                    b.Property<int>("PlayersPersonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamsTeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PlayersPersonId", "TeamsTeamId");

                    b.HasIndex("TeamsTeamId");

                    b.ToTable("PlayerTeam");
                });

            modelBuilder.Entity("RefereeSeason", b =>
                {
                    b.Property<int>("RefereesPersonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SeasonsSeasonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RefereesPersonId", "SeasonsSeasonId");

                    b.HasIndex("SeasonsSeasonId");

                    b.ToTable("RefereeSeason");
                });

            modelBuilder.Entity("SeasonTeam", b =>
                {
                    b.Property<int>("SeasonsSeasonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamsTeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SeasonsSeasonId", "TeamsTeamId");

                    b.HasIndex("TeamsTeamId");

                    b.ToTable("SeasonTeam");
                });

            modelBuilder.Entity("SportsScheduleProLibrary.Alert", b =>
                {
                    b.Property<int>("AlertId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("AlertDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("AlertType")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ClubId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Message")
                        .HasColumnType("TEXT");

                    b.HasKey("AlertId");

                    b.HasIndex("ClubId");

                    b.ToTable("Alert");
                });

            modelBuilder.Entity("SportsScheduleProLibrary.AlertContact", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactPhone")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("PreferredContactMethod")
                        .HasColumnType("INTEGER");

                    b.HasKey("PersonId");

                    b.ToTable("AlertContact");
                });

            modelBuilder.Entity("SportsScheduleProLibrary.Club", b =>
                {
                    b.Property<int>("ClubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ClubId");

                    b.ToTable("Club");
                });

            modelBuilder.Entity("SportsScheduleProLibrary.Coach", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactPhone")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonId");

                    b.ToTable("Coach");
                });

            modelBuilder.Entity("SportsScheduleProLibrary.Field", b =>
                {
                    b.Property<int>("FieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClubId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasLights")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOpenFriday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOpenMonday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOpenSaturday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOpenSunday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOpenThursday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOpenTuesday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOpenWednesday")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("FieldId");

                    b.HasIndex("ClubId");

                    b.HasIndex("LocationId");

                    b.ToTable("Field");
                });

            modelBuilder.Entity("SportsScheduleProLibrary.League", b =>
                {
                    b.Property<int>("LeagueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AgeGroup")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("AgeGroupEarliestDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("AgeGroupLatestDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("AlertId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClubId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("LeagueId");

                    b.HasIndex("AlertId");

                    b.HasIndex("ClubId");

                    b.ToTable("League");
                });

            modelBuilder.Entity("SportsScheduleProLibrary.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClubId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOpenFriday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOpenMonday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOpenSaturday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOpenSunday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOpenThursday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOpenTuesday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOpenWednesday")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("LocationId");

                    b.HasIndex("ClubId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("SportsScheduleProLibrary.Player", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactPhone")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("SportsScheduleProLibrary.Referee", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactPhone")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonId");

                    b.ToTable("Referee");
                });

            modelBuilder.Entity("SportsScheduleProLibrary.Season", b =>
                {
                    b.Property<int>("SeasonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClubId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOpenFriday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOpenMonday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOpenSaturday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOpenSunday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOpenThursday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOpenTuesday")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOpenWednesday")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("SeasonId");

                    b.HasIndex("ClubId");

                    b.ToTable("Season");
                });

            modelBuilder.Entity("SportsScheduleProLibrary.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LeagueId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShirtColorChosen")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortsColorChosen")
                        .HasColumnType("TEXT");

                    b.HasKey("TeamId");

                    b.HasIndex("LeagueId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("SportsScheduleProLibrary.Tournament", b =>
                {
                    b.Property<int>("TournamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("TournamentName")
                        .HasColumnType("TEXT");

                    b.HasKey("TournamentId");

                    b.HasIndex("LocationId");

                    b.ToTable("Tournament");
                });

            modelBuilder.Entity("TeamTournament", b =>
                {
                    b.Property<int>("TeamsTeamId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TournamentsTournamentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeamsTeamId", "TournamentsTournamentId");

                    b.HasIndex("TournamentsTournamentId");

                    b.ToTable("TeamTournament");
                });

            modelBuilder.Entity("AlertAlertContact", b =>
                {
                    b.HasOne("SportsScheduleProLibrary.AlertContact", null)
                        .WithMany()
                        .HasForeignKey("AlertContactsPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsScheduleProLibrary.Alert", null)
                        .WithMany()
                        .HasForeignKey("AlertsAlertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AlertContactPlayer", b =>
                {
                    b.HasOne("SportsScheduleProLibrary.AlertContact", null)
                        .WithMany()
                        .HasForeignKey("AlertContactsPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsScheduleProLibrary.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoachPlayer", b =>
                {
                    b.HasOne("SportsScheduleProLibrary.Coach", null)
                        .WithMany()
                        .HasForeignKey("CoachesPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsScheduleProLibrary.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoachTeam", b =>
                {
                    b.HasOne("SportsScheduleProLibrary.Coach", null)
                        .WithMany()
                        .HasForeignKey("CoachesPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsScheduleProLibrary.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FieldLeague", b =>
                {
                    b.HasOne("SportsScheduleProLibrary.Field", null)
                        .WithMany()
                        .HasForeignKey("FieldsFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsScheduleProLibrary.League", null)
                        .WithMany()
                        .HasForeignKey("LeaguesLeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FieldTournament", b =>
                {
                    b.HasOne("SportsScheduleProLibrary.Field", null)
                        .WithMany()
                        .HasForeignKey("FieldsFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsScheduleProLibrary.Tournament", null)
                        .WithMany()
                        .HasForeignKey("TournamentsTournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LeagueReferee", b =>
                {
                    b.HasOne("SportsScheduleProLibrary.League", null)
                        .WithMany()
                        .HasForeignKey("LeaguesLeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsScheduleProLibrary.Referee", null)
                        .WithMany()
                        .HasForeignKey("RefereesPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LeagueSeason", b =>
                {
                    b.HasOne("SportsScheduleProLibrary.League", null)
                        .WithMany()
                        .HasForeignKey("LeaguesLeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsScheduleProLibrary.Season", null)
                        .WithMany()
                        .HasForeignKey("SeasonsSeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlayerTeam", b =>
                {
                    b.HasOne("SportsScheduleProLibrary.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsScheduleProLibrary.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RefereeSeason", b =>
                {
                    b.HasOne("SportsScheduleProLibrary.Referee", null)
                        .WithMany()
                        .HasForeignKey("RefereesPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsScheduleProLibrary.Season", null)
                        .WithMany()
                        .HasForeignKey("SeasonsSeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeasonTeam", b =>
                {
                    b.HasOne("SportsScheduleProLibrary.Season", null)
                        .WithMany()
                        .HasForeignKey("SeasonsSeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsScheduleProLibrary.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SportsScheduleProLibrary.Alert", b =>
                {
                    b.HasOne("SportsScheduleProLibrary.Club", "Club")
                        .WithMany()
                        .HasForeignKey("ClubId");

                    b.Navigation("Club");
                });

            modelBuilder.Entity("SportsScheduleProLibrary.Field", b =>
                {
                    b.HasOne("SportsScheduleProLibrary.Club", "Club")
                        .WithMany("Fields")
                        .HasForeignKey("ClubId");

                    b.HasOne("SportsScheduleProLibrary.Location", "Location")
                        .WithMany("Fields")
                        .HasForeignKey("LocationId");

                    b.Navigation("Club");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("SportsScheduleProLibrary.League", b =>
                {
                    b.HasOne("SportsScheduleProLibrary.Alert", null)
                        .WithMany("Leagues")
                        .HasForeignKey("AlertId");

                    b.HasOne("SportsScheduleProLibrary.Club", "Club")
                        .WithMany("Leagues")
                        .HasForeignKey("ClubId");

                    b.Navigation("Club");
                });

            modelBuilder.Entity("SportsScheduleProLibrary.Location", b =>
                {
                    b.HasOne("SportsScheduleProLibrary.Club", "Club")
                        .WithMany("Locations")
                        .HasForeignKey("ClubId");

                    b.Navigation("Club");
                });

            modelBuilder.Entity("SportsScheduleProLibrary.Season", b =>
                {
                    b.HasOne("SportsScheduleProLibrary.Club", "Club")
                        .WithMany("Seasons")
                        .HasForeignKey("ClubId");

                    b.Navigation("Club");
                });

            modelBuilder.Entity("SportsScheduleProLibrary.Team", b =>
                {
                    b.HasOne("SportsScheduleProLibrary.League", "League")
                        .WithMany("Teams")
                        .HasForeignKey("LeagueId");

                    b.Navigation("League");
                });

            modelBuilder.Entity("SportsScheduleProLibrary.Tournament", b =>
                {
                    b.HasOne("SportsScheduleProLibrary.Location", "Location")
                        .WithMany("Tournaments")
                        .HasForeignKey("LocationId");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("TeamTournament", b =>
                {
                    b.HasOne("SportsScheduleProLibrary.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsScheduleProLibrary.Tournament", null)
                        .WithMany()
                        .HasForeignKey("TournamentsTournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SportsScheduleProLibrary.Alert", b =>
                {
                    b.Navigation("Leagues");
                });

            modelBuilder.Entity("SportsScheduleProLibrary.Club", b =>
                {
                    b.Navigation("Fields");

                    b.Navigation("Leagues");

                    b.Navigation("Locations");

                    b.Navigation("Seasons");
                });

            modelBuilder.Entity("SportsScheduleProLibrary.League", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("SportsScheduleProLibrary.Location", b =>
                {
                    b.Navigation("Fields");

                    b.Navigation("Tournaments");
                });
#pragma warning restore 612, 618
        }
    }
}
