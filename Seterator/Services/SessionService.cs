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
    public interface ISessionService
    {
        /// <summary>
        /// Возвращает истину, если сессия с таким идентификатором существует.
        /// </summary>
        bool IsExists(string sessionId);
        
        /// <summary>
        /// Помечает сессию, в ходе которой пользователь вошёл в учётную запись.
        /// </summary>
        Task MarkAuthenticated(string sessionId, string userName);
        
        /// <summary>
        /// Помечает сессию, в ходе которой пользователь вышел из учётной записи.
        /// </summary>
        Task MarkUnauthenticated(string sessionId);
        
        /// <summary>
        /// Регистрирует новую сессию
        /// </summary>
        Task RegisterNew(string sessionId);
    }
    public class SessionService : ISessionService
    {
        private readonly DatabaseContext database;
        public SessionService(DatabaseContext database)
        {
            this.database = database;
        }

        public bool IsExists(string sessionId)
        {
            return database.Sessions.Any(session => session.Id == sessionId);
        }

        public async Task MarkAuthenticated(string sessionId, string username)
        {
            var session = database.Sessions.Single(session => session.Id == sessionId);
            var user = database.Users.Single(user => user.Login == username);
            session.UserGuid = user.Guid;
            session.Authenticated = true;
            await database.SaveChangesAsync();
        }

        public async Task MarkUnauthenticated(string sessionId)
        {
            var session = database.Sessions.Single(session => session.Id == sessionId);
            session.UserGuid = null;
            session.Authenticated = false;
            await database.SaveChangesAsync();
        }

        public async Task RegisterNew(string sessionId)
        {
            database.Sessions.Add(new Models.Session()
            {
                Id = sessionId,
                UserGuid = null,
                Authenticated = false
            });
            await database.SaveChangesAsync();
        }
    }
}
