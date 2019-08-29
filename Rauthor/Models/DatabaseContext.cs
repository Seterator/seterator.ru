#nullable enable
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
        public DbSet<User> Users { get; set; }
        public DbSet<Poem> Poems { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration) : base(options)
        {
            conectionString = configuration.GetConnectionString("Local MySQL");
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
