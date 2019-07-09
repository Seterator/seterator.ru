using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using Rauthor.Models;

namespace Rauthor.Controllers
{
    public class PoemController : Controller
    {
        readonly DatabaseContext database;
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
            if (ModelState.IsValid)
            {
                database.Poems.Add(new Poem()
                {
                    ParticipantGuid = database.GetUser(User.Identity.Name).Guid,// П
                    Text = poem.Text
                });
                await database.SaveChangesAsync();
                return RedirectToAction("Index", "Poem");
            }
            return View(poem);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            User user = database.Users
                .Where(u => u.Login == User.Identity.Name)
                .Include(u => u.Poems)
                .FirstOrDefault();
            return View(user.Poems);
        }
    }
}