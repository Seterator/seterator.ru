using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Rauthor.Models;

namespace Rauthor.Controllers
{
    public class AccountController : Controller
    {
        DatabaseContext database;
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
        public async Task<IActionResult> Login(ViewModels.LoginModel data)
        {
            Models.User user = database.Users.FirstOrDefault(u => u.Login == data.Login);
            if (user == null)
            {
                ModelState.AddModelError("", "Неверный логин или пароль");
            }
            else
            {
                await Authenticate(user);
                return RedirectToAction("Index", "Home");
            }
            return View(data);
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
            if (ModelState.IsValid)
            {
                var user = database.Users.FirstOrDefault(u => u.Login == data.Login);
                if (user == null)
                {
                    var newUser = new Models.User()
                    {
                        Login = data.Login,
                        PasswordHash = data.Password
                    };
                    database.Users.Add(newUser);
                    await database.SaveChangesAsync();
                    _ = Authenticate(newUser);
                    return RedirectToAction("Index", "Home");
                }  
                else
                {
                    ModelState.AddModelError("", "Некорректные данные");
                }
            }
            return View(data);
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim("GUID", user.Guid.ToString()) // TODO разобраться как хранить этот бред в сессии
            };
            ClaimsIdentity id = new ClaimsIdentity(claims:             claims,
                                                   authenticationType: "ApplicationCookie",
                                                   nameType:           ClaimsIdentity.DefaultNameClaimType,
                                                   roleType:           ClaimsIdentity.DefaultRoleClaimType);
            Request.HttpContext.Session.SetUserGuid(user.Guid);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}