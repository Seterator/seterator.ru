using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
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
            Database.EnsureCreated();
        }

        public User GetUser(string login)
        {
            return this.Users.FirstOrDefault(u => u.Login == login);
        }
    }
}
