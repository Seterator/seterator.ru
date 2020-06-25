using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using Seterator.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Seterator.Services;
using Microsoft.AspNetCore.Http;

namespace Seterator.UnitTests.Controllers.Api
{
    public class Competition
    {
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
                var controller = new Seterator.Controllers.Api.CompetitionController(db);

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
