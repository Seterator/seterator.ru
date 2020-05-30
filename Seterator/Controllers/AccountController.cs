using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Seterator.Models;
using static Seterator.Services.SessionExtensions;

namespace Seterator.Controllers
{
    public class AccountController : Controller
    {
        private readonly DatabaseContext database;
        private static readonly byte[] salt = new byte[]
        {
            0xad, 0x34, 0xff, 0x45, 0xf2, 0x12, 0x34, 0xfa,
            0xad, 0x34, 0xff, 0x45, 0xf2, 0x12, 0x34, 0xfa
        };
        public AccountController(DatabaseContext database)
        {
            this.database = database;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(ViewModels.LoginModel model)
        {
            Contract.Assert(model != null);
            if (ModelState.IsValid)
            {
                Models.User user = database.Users.Include(x => x.Roles).FirstOrDefault(u => u.Login == model.Login);
                if (user == null || !Utils.PasswordHasher.Default.Hash(model.Password).SequenceEqual(user.PasswordHash))
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }
                else
                {
                    Authenticate(user).ConfigureAwait(false);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Неправильно введены данные");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(ViewModels.RegistrationModel data)
        {
            var user = database.Users.FirstOrDefault(u => u.Login == data.Login);
            if (data.Password == null)
                data.Password = "password";
            if (user == null)
            {
                var newUser = new Models.User()
                {
                    Login = data.Login,
                    PasswordHash = Utils.PasswordHasher.Default.Hash(data.Password)
                };
                database.Users.Add(newUser);
                await database.SaveChangesAsync().ConfigureAwait(true);
                _ = Authenticate(newUser);
                return RedirectToAction("Index", "Home");
            }  
            else
            {
                ModelState.AddModelError("", "Некорректные данные");
                return View(data);
            }
        }

        public IActionResult Main()
        {
            return View();
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login));
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role.UserRole.ToString()));
            }
            ClaimsIdentity id = new ClaimsIdentity(claims:             claims,
                                                   authenticationType: "ApplicationCookie",
                                                   nameType:           ClaimsIdentity.DefaultNameClaimType,
                                                   roleType:           ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext
                .SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                             new ClaimsPrincipal(id))
                .ConfigureAwait(false);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext
                .SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme)
                .ConfigureAwait(false);
            return RedirectToAction("Index", "Home");
        }
    }
}
