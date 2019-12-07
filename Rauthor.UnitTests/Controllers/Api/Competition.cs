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
                    Prizes = new List<Prize>()
                    {
                        new Prize() { BeginPlace = 1, EndPlace = 1, Value = "First place prize"},
                        new Prize() { BeginPlace = 2, EndPlace = 10, Value = "Top-10 prize"}
                    },
                    ShortDescription = "Sample short description",
                    Title = "Competition {997DD1CD-FC9C-4A2A-AAE2-9EB0AA668CAD}"
                };
                controller.Post(competition);
            }

            using (var db = Database.Use(dataset))
            {
                var competition = db.Competitions
                    .Include(x => x.Categories)
                    .Include(x => x.Constraints)
                    .Include(x => x.Jury)
                    .Include(x => x.Prizes)
                    .Where(x => x.Title == "Competition {997DD1CD-FC9C-4A2A-AAE2-9EB0AA668CAD}")
                    .Single();
                var constrains = db.CompetitionConstraints.Where(x => x.CompetitionGuid == competition.Guid);
                Assert.NotEqual(new Guid(), competition.Guid);
                Assert.Contains("Sample1", constrains.Select(x => x.CheckedValue));
                Assert.Contains("Sample2", constrains.Select(x => x.CheckedValue));
                Assert.Contains("First place prize", competition.Prizes.Select(x => x.Value));
                Assert.Contains("Top-10 prize", competition.Prizes.Select(x => x.Value));
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
                    .Include(x => x.Prizes)
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
                    Prizes = competition.Prizes.Append(new Prize() {BeginPlace = 100, EndPlace = 100, Value = "Looser prize" }).ToList(),
                    Title = competition.Title,
                    ShortDescription = competition.ShortDescription,
                };
                controllerResult = controller.Put(guid, updated);
            }

            Assert.IsType<OkResult>(controllerResult);
            using (var db = Database.Use(dataset))
            {
                var competition = db.Competitions
                    .Include(x => x.Prizes)
                    .Single(x => x.Guid == guid);
                Assert.Equal("[Updated]", competition.Description);
                Assert.Contains("Looser prize", competition.Prizes.Select(x => x.Value));
                Assert.Contains("Looser prize", db.Prizes.Where(x => x.CompetitionGuid == competition.Guid).Select(x => x.Value));
            }
        }
    }
}
