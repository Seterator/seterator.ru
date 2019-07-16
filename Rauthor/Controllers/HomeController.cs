using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
