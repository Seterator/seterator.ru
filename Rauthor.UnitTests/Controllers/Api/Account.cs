using Rauthor.Models.Api;
using System.Linq;
using Xunit;

namespace Rauthor.UnitTests.Controllers.Api
{
    public class Account
    {
        [Fact]
        public void RegisterCorrect()
        {
            Database.ConfigureInstanceAndData();
            using (var db = Database.Instance)
            {
                var controller = new Rauthor.Controllers.Api.AccountController(db);
                var result = controller.Post(new Login() { Method = "register", Password = "password", Username = "sample_user" });
                Assert.Equal(result.Result, "accept");
                db.Users.Single(x => x.Login == "sample_user");
            }
        }

        [Fact]
        public void LoginCorrect()
        {
            Database.ConfigureInstanceAndData();
            using (var db = Database.Instance)
            {
                var controller = new Rauthor.Controllers.Api.AccountController(db);
                controller.Post(new Login() { Method = "register", Password = "password", Username = "sample_user" });
                var result = controller.Post(new Login() { Method = "login", Password = "password", Username = "sample_user" });
                Assert.Equal(result.Result, "accept");
            }
        }
    }
}
