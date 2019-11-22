using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rauthor.Models;
using Rauthor.Services;
using Rauthor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.Controllers
{
    public class ProfileController : Controller
    {
        DatabaseContext database;
        public ProfileController(DatabaseContext database)
        {
            this.database = database;
        }
        [Authorize(Roles = "User")]
        public IActionResult Index()
        {
            User user = HttpContext.Session.Get<User>("user");
            var profile = ProfileModel.ReadFromDatabase(user.Guid, database);
            return View(profile);
        }

        [HttpGet]
        [Route("{shortLink}")]
        public IActionResult Profile(string shortLink)
        {
            try
            {
                Guid user_guid = database.Profiles
                    .Join(database.Roles, profile => profile.RoleGuid, role => role.Guid, (profile, role) => new { profile, role })
                    .Join(database.Users, t => t.role.UserGuid, user => user.Guid, (t, user) => new { t.profile, t.role, user })
                    .Single(x => x.profile.ShortLink == shortLink)
                    .user.Guid;
                var profile = ProfileModel.ReadFromDatabase(user_guid, database);
                return View("Index", profile);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            
        }
        [HttpGet]
        [Route("[controller]/{guid}")]
        public IActionResult Profile(Guid guid)
        {
            try
            {
                var profile = ProfileModel.ReadFromDatabase(guid, database);
                return View("Index", profile);
            }
            catch (NullReferenceException e)
            {
                return NotFound();
            }
        }

    }
}
