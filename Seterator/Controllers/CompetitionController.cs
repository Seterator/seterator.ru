﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Seterator.Models;
using Seterator.Services;

namespace Seterator.Controllers
{
    public class CompetitionController : Controller
    {
        DatabaseContext database;
        public CompetitionController([FromServices] DatabaseContext database)
        {
            this.database = database;
        }
        public IActionResult Details([FromRoute] Guid guid)
        {
            Contract.Assert(database != null);
            var competition = database.Competitions.Include(c => c.Participants).FirstOrDefault(c => c.Guid == guid);
            database.Users.Where(user => competition.Participants.Any(p => p.UserGuid == user.Guid)).Load();
            database.Poems.Where(poem => competition.Participants.Any(p => p.Guid == poem.ParticipantGuid)).Load();
            ViewData["Title"] = competition.Title;
            if (User.Identity.IsAuthenticated) {
                ViewData["Personal"] = true;
                var user = HttpContext.Session.Get<User>("user");
                var participant = competition.Participants.FirstOrDefault(p => p.UserGuid == user.Guid);
                ViewData["TakingPart"] = participant != null;
                if (participant != null)
                {
                    ViewData["ParticipantGuid"] = participant.Guid;
                }
            }
            else
            {
                ViewData["Personal"] = false;
            }
            return View(competition);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update(Guid guid)
        {
            var competition = database.Competitions.Where(x => x.Guid == guid).Single();
            return View(competition);
        }

        public IActionResult Delete([FromRoute] Guid guid)
        {
            var competition = database.Competitions.Where(x => x.Guid == guid).Single();
            database.Competitions.Remove(competition);
            database.SaveChanges();
            return Redirect("/");
        }
    }
}