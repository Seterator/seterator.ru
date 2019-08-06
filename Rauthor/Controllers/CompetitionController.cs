using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Rauthor.Models;
using Rauthor.Services;

namespace Rauthor.Controllers
{
    public class CompetitionController : Controller
    {
        public IActionResult Details([FromRoute] Guid guid, [FromServices] DatabaseContext db)
        {
            Contract.Assert(db != null);
            var competition = db.Competitions.Include(c => c.Participants).FirstOrDefault(c => c.Guid == guid);
            db.Users.Where(user => competition.Participants.Any(p => p.UserGuid == user.Guid)).Load();
            db.Poems.Where(poem => competition.Participants.Any(p => p.Guid == poem.ParticipantGuid)).Load();
            ViewData["Title"] = competition.Titile;
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
    }
}