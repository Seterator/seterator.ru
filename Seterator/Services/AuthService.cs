using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace Seterator.Services
{
    public class AuthService
    {
        const string scheme = CookieAuthenticationDefaults.AuthenticationScheme;
        const string username = ClaimsIdentity.DefaultNameClaimType;
        const string role = ClaimsIdentity.DefaultRoleClaimType;
        const string authType = "ApplicationCookie";
        private readonly HttpContext httpContext;

        public AuthService(IHttpContextAccessor http)
        {
            this.httpContext = http.HttpContext;
        }

        public async Task Authenticate(string login, IEnumerable<string> roles)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(username, login));
            claims.AddRange(roles.Select(exactRole => new Claim(role, exactRole)));
            var id = new ClaimsIdentity(claims, authType, username, role);
            await httpContext.SignInAsync(scheme, new ClaimsPrincipal(id));
        }

        public async Task Logout()
        {
            await httpContext.SignOutAsync(scheme);
        }

        /// <summary>
        /// Возвращает истину, если пользователь отправивший запрос уже выполнил авторизацию.
        /// </summary>
        public bool IsCurrentUserAuthorized() => httpContext.User.Identity.IsAuthenticated;

        /// <summary>
        /// Возвращает имя пользователя, отправившего запрос, если он уже авторизован.
        /// Иначе - выбрасывает исключение.
        /// </summary>
        public string CurrentUserLogin()
        {
            if(IsCurrentUserAuthorized())
            {
                return httpContext.User.Identity.Name!;
            }
            else
            {
                throw new Exception("Пользователь не авторизован");
            }
        }

        /// <summary>
        /// Возвращает список ролей пользователя, отправившего запрос, если он уже авторизован.
        /// Иначе - выбрасывает исключение.
        /// </summary>
        public List<string> CurrentUserRoles()
        {
            if (IsCurrentUserAuthorized())
            {
                return httpContext.User.Claims
                    .Where(x => x.Type == role)
                    .Select(x => x.Value)
                    .ToList();
            }
            else
            {
                throw new Exception("Пользователь не авторизован");
            }
        }
    }
}
