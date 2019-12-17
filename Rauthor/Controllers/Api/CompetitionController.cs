using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rauthor.Models;
using Rauthor.Services;

namespace Rauthor.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionController : ControllerBase
    {
        DatabaseContext database;

        public CompetitionController(DatabaseContext db)
        {
            database = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(database.Competitions
                .Include(x => x.Prizes)
                .Include(x => x.Categories));
        }

        [HttpGet("{guid}", Name = "Get")]
        public IActionResult Get(Guid guid)
        {
            var value = database.Competitions
                .Include(x => x.Participants)
                    .ThenInclude(x => x.User)
                .Include(x => x.Prizes)
                .Include(x => x.Jury)
                .Include(x => x.Categories)
                .Where(x => x.Guid == guid)
                .Single();
            var v = ViewModels.Api.Competition.FromEntity(value);
            v.Participants = v.Participants
                .Select(x => { x.Competition = null; x.User.Participants = null; return x; })
                .ToList();
            return Ok(v);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost]
        public IActionResult Post([FromBody] ViewModels.Api.Competition value)
        {
            var competition = Competition.FromApiViewModel(value);
            competition.Guid = Guid.NewGuid();
            competition.CreatorUserGuid = HttpContext.Session.Get<User>("user").Guid;
            database.Competitions.Add(competition);
            database.SaveChanges();
            return Ok();
        }
        
        [Authorize(Roles = "Admin, Manager")]
        [HttpPut("{guid}")]
        public IActionResult Put(Guid guid, [FromBody] ViewModels.Api.Competition value)
        {
            var current = database.Competitions
                .Include(x => x.Constraints)
                .Include(x => x.Categories)
                .Include(x => x.Jury)
                .Include(x => x.Prizes)
                .Where(x => x.Guid == guid)
                .Single();
            value.Guid = guid;
            var competition = Competition.FromApiViewModel(value);
            database.Entry<Competition>(current).CurrentValues.SetValues(competition);
            
            current.Categories.Clear();
            current.Constraints.Clear();
            current.Jury.Clear();
            current.Prizes.Clear();
            
            current.Categories.AddRange(competition.Categories);
            current.Constraints.AddRange(competition.Constraints);
            current.Jury.AddRange(competition.Jury);
            current.Prizes.AddRange(competition.Prizes);
            
            database.SaveChanges();
            return Ok();
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            var competition = database.Competitions.Where(x => x.Guid == guid).Single();
            database.Competitions.Remove(competition);
            database.SaveChanges();
            return Ok();
        }
    }
}
