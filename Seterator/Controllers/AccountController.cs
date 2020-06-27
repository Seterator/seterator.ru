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
using Seterator.Services;
using static Seterator.Services.SessionExtensions;

namespace Seterator.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService account;
        private readonly AuthService auth;
        
        public AccountController(AccountService account, AuthService auth)
        {
            this.account = account;
            this.auth = auth;
        }
        
        public IActionResult Main()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await auth.Logout();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(ViewModels.LoginModel model)
        {
        
            var canLogin = account.TryLogin(model.Login, model.Password);
            if (canLogin)
            {
                await auth.Authenticate(model.Login, Enumerable.Empty<string>());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Неверный логин или пароль");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(ViewModels.RegistrationModel model)
        {
            var loginAvailable = account.IsLoginAvailable(model.Login);
            if (loginAvailable)
            {
                await account.Register(model.Login, model.Password);
                await auth.Authenticate(model.Login, Enumerable.Empty<string>());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Пользователь с таким именем уже существует");
                return View(model);
            }
        }
    }
}
