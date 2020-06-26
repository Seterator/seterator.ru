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
using System.Security.Cryptography;
using Seterator.Models;
using Seterator.Models.Api;
using Seterator.ViewModels;
using Seterator.Services;

namespace Seterator.Controllers.Api
{
    // [Route("api/[controller]")]
    // [ApiController]
    // public class AccountController : ControllerBase
    // {
    //     AccountService account;
    //     private static readonly byte[] salt = new byte[]
    //     {
    //         0xad, 0x34, 0xff, 0x45, 0xf2, 0x12, 0x34, 0xfa,
    //         0xad, 0x34, 0xff, 0x45, 0xf2, 0x12, 0x34, 0xfa
    //     };
    //     public AccountController(AccountService account)
    //     {
    //         this.account = account;
    //     }
    //     // POST: api/Account
    //     [HttpPost]
    //     public LoginResult Post([FromBody] Login data)
    //     {
    //         switch (data.Method)
    //         {
    //             case "login":
    //             {
    //                 var canLogin = account.TryLogin(data.Login, data.Password);
    //                 if (canLogin)
    //                 {
    //                     Authenticate(user);
                        
    //                 }
    //             }
    //             case "register":
    //             {
    //                 return Register(data);
    //             }

    //             default:
    //                 return new Models.Api.LoginResult() { Result = "reject", Message = "Ошибка в запросе" };
    //         }
    //     }
        
    //     private LoginResult Register(Models.Api.Login data)
    //     {
    //         var user = database.Users.FirstOrDefault(u => u.Login == data.Login);
    //         var passwordHash = Utils.HashService.Default.Hash(data.Password);
    //         if (user == null)
    //         {
    //             var newUser = new Models.User()
    //             {
    //                 Login = data.Login,
    //                 PasswordHash = passwordHash
    //         };
    //             database.Users.Add(newUser);
    //             database.SaveChanges();
    //             Task.Run(async () => await Authenticate(newUser));
    //             return new LoginResult() { Result = "accept", Message = "Регистрация завершена успешно" };
    //         }
    //         else
    //         {
    //             return new LoginResult() { Result = "reject", Message = "Ошибка в запросе" };
    //         }
    //     }
        
    //     private async Task Authenticate(User user)
    //     {
    //         var claims = new List<Claim>();
    //         claims.Add(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login));
    //         foreach (var role in user.Roles)
    //         {
    //             claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role.UserRole.ToString()));
    //         }
    //         var id = new ClaimsIdentity(claims: claims,
    //                                                authenticationType: "ApplicationCookie",
    //                                                nameType: ClaimsIdentity.DefaultNameClaimType,
    //                                                roleType: ClaimsIdentity.DefaultRoleClaimType);
    //         await HttpContext
    //             .SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
    //                          new ClaimsPrincipal(id));
    //     }
    // }
}
