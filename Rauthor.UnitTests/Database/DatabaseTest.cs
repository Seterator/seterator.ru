using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Rauthor.UnitTests.Database
{
    public class DatabaseTest
    {
        protected IConfiguration Config => new ConfigurationBuilder()
            .AddUserSecrets<Startup>()
            .Build();
        protected DbContextOptions<DatabaseContext> Options => new DbContextOptionsBuilder<DatabaseContext>()
            .UseMySQL(Config.GetConnectionString("Local MySQL")).Options;
        protected IMemoryCache Cache => null;
        protected DatabaseContext Database => new DatabaseContext(Options);
    }
}
