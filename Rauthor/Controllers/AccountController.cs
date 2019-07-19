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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Crypto.Generators;
using Rauthor.Models;
using static Rauthor.Services.SessionExtensions;

namespace Rauthor.Controllers
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
        public async Task<IActionResult> Login(ViewModels.LoginModel model)
        {
            Contract.Assert(model != null);
            if (ModelState.IsValid)
            {
                Models.User user = database.Users.FirstOrDefault(u => u.Login == model.Login);
                if (user == null || !BCrypt.Generate(Encoding.Unicode.GetBytes(model.Password), salt, 8).SequenceEqual(user.PasswordHash))
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }
                else
                {
                    await Authenticate(user).ConfigureAwait(false);
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
            Contract.Assert(data != null);
            if (ModelState.IsValid)
            {
                var user = database.Users.FirstOrDefault(u => u.Login == data.Login);
                if (user == null)
                {
                    
                    var newUser = new Models.User()
                    {
                        Login = data.Login,
                        PasswordHash = BCrypt.Generate(Encoding.Unicode.GetBytes(data.Password), salt, 8)
                    };
                    database.Users.Add(newUser);
                    await database.SaveChangesAsync().ConfigureAwait(true);
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

        public IActionResult Main()
        {
            return View();
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimTypes.Role, user.Kind.ToString())
            };
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