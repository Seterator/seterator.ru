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
            return PartialView(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Become(Guid id)
        {
            Competition competition;
            competition = database.Competitions.First((c) => c.Guid == id);
            ViewData["Competition title"] = competition.Titile;
            ViewData["Competition guid"] = id;
            return View();
        }
        
        public IActionResult Edit(Guid id)
        {
            var guid = id;
            return View(database.Participants.Include(p => p.Poems).First(p => p.Guid == guid));
        }

        /// <summary>
        /// Становясь участником, пользователь отправляет своё произведение.
        /// </summary>
        [Authorize]
        [HttpPost]
        public IActionResult Become([FromRoute] string id, [FromForm] PoemModel poem)
        {
            Contract.Assert(poem != null);
            if (ModelState.IsValid)
            {
                var participant = new Participant()
                {
                    CompetitionGuid = new Guid(id),
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
                    .FirstOrDefault(p => !p.Approved));
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
                database.Participants.FirstOrDefault(p => p.Guid == guid).Approved = true;
                database.SaveChangesAsync();
                return RedirectToAction("Review");
            }
            else
            {
                return StatusCode((int)HttpStatusCode.Forbidden);
            }
        }
        public IActionResult Reject(Guid guid)
        {
            return RedirectToAction("Review");
        }

    }
}