using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Rauthor.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Poem> Poems { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;" +
                                    "UserId=bearpro;" +
                                    "Password=maslovpider228;" +
                                    "database=rauthor;");
        }
        public User GetUser(string login)
        {
            return this.Users.FirstOrDefault(u => u.Login == login);
        }
    }
}
