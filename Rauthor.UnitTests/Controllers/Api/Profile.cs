using Microsoft.AspNetCore.Mvc;
using Rauthor.Models;
using Rauthor.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Rauthor.UnitTests.Controllers.Api
{
    public class Profile
    {
        [Fact]
        public void ListProfilesWorking()
        {
            var dataset = Database.Setup();
            using (var db = Database.Use(dataset))
            {
                var controller = new Rauthor.Controllers.Api.ProfileController(db);
                var userGuid = db.Users.First().Guid;
                var result = controller.GetProfiles(new ProfileRequest() 
                { 
                    Guid = userGuid, 
                    Type = ProfileRequest.ProfileRequestType.list 
                });
                Assert.IsType<OkObjectResult>(result);
                var okResult = result as OkObjectResult;
                var profiles = okResult.Value as IEnumerable<UserProfile>;
                Assert.All(profiles, (profile) =>
                {
                    Assert.IsType<UserProfile>(profile);
                    Assert.NotNull(profile);
                });
            }
        }
        
        [Fact]
        public void ConcreteProfileWorking()
        {
            var dataset = Database.Setup();
            using (var db = Database.Use(dataset))
            {
                var controller = new Rauthor.Controllers.Api.ProfileController(db);
                var roleGuid = db.Roles.First().Guid;
                var result = controller.GetProfiles(new ProfileRequest() 
                { 
                    Guid = roleGuid, 
                    Type = ProfileRequest.ProfileRequestType.concrete 
                });
                Assert.IsType<OkObjectResult>(result);
                Assert.IsType<UserProfile>((result as OkObjectResult).Value);
                Assert.NotNull((result as OkObjectResult).Value);
            }
        }
    }
}
