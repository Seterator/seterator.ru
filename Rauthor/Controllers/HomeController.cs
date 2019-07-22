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
            var closing = database.Competitions
                .Include("Participants")
                .Where(c => c.StartDate > DateTime.Now)
                .OrderByDescending(c => c.StartDate)
                .Take(2);
            var resulting = database.Competitions
                .Include("Participants")
                .Where(c => c.StartDate < DateTime.Now && DateTime.Now < c.EndDate)
                .OrderBy(c => c.EndDate)
                .Take(2);
            var model = new RelevantCompetitionsModel()
            {
                ClosingApplyCompetitions = closing,
                IncomingResultCompetitions = resulting
            };
            return View(model);
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
