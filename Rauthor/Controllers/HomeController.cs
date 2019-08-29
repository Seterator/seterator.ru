using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rauthor.Models;
using Rauthor.ViewModels;
using System;
using System.Linq;

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
            var competition = database.Competitions.Include("Participants");
            return View(competition);
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
