using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using Xunit;

namespace Seterator.UnitTests.Database
{
    [Trait("Category", "DatabaseTest")]
    public class DatabaseTest
    {
        protected IConfiguration Config => new ConfigurationBuilder()
            .AddUserSecrets<Startup>()
            .Build();
        protected DbContextOptions<DatabaseContext> Options => new DbContextOptionsBuilder<DatabaseContext>()
            .UseMySql(Environment.GetEnvironmentVariable("MYSQL_CONN")).Options;
        protected IMemoryCache Cache => null;
        protected DatabaseContext Database => new DatabaseContext(Options, false);
    }
}
