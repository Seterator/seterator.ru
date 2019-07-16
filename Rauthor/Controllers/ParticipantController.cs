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

namespace Rauthor.Controllers
{
    public class ParticipantController : Controller
    {
        readonly DatabaseContext database;
        public ParticipantController(DatabaseContext database)
        {
            this.database = database;
        }
        public IActionResult Index()
        {
            return StatusCode(404);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Become(string id)
        {
            Competition competition;
            var guid = new Guid(id);
            competition = database.Competitions.First((c) => c.Guid == guid);
            ViewData["Competition title"] = competition.Titile;
            ViewData["Competition guid"] = id;
            return View();
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
                    Text = poem.Text
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
    }
}