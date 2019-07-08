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
            var participant = new Participant()
            {
                CompetitionGuid = competition.Guid,
                UserGuid = database.Users.First(u => u.Login == User.Identity.Name).Guid
            };
            //HttpContext.Session.SetString("accepting", JsonConvert.SerializeObject(participant,
            //                                                                       type: typeof(Participant),
            //                                                                       settings: default));
            HttpContext.Session.Set<Participant>("accepting", participant);
            return View(participant);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Become()
        {
            //Participant participant = JsonConvert.DeserializeObject(value: HttpContext.Session.GetString("accepting"),
            //                                                        type: typeof(Participant)) as Participant;

            Participant participant = HttpContext.Session.Get<Participant>("accepting");
            database.Participants.Add(participant);
            database.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}