using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Seterator.Models;

namespace Seterator
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Poem> Poems { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<ParticipantAssessment> ParticipantAssessments { get; set; }
        public DbSet<CompetitionCategory> CompetitionCategories { get; set; }
        public DbSet<CompetitionConstraint> CompetitionConstraints { get; set; }
        public DbSet<CompetitionRelCategory> CompetitionRelCategories { get; set; }
        public DbSet<CompetitionRelJury> CompetitionRelJuries { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Prize> Prizes { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Contract.Assert(modelBuilder != null);
            
            modelBuilder.Entity<User>()
                .Property("PasswordHash")
                .HasConversion(new ValueConverter<IReadOnlyCollection<byte>, byte[]>(
                    m => m.ToArray(),
                    p => p as IReadOnlyCollection<byte>
                ));

            modelBuilder.Entity<CompetitionRelCategory>()
                .HasKey(x => new { x.CategoryGuid, x.CompetitionGuid });

            modelBuilder.Entity<CompetitionRelJury>()
                .HasKey(x => new { x.CompetitionGuid, x.JuryUserGuid });

            modelBuilder.Entity<CompetitionRelCategory>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Competitions)
                .HasForeignKey(x => x.CategoryGuid);

            modelBuilder.Entity<CompetitionRelCategory>()
                .HasOne(x => x.Competition)
                .WithMany(x => x.Categories)
                .HasForeignKey(x => x.CompetitionGuid);

            modelBuilder.Entity<CompetitionRelJury>()
                .HasOne(x => x.Competition)
                .WithMany(x => x.Jury)
                .HasForeignKey(x => x.CompetitionGuid);

            

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null) throw new NullReferenceException();
            optionsBuilder.EnableDetailedErrors()
                          .EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        public User GetUser(string login)
        {
            return this.Users.FirstOrDefault(u => u.Login == login);
        }
    }
}
