using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rauthor.Models;

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

        [Authorize(Roles = "User")]
        [HttpGet]
        public IEnumerable<Competition> Get()
        {
            return database.Competitions;
        }

        [Authorize(Roles = "User")]
        [HttpGet("{guid}", Name = "Get")]
        public string Get(Guid guid)
        {
            var value = database.Competitions.Include(x => x.Participants).Where(x => x.Guid == guid).Single();
            value.Participants = value.Participants.Select(x => { x.Competition = null; return x; }).ToList();
            return Newtonsoft.Json.JsonConvert.SerializeObject(value);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost]
        public IActionResult Post([FromBody] ViewModels.Api.Competition value)
        {
            var competition = Competition.FromApiViewModel(value);
            database.Competitions.Add(competition);
            database.SaveChanges();
            return Ok();
        }
        
        [Authorize(Roles = "Admin, Manager")]
        [HttpPut("{guid}")]
        public IActionResult Put(Guid guid, [FromBody] ViewModels.Api.Competition value)
        {
            var oldValue = database.Competitions.Where(x => x.Guid == guid).Single();
            value.Guid = guid;
            database.Entry<Competition>(oldValue).CurrentValues.SetValues(Competition.FromApiViewModel(value));
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
