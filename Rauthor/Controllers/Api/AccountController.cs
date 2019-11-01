using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Generators;
using Rauthor.Models;
using Rauthor.Models.Api;
using Rauthor.ViewModels;

namespace Rauthor.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        DatabaseContext database;
        private static readonly byte[] salt = new byte[]
        {
            0xad, 0x34, 0xff, 0x45, 0xf2, 0x12, 0x34, 0xfa,
            0xad, 0x34, 0xff, 0x45, 0xf2, 0x12, 0x34, 0xfa
        };
        public AccountController(DatabaseContext database)
        {
            this.database = database;
        }
        // POST: api/Account
        [HttpPost]
        public Models.Api.LoginResult Post([FromBody] Login data)
        {
            switch (data.Method)
            {
                case "login":
                {
                    return Login(data);
                }
                case "register":
                {
                    return Register(data);
                }

                default:
                    return new Models.Api.LoginResult() { Result = "reject", Message = "Ошибка в запросе" };
            }
        }
    
        private LoginResult Login(Models.Api.Login data)
        {
            Models.User user = database.Users.FirstOrDefault(u => u.Login == data.Username);
            if (user == null || !BCrypt.Generate(Encoding.Unicode.GetBytes(data.Password), salt, 8).SequenceEqual(user.PasswordHash))
            {
                return new LoginResult() { Result = "reject", Message = "Неверный логин или пароль" };
            }
            else
            {
                Authenticate(user).Wait();
                return new Models.Api.LoginResult() { Result = "accept", Message = "Авторизация завершена успешно." };
            }
        }
        private LoginResult Register(Models.Api.Login data)
        {
            var user = database.Users.FirstOrDefault(u => u.Login == data.Username);
            if (user == null)
            {
                var newUser = new Models.User()
                {
                    Login = data.Username,
                    PasswordHash = BCrypt.Generate(Encoding.Unicode.GetBytes(data.Password), salt, 8)
                };
                database.Users.Add(newUser);
                database.SaveChanges();
                Authenticate(newUser).Wait();
                return new LoginResult() { Result = "accept", Message = "Регистрация завершена успешно" };
            }
            else
            {
                return new LoginResult() { Result = "reject", Message = "Ошибка в запросе" };
            }
        }
        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimTypes.Role, user.Kind.ToString())
            };
            ClaimsIdentity id = new ClaimsIdentity(claims: claims,
                                                   authenticationType: "ApplicationCookie",
                                                   nameType: ClaimsIdentity.DefaultNameClaimType,
                                                   roleType: ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext
                .SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                             new ClaimsPrincipal(id))
                .ConfigureAwait(false);
        }
    }
}
