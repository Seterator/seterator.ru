﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Seterator.Models;
using Seterator.Services;
using Seterator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seterator.Controllers
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
            User user = null;//HttpContext.Session.Id; //.Get<User>("user");
            var profile = ProfileModel.ReadFromDatabase(user.Guid, database);
            return View(profile);
        }

        /// <summary>
        /// Возвращает базовое представление профиля пользователя по короткой ссылке.
        /// </summary>
        /// <param name="shortLink">Короткая ссылка на профиль пользователя.</param>
        /// <remarks>
        /// Большой Order для маршрута установлен для того, чтобы понизить приоритет сопоставления.
        /// Если не устанавливать такой Order - будет происходить коллизия между маршрутами, и при запросе
        /// `/Profile` будет использоваться не маршрут с методом Index по умолчанию, а маршрут с {shortLink},
        /// `Profile` будет восприниматься как короткая ссылка для профиля.
        /// </remarks>
        //[Route("{shortLink}", Order = 150)]
        [HttpGet("{shortLink}", Name = "Short profile link", Order = 150)]
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
                return NotFound($"Профиль '{shortLink}' не найден");
            }
            
        }
        [HttpGet]
        [Route("[controller]/{guid}", Name = "Profile guid link")]
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
