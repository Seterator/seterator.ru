#nullable enable
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rauthor.Models;
using Rauthor.Services;
using Rauthor.ViewModels.Api;
using System;
using System.Linq;

namespace Rauthor.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        DatabaseContext database;

        public ParticipantController(DatabaseContext db)
        {
            database = db;
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult Post([FromBody] ViewModels.Api.ParticipantPost value)
        {
            var competitionExists = database.Competitions.SingleOrDefault(x => x.Guid == value.Guid) != null;
            if (competitionExists)
            {
                var participant = new Models.Participant()
                {
                    Guid = Guid.NewGuid(),
                    CompetitionGuid = value.Guid,
                    CreateDate = DateTime.Now,
                    Nickname = value.Nickname,
                    Status = Models.ParticipantStatus.New,
                    UserGuid = HttpContext.Session.Get<User>("user").Guid,
                };
                var poem = new Poem()
                {
                    Guid = Guid.NewGuid(),
                    ParticipantGuid = participant.Guid,
                    Text = value.Poem,
                    Title = value.Title
                };
                database.Database.BeginTransaction();
                database.Participants.Add(participant);
                database.Poems.Add(poem);
                database.Database.CommitTransaction();
                var result = new ParticipantPostResult() 
                { 
                    CreatedParticipantGuid = participant.Guid,
                    PoemGuids = { poem.Guid }
                };
                return Ok(result);
            }
            else
            {
                return BadRequest("Такого соревнования не существует.");
            }
        }
    }
}
