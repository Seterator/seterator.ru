using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rauthor.Models;
using Newtonsoft.Json;
using MySqlX.XDevAPI;
using Microsoft.AspNetCore.Http;
using static Rauthor.Services.SessionExtensions;
using Rauthor.ViewModels;
using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Rauthor.Controllers
{
    public class ParticipantController : Controller
    {
        readonly DatabaseContext database;
        public ParticipantController(DatabaseContext database)
        {
            this.database = database;
        }

        [Authorize]
        public IActionResult Index()
        {
            var user = HttpContext.Session.Get<User>("user");
            var model = database.Participants
                .Where(p => p.UserGuid == user.Guid)
                .Include(p => p.Poems)
                .Include(p => p.Competition);
            return View(model);
        }
        /// <param name="guid">Guid соревнования, в котором предполагается участие</param>
        [Authorize]
        [HttpGet]
        public IActionResult Become(Guid guid)
        {
            Competition competition;
            competition = database.Competitions.First((c) => c.Guid == guid);
            ViewData["Competition title"] = competition.Titile;
            ViewData["Competition guid"] = guid;
            return View();
        }
        
        public IActionResult Edit(Guid guid)
        {
            return View(database.Participants.Include(p => p.Poems).Include(p=>p.Competition).First(p => p.Guid == guid));
        }

        /// <summary>
        /// Становясь участником, пользователь отправляет своё произведение.
        /// </summary>
        /// <param name="guid">Guid соревнования</param>
        [Authorize]
        [HttpPost]
        public IActionResult Become([FromRoute] Guid guid, [FromForm] PoemModel poem)
        {
            Contract.Assert(poem != null);
            if (ModelState.IsValid)
            {
                var participant = new Participant()
                {
                    CompetitionGuid = guid,
                    UserGuid = HttpContext.Session.Get<User>("user").Guid
                };
                database.Participants.Add(participant);

                var poemRecord = new Poem()
                {
                    ParticipantGuid = participant.Guid,
                    Text = poem.Text,
                    Title = poem.Title
                };
                database.Poems.Add(poemRecord);
                database.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Неверные данные");
                return View();
            }
        }

        [Authorize]
        public IActionResult Review()
        {
            if (User.HasClaim(ClaimTypes.Role, "Moderator"))
            {
                return View(database.Participants
                    .Include(p => p.Competition)
                    .Include(p => p.Poems)
                    .FirstOrDefault(p => p.Status == ParticipantStatus.New || p.Status == ParticipantStatus.Updated));
            }
            else
            {
                return StatusCode((int)HttpStatusCode.Forbidden);
            }
        }

        /// <remarks>
        /// Создаёт запись в таблице оценок, если её ещё нет.
        /// Устанавливает значение VoteState в Up.
        /// </remarks>
        [Authorize]
        public IActionResult Upvote(Guid guid)
        {
            var user = HttpContext.Session.Get<User>("user");
            var participant = database.Participants.FirstOrDefault(p => p.Guid == guid);
            database.Entry(participant).Collection(x => x.Votes).Load();
            var vote = participant.Votes?.FirstOrDefault(v => v.UserGuid == user.Guid);
            if (vote == null)
            {
                vote = new VoteOfUser()
                {
                    UserGuid = user.Guid,
                    ParticipantGuid = participant.Guid,
                    VoteState = VoteState.Up
                };
                database.VotesOfUsers.Add(vote);
            }
            else
            {
                vote.VoteState = VoteState.Up;
            }
            database.SaveChanges();
            return StatusCode((int)HttpStatusCode.OK);
        }

        [Authorize]
        public IActionResult Downvote(Guid guid)
        {
            var user = HttpContext.Session.Get<User>("user");
            var participant = database.Participants.FirstOrDefault(p => p.Guid == guid);
            database.Entry(participant).Collection(x => x.Votes).Load();
            var vote = participant.Votes?.FirstOrDefault(v => v.UserGuid == user.Guid);
            if (vote == null)
            {
                vote = new VoteOfUser()
                {
                    UserGuid = user.Guid,
                    ParticipantGuid = participant.Guid,
                    VoteState = VoteState.None
                };
                database.VotesOfUsers.Add(vote);
            }
            else
            {
                vote.VoteState = VoteState.None;
            }
            database.SaveChanges();
            return StatusCode((int)HttpStatusCode.OK);
        }

        [Authorize]
        public IActionResult Accept(Guid guid)
        {
            if (User.HasClaim(ClaimTypes.Role, "Moderator"))
            {
                database.Participants.FirstOrDefault(p => p.Guid == guid).Status = ParticipantStatus.Approved;
                database.SaveChangesAsync();
                return RedirectToAction("Review");
            }
            else
            {
                return StatusCode((int)HttpStatusCode.Forbidden);
            }
        }
        [Authorize]
        public IActionResult Reject(Guid guid)
        {
            database.Participants.FirstOrDefault(p => p.Guid == guid).Status = ParticipantStatus.Rejected;
            database.SaveChangesAsync();
            return RedirectToAction("Review");
        }

    }
}