using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Seterator.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Seterator.Services;

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
        public Task Invoke(HttpContext context, ISessionService session)
        {
            if (!session.IsExists(context.Session.Id))
            {
                session.RegisterNew(context.Session.Id);
            }
            return next(context);
        }
    }
}
