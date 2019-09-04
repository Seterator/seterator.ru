using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
namespace Rauthor.Models
{
    public class DatabaseContext : DbContext
    {
        private string conectionString;
        private IMemoryCache cache;
        public DbSet<User> Users { get; set; }
        public DbSet<Poem> Poems { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<VoteOfUser> VotesOfUsers { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration, IMemoryCache cache) : base(options)
        {
            conectionString = configuration.GetConnectionString("Local MySQL");
            this.cache = cache;
            Database.SetCommandTimeout(TimeSpan.FromSeconds(60)); // NOTE Большой таймаут для работы с херовым интернетом.
            Database.EnsureCreated();
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

            modelBuilder.Entity<Competition>()
                .Property<string>("conditions")
                .HasField("json");

            modelBuilder.Entity<VoteOfUser>()
                .HasKey(v => new { v.UserGuid, v.ParticipantGuid });

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null) throw new NullReferenceException();
            optionsBuilder.EnableDetailedErrors()
                          .UseMemoryCache(cache)
                          .EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        public User GetUser(string login)
        {
            return this.Users.FirstOrDefault(u => u.Login == login);
        }
    }
}
