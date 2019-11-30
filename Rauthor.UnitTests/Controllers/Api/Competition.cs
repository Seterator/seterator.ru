using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using Rauthor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Rauthor.UnitTests.Controllers.Api
{
    public class Competition
    {
        [Fact]
        public void PostingNewCompetitionWorking()
        {
            var newCompetitionGuid = Guid.NewGuid();
            var dataset = Database.Setup();
            using (var db = Database.Use(dataset))
            {
                var controller = new Rauthor.Controllers.Api.CompetitionController(db);
                var competition = new ViewModels.Api.Competition()
                {
                    ManagerSocialLinks = new List<string>() { "vk.com", "twitter.com"},
                    Categories = new List<Guid>() { db.CompetitionCategories.First().Guid },
                    Constraints = new List<CompetitionConstraint>() 
                    { 
                        new CompetitionConstraint() { CheckedValue = "Sample1", Max = 10, Min = 5 },
                        new CompetitionConstraint() { CheckedValue = "Sample2", Max = 10, Min = 5 }
                    },
                    JuryGuids = new List<Guid>() { db.Roles.First(x => x.UserRole == UserRole.Jury).Guid },
                    Description = "Sample description",
                    EndDate = new DateTime(),
                    PublicationDate = new DateTime(),
                    StartDate = new DateTime(),
                    ManagerEmail = "sample@email",
                    ManagerPhoneNumber = "+sample",
                    Prizes = "null",
                    ShortDescription = "Sample short description",
                    Title = "Sample title"
                };
                controller.Post(competition);
            }

            using (var db = Database.Use(dataset))
            {
                var competition = db.Competitions
                    .Include(x => x.Categories)
                    .Include(x => x.Constraints)
                    .Include(x => x.Jury)
                    .Last();
                Assert.NotEqual(new Guid(), competition.Guid);
                Assert.Contains("Sample1", competition.Constraints.Select(x => x.CheckedValue));
                Assert.Contains("Sample2", competition.Constraints.Select(x => x.CheckedValue));
                Assert.True(competition.Jury.Select(x => x.Jury).Count() > 0);
                Assert.True(competition.Categories.Select(x => x.Category).Count() > 0);
                
            }
        }

        [Fact]
        public void UpdatingCompetitionWorking()
        {
            Database.Setup();
            Guid guid;
            Microsoft.AspNetCore.Mvc.IActionResult controllerResult;
            var dataset = Database.Setup();
            using (var db = Database.Use(dataset))
            {
                var competition = db.Competitions
                    .Include(x => x.Constraints)
                    .Include(x => x.Categories)
                    .First();
                guid = competition.Guid;
                var controller = new Rauthor.Controllers.Api.CompetitionController(db);

                var updated = new ViewModels.Api.Competition()
                {
                    Categories = competition.Categories.Select(x => x.CategoryGuid).ToList(),
                    Constraints = competition.Constraints,
                    Description = $"[Updated]",
                    EndDate = competition.EndDate,
                    StartDate = competition.StartDate,
                    JuryGuids = competition.Jury.Select(x => x.JuryUserGuid).ToList(),
                    Prizes = competition.Prizes,
                    Title = competition.Title,
                    ShortDescription = competition.ShortDesctiption,
                };
                controllerResult = controller.Put(guid, updated);
            }

            Assert.IsType<OkResult>(controllerResult);
            using (var db = Database.Use(dataset))
            {
                var competition = db.Competitions.Single(x => x.Guid == guid);
                Assert.Equal("[Updated]", competition.Description);
            }
        }
    }
}
