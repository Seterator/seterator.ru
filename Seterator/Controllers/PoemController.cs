﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seterator.Models;
using Seterator.Services;
using Seterator.ViewModels;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Seterator.Controllers
{
    public class PoemController : Controller
    {
        private readonly DatabaseContext database;
        public PoemController(DatabaseContext database)
        {
            this.database = database;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ViewModels.PoemModel poem)
        {
            Contract.Assert(poem != null);
            if (ModelState.IsValid)
            {
                database.Poems.Add(new Poem()
                {
                    ParticipantGuid = database.GetUser(User.Identity.Name).Guid,
                    Text = poem.Text
                });
                await database.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction("Index", "Poem");
            }
            return View(poem);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<UserPoemModel> poems = database.Poems
                .Include(p => p.Author)
                .Include(p => p.Author.Competition)
                .Where(p => p.Author.UserGuid == HttpContext.Session.Get<User>("user").Guid)
                .Select(p => new UserPoemModel
                {
                    AuthorName = User.Identity.Name,
                    CompetitionTitle = p.Author.Competition.Title,
                    PoemText = p.Text,
                    PoemGuid = p.Guid
                });
            return View(poems);
        }

        public IActionResult Details(System.Guid guid)
        {
            Poem poem;
            poem = database.Poems.First((c) => c.Guid == guid);
            ViewData["Poem title"] = poem.Title;
            ViewData["Poem text"] = poem.Text;
            ViewData["Poem guid"] = guid;

            //Participant participant;
            //User user;
            var participant = database.Participants.Include(x => x.User).First((c) => c.Guid == poem.ParticipantGuid);
            ViewData["Participant login"] = participant.User.Login;
            ViewData["Participant status"] = "Статус не установлен";
            return View();
        }
    }
}