using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SportsScheduleProLibrary.Models;

#nullable disable

namespace SportsScheduleProLibrary.Data
{
    public partial class SportsScheduleProDataContext : DbContext
    {

        public DbSet<Alert> Alerts { get; set; }
        public DbSet<AlertContact> AlertContacts { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<ExcludedGameDate> ExcludedGameDates { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Location> Locations { get; set; }
        //public DbSet<Person> People { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

        public SportsScheduleProDataContext()
        {
        }

        public SportsScheduleProDataContext(DbContextOptions<SportsScheduleProDataContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=./SportsScheduleProData.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            OnModelCreatingPartial(builder);

            builder.Entity<Alert>(entity =>
            {
                entity.ToTable("Alert");
                entity.HasKey(s => s.AlertId);
                entity.HasMany(s => s.Leagues);
                entity.HasMany(s => s.AlertContacts);
                entity.HasOne(s => s.Club);
                entity.HasQueryFilter(s => !s.IsDeleted);
                entity.HasData(new Alert
                {
                    AlertId = 1,
                    AlertDate = DateTime.Now,
                    Message = "Weather alert - Fields will be closed due to inclement weather.",                    
                });
            });

            builder.Entity<AlertContact>(entity =>
            {
                entity.ToTable("AlertContact");
                entity.HasKey(s => s.PersonId);
                entity.HasMany(s => s.Players).WithMany(s => s.AlertContacts);
                entity.HasMany(s => s.Alerts).WithMany(s => s.AlertContacts);
                entity.HasQueryFilter(s => !s.IsDeleted);
                entity.HasData(new AlertContact
                {
                    ContactEmail = "timothylindsay.ns1@gmail.com",
                    ContactPhone = "3182451296",
                    Name = "Timothy Lindsay",
                    PreferredContactMethod = PreferredContactMethod.GroupMe,
                    PersonId = 1
                });
            });

            builder.Entity<Club>(entity =>
            {
                entity.ToTable("Club");
                entity.HasKey(s => s.ClubId);
                entity.HasQueryFilter(s => !s.IsDeleted);
                entity.HasMany(s => s.Locations).WithOne(s => s.Club);
                entity.HasMany(s => s.Fields).WithOne(s => s.Club);
                entity.HasMany(s => s.Seasons).WithOne(s => s.Club);
                entity.HasMany(s => s.Leagues).WithOne(s => s.Club);
                entity.HasData(new Club
                {
                    Name = "NELSA",
                    ClubId = 1
                });
            });

            builder.Entity<Coach>(entity =>
            {
                entity.ToTable("Coach");
                entity.HasKey(s => s.PersonId);
                entity.HasQueryFilter(s => !s.IsDeleted);
                entity.HasMany(s => s.Players).WithMany(s => s.Coaches);
                entity.HasMany(s => s.Teams).WithMany(s => s.Coaches);
                entity.HasData(new List<Coach> 
                {
                    new Coach
                    {
                        ContactEmail = "timothylindsay.ns1@gmail.com",
                        ContactPhone = "3182451296",
                        Name = "Timothy Lindsay",
                        PersonId = 1,
                    },
                    new Coach
                    {                                               
                        Name = "Doug Smith",
                        PersonId = 2,
                    } 
                });
            });

            builder.Entity<Director>(entity =>
            {
                entity.ToTable("Director");
                entity.HasKey(s => s.PersonId);
                entity.HasQueryFilter(s => !s.IsDeleted);
                entity.HasMany(s => s.Tournaments).WithOne(s => s.Director);
                entity.HasOne(s => s.Club).WithMany(s => s.Directors);
                entity.HasData(new Director
                {
                    Name = "Nick Artigue",
                    PersonId = 1,
                });
            });

            builder.Entity<ExcludedGameDate>(entity =>
            {
                entity.ToTable("ExcludedGameDate");
                entity.HasKey(s => s.ExcludedGameDateId);
                entity.HasQueryFilter(s => !s.IsDeleted);
                entity.HasOne(s => s.Team).WithMany(s => s.ExcludedGameDates);
                entity.HasData(new ExcludedGameDate
                {
                    ExcludedGameDateId = 1,
                    ExcludedDate = new DateTime(2025, 4, 20),
                    ExcludedTimeStart = null,
                    ExcludedTimeEnd = null,
                });
            });

            builder.Entity<Game>(entity =>
            {
                entity.ToTable("Game");
                entity.HasKey(s => s.GameId);
                entity.HasQueryFilter(s => !s.IsDeleted);
                entity.HasOne(s => s.Field).WithMany(s => s.Games);
                entity.HasOne(s => s.League).WithMany(s => s.Games);
            });

            builder.Entity<Field>(entity =>
            {
                entity.ToTable("Field");
                entity.HasKey(s => s.FieldId);
                entity.HasQueryFilter(s => !s.IsDeleted);
                entity.HasMany(s => s.Tournaments).WithMany(s => s.Fields);
                entity.HasMany(s => s.Leagues).WithMany(s => s.Fields);
                entity.HasOne(s => s.Location).WithMany(s => s.Fields);
                entity.HasData(new Field
                {
                    Name = "NELSA",
                    FieldId = 1,
                    IsOpenFriday = true,
                    IsOpenMonday = true,
                    IsOpenSaturday = true,
                    IsOpenSunday = true,
                    IsOpenThursday = true,
                    IsOpenTuesday = true,
                    IsOpenWednesday = true,                  
                });
            });

            builder.Entity<League>(entity =>
            {
                entity.ToTable("League");
                entity.HasKey(s => s.LeagueId);
                entity.HasQueryFilter(s => !s.IsDeleted);
                entity.HasMany(s => s.Seasons).WithMany(s => s.Leagues);
                entity.HasMany(s => s.Teams).WithOne(s => s.League);
                entity.HasMany(s => s.Fields).WithMany(s => s.Leagues);
                entity.HasOne(s => s.Club).WithMany(s => s.Leagues);
                entity.HasData(new League
                {
                    AgeGroup = "9-10",
                    AgeGroupEarliestDate = new DateTime(2015, 1, 1),
                    AgeGroupLatestDate = new DateTime(2016, 12, 31),
                    EndDate = new DateTime(2025,4,1),
                    Gender = "Male",
                    Name = "2015-2016 Boys Recreational",
                    StartDate = new DateTime(2024, 9, 1),     
                    GameLengthWindow = 90,
                    EarliestGameTimeHourSaturday = 9,
                    EarliestGameTimeMinuteSaturday = 0,
                    EarliestGameTimeHourSunday = 13,
                    EarliestGameTimeMinuteSunday = 0,
                    EarliestGameTimeHourWeekday = 17,
                    EarliestGameTimeMinuteWeekday = 45,
                    PlayEachTimeCount = 1,
                    DailyGamesPerFieldSaturday = 3,
                    DailyGamesPerFieldSunday = 1,
                    DailyGamesPerFieldWeekday = 1,
                    LeagueId = 1                 
                });
            });

            builder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");
                entity.HasKey(s => s.LocationId);
                entity.HasQueryFilter(s => !s.IsDeleted);
                entity.HasMany(s => s.Fields).WithOne(s => s.Location);
                entity.HasOne(s => s.Club).WithMany(s => s.Locations);
                entity.HasData(new Location
                {
                    IsOpenFriday = true,
                    IsOpenMonday = true,
                    IsOpenSaturday = true,
                    IsOpenSunday = true,
                    IsOpenThursday = true,
                    IsOpenTuesday = true,
                    IsOpenWednesday = true,
                    Name = "NELSA (Chennault)",
                    LocationId = 1,
                });
            });

            builder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");
                entity.HasKey(s => s.PersonId);
                entity.HasQueryFilter(s => !s.IsDeleted);
                entity.HasMany(s => s.Coaches).WithMany(s => s.Players);
                entity.HasMany(s => s.AlertContacts).WithMany(s => s.Players);
                entity.HasMany(s => s.Teams).WithMany(s => s.Players);
                entity.HasData(new Player
                {
                    Name = "Micah Lindsay",
                    PersonId = 1,
                    ContactEmail = "timothylindsay.ns1@gmail.com",
                    ContactPhone = "3182451296",
                });
            });

            builder.Entity<Referee>(entity =>
            {
                entity.ToTable("Referee");
                entity.HasKey(s => s.PersonId);
                entity.HasQueryFilter(s => !s.IsDeleted);
                entity.HasMany(s => s.Seasons).WithMany(s => s.Referees);
                entity.HasMany(s => s.Leagues).WithMany(s => s.Referees);
            });

            builder.Entity<Season>(entity =>
            {
                entity.ToTable("Season");
                entity.HasKey(s => s.SeasonId);
                entity.HasQueryFilter(s => !s.IsDeleted);
                entity.HasOne(s => s.Club).WithMany(s => s.Seasons);
                entity.HasMany(s => s.Leagues).WithMany(s => s.Seasons);
                entity.HasMany(s => s.Referees).WithMany(s => s.Seasons);
                entity.HasData(new Season
                {
                    EndDate = new DateTime(2025, 4, 1),
                    IsOpenFriday = true,
                    IsOpenMonday = true,
                    IsOpenSaturday = true,
                    IsOpenSunday = true,
                    IsOpenThursday = true,
                    IsOpenTuesday = true,
                    IsOpenWednesday = true,
                    StartDate = new DateTime(2025,2,17),
                    SeasonId = 1
                });
            });

            builder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");
                entity.HasKey(s => s.TeamId);
                entity.HasQueryFilter(s => !s.IsDeleted);
                entity.HasOne(s => s.League).WithMany(s => s.Teams);
                entity.HasMany(s => s.Seasons).WithMany(s => s.Teams);
                entity.HasMany(s => s.Players).WithMany(s => s.Teams);
                entity.HasMany(s => s.Coaches).WithMany(s => s.Teams);
                entity.HasMany(s => s.Tournaments).WithMany(s => s.Teams);
                entity.HasData(new Team
                {
                    Name = "Smith/Lindsay",
                    TeamId = 1,
                    ShirtColorChosen = "Navy Striped",
                    ShortsColorChosen = "Black",
                });
            });

            builder.Entity<Tournament>(entity =>
            {
                entity.ToTable("Tournament");
                entity.HasKey(s => s.TournamentId);
                entity.HasQueryFilter(s => !s.IsDeleted);
                entity.HasMany(s => s.Fields).WithMany(s => s.Tournaments);
                entity.HasMany(s => s.Teams).WithMany(s => s.Tournaments);
                entity.HasOne(s => s.Location).WithMany(s => s.Tournaments);
                entity.HasData(new Tournament
                {
                    TournamentName = "End of Season Recreational",
                    TournamentId = 1,
                    EndDate = new DateTime(2025, 4, 1),
                    StartDate = new DateTime(2025 ,4 ,1),
                });
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
