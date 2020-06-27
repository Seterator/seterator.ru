using Seterator.Models.Api;
using System.Linq;
using Xunit;

namespace Seterator.UnitTests.Controllers.Api
{
    public class Account
    {
        // [Fact]
        // public void RegisterCorrect()
        // {
        //     var dataset = Database.Setup();
        //     using (var db = Database.Use(dataset))
        //     {
        //         var controller = new Seterator.Controllers.Api.AccountController(db);
        //         var result = controller.Post(new Login() { Method = "register", Password = "password", Login = "sample_user" });
        //         Assert.Equal(result.Result, "accept");
        //         db.Users.Single(x => x.Login == "sample_user");
        //     }
        // }

        // [Fact]
        // public void LoginCorrect()
        // {
        //     var dataset = Database.Setup();
        //     using (var db = Database.Use(dataset))
        //     {
        //         var controller = new Seterator.Controllers.Api.AccountController(db);
        //         controller.Post(new Login() { Method = "register", Password = "password", Login = "sample_user" });
        //         var result = controller.Post(new Login() { Method = "login", Password = "password", Login = "sample_user" });
        //         Assert.Equal(result.Result, "accept");
        //     }
        // }
    }
}
