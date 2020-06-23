using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Seterator.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using static Seterator.Services.SessionExtensions;
using Seterator.ViewModels;
using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Seterator.Controllers
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
            ViewData["Competition title"] = competition.Title;
            ViewData["Competition guid"] = guid;
            return View();
        }
        
        public IActionResult Details(Guid guid)
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
