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
    [Authorize(Roles = "User")]
    public class ProfileController : Controller
    {
        DatabaseContext database;
        public ProfileController(DatabaseContext database)
        {
            this.database = database;
        }
        [Authorize]
        public IActionResult Index()
        {
            User user = HttpContext.Session.Get<User>("user");
            ProfileModel profile = ProfileModel.ReadFromDatabase(user.Guid, database);
            return View(profile);
        }
    }
}
