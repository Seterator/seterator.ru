using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet]
        public IEnumerable<Competition> Get()
        {
            return database.Competitions;
        }

        [HttpGet("{guid}", Name = "Get")]
        public string Get(Guid guid)
        {
            var value = database.Competitions.Include(x => x.Participants).Where(x => x.Guid == guid).Single();
            value.Participants = value.Participants.Select(x => { x.Competition = null; return x; }).ToList();
            return Newtonsoft.Json.JsonConvert.SerializeObject(value);
        }

        [HttpPost]
        public void Post([FromBody] Competition value)
        {
            value.Guid = Guid.NewGuid();
            database.Competitions.Add(value);
            database.SaveChanges();
        }

        [HttpPut("{guid}")]
        public void Put(Guid guid, [FromBody] Competition value)
        {

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{guid}")]
        public void Delete(Guid guid)
        {
            var competition = database.Competitions.Where(x => x.Guid == guid).Single();
            database.Competitions.Remove(competition);
            database.SaveChanges();
        }
    }
}
