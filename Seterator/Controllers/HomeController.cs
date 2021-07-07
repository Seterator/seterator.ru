using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seterator.Models;
using Seterator.ViewModels;
using System;
using System.Linq;

namespace Seterator.Controllers
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
            try
            {
                var competition = database.Competitions.Include("Participants");
                return View(competition);
            }
#pragma warning disable CA1031 // Do not catch general exception types
            catch (Exception e)
#pragma warning restore CA1031 // Do not catch general exception types
            {
                return StatusCode(500, e);
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
