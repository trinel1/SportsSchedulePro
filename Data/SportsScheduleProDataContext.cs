using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SportsScheduleProLibrary.Data
{
    public partial class SportsScheduleProDataContext : DbContext
    {

        public DbSet<Alert> Alerts { get; set; }
        public DbSet<AlertContact> AlertContacts { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Location> Locations { get; set; }
        //public DbSet<Person> People { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<Season> Seasons { get; set; }

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
            });

            builder.Entity<AlertContact>(entity =>
            {
                entity.ToTable("AlertContact");
                entity.HasKey(s => s.PersonId);
                entity.HasMany(s => s.Players).WithMany(s => s.AlertContacts);
                entity.HasQueryFilter(s => !s.IsDeleted);
            });

            builder.Entity<Coach>(entity =>
            {
                entity.ToTable("Coach");
                entity.HasKey(s => s.PersonId);
                entity.HasQueryFilter(s => !s.IsDeleted);
            });

            builder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");
                entity.HasKey(s => s.PersonId);
                entity.HasQueryFilter(s => !s.IsDeleted);
            });

            builder.Entity<Referee>(entity =>
            {
                entity.ToTable("Referee");
                entity.HasKey(s => s.PersonId);
                entity.HasQueryFilter(s => !s.IsDeleted);
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
