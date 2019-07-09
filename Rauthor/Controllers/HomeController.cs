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
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
