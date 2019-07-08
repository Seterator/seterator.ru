using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySqlX.XDevAPI;
using Rauthor.Models;

namespace Rauthor.Controllers
{
    public class HomeController : Controller
    {
        readonly DatabaseContext database;
        public HomeController(DatabaseContext database)
        {
            this.database = database;
        }
        public IActionResult Index()
        {
            database.SaveChanges();

            return View(database.Competitions.Include("Participants"));
        }
        [Authorize]
        public IActionResult Privacy()
        {
            ViewBag.IN = User.Identity.Name;
                //User.Claims.FirstOrDefault(c => c.Type == "GUID").Value;
                //new Guid(Request.HttpContext.Session.Get("User GUID")).ToString();
                //Request.HttpContext.Session.GetUserGuid();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
