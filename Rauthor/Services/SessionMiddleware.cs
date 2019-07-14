using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Rauthor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.Services
{
    /// <summary>
    /// Восстанавливает данные сессии авторизованного пользователя.
    /// </summary>
    public class SessionRestore
    {
        readonly RequestDelegate next;
        public SessionRestore(RequestDelegate next)
        {
            this.next = next;
        }
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task Invoke(HttpContext context, DatabaseContext database)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            
            if (context.User.Identity.IsAuthenticated)
            {
                try
                {
                    bool sessionSet = context.Session.Get<bool>("sessionSet");
                    if (!sessionSet)
                    {
                        Restore(context, database);
                    }
                }
                catch (KeyNotFoundException)
                {  
                    Restore(context, database);
                }
                
            }
            else
            {
                context.Session.Set<bool>("sessionSet", false);
                context.Session.Set<User>("user", null);
            }
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            next(context);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }
        private void Restore(HttpContext context, DatabaseContext database)
        {
            string login = context.User.Identity.Name;
            User user = database.GetUser(login);
            context.Session.Set<User>("user", user);
            context.Session.Set<bool>("sessionSet", true);
        }
    }
}
