using System.Reflection.Emit;
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
    [Route("api/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService account;
        private readonly AuthService auth;

        public AccountController(AccountService account, AuthService auth)
        {
            this.account = account;
            this.auth = auth;
        }

        [HttpPost]
        public async Task<AccountActionResult> Login([FromBody] Login model)
        {
            var canLogin = account.TryLogin(model.Username, model.Password);
            if (canLogin)
            {
                var roles = await account.GetUserClaims(model.Username);
                await auth.Authenticate(model.Username, roles);
                return new AccountActionResult()
                {
                    Status = 0,
                    Message = "Авторизация выполнена"
                };
            }
            else
            {
                return new AccountActionResult()
                {
                    Status = 1,
                    Message = "Авторизация не выполнена"
                };
            }
        }

        [HttpPost]
        public async Task<AccountActionResult> Register([FromBody] Register model)
        {
            var loginAvailable = account.IsLoginAvailable(model.Username);
            if (loginAvailable)
            {
                await account.Register(model.Username, model.Password);
                await auth.Authenticate(model.Username, Enumerable.Empty<string>());
                return new AccountActionResult()
                {
                    Status = 0,
                    Message = "Регистрация и вход выполнены"
                };
            }
            else
            {
                return new AccountActionResult()
                {
                    Status = 1,
                    Message = "Пользователь с таким именем уже существует"
                };                
            }
        }

        [HttpPost]
        public async Task<AccountActionResult> Logout()
        {
            try
            {
                await auth.Logout();
                return new AccountActionResult()
                {
                    Status = 0,
                    Message = "Выход из учётной записи выполнен"
                };
            }
            catch
            {
                return new AccountActionResult()
                {
                    Status = 1,
                    Message = "Ошибка при попытке выхода из учётной записи."
                };
            }
        }
    }
}
