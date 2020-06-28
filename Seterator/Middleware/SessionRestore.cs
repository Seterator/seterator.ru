using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Seterator.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Seterator.Middleware
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
        public Task Invoke(HttpContext context, DatabaseContext database)
        {
            // if (context.User.Identity.IsAuthenticated)
            // {
            //     try
            //     {
            //         bool sessionSet = context.Session.Get<bool>("sessionSet");
            //         if (!sessionSet)
            //         {
            //             Restore(context, database);
            //         }
            //     }
            //     catch (KeyNotFoundException)
            //     {  
            //         Restore(context, database);
            //     }
                
            // }
            // else
            // {
            //     context.Session.Set<bool>("sessionSet", false);
            //     context.Session.Set<User>("user", null);
            // }
            return next(context);
        }
    }
}
