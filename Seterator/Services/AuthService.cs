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
        private readonly HttpContext httpContext;
        public AuthService(IHttpContextAccessor http)
        {
            this.httpContext = http.HttpContext;
        }

        public async Task Authenticate(string login, IEnumerable<string> roles)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimsIdentity.DefaultNameClaimType, login));
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role));
            }
            ClaimsIdentity id = 
                new ClaimsIdentity(claims: claims,
                                   authenticationType: "ApplicationCookie",
                                   nameType: ClaimsIdentity.DefaultNameClaimType,
                                   roleType: ClaimsIdentity.DefaultRoleClaimType);
            await httpContext
                .SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                             new ClaimsPrincipal(id));
        }

        public async Task Logout()
        {
            await httpContext
                .SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
