using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Seterator.Models;

namespace Seterator.Services
{
    public class AccountService
    {
        private readonly DatabaseContext database;
        private readonly HashService hasher;
        public AccountService(DatabaseContext database, HashService hasher)
        {
            this.database = database;
            this.hasher = hasher;
        }

        /// <summary>
        /// Возвращает истину, если существует пользователь с указанным логином и хешем пароля.
        /// </summary>
        public bool CheckCredentials(string login, IReadOnlyCollection<byte> passwordHash)
        {
            var userExists = database.Users.Any(
                user => user.Login == login && user.PasswordHash == passwordHash);
            return userExists;
        }

        /// <summary>
        /// Возвращает истину, если пользователь с указанным логином и паролем может выполнить вход.
        /// </summary>
        public bool TryLogin(string login, string password)
        {
            var passwordHash = hasher.Hash(password);
            var credentialsCorrect = CheckCredentials(login, passwordHash);
            return credentialsCorrect;
        }

        /// <summary>
        /// Возвращает перечень ролей, доступных пользователю с данным логином.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<List<string>> GetUserClaims(string username)
        {
            var roles = await database.Roles.AsNoTracking()
                .Include(x => x.User)
                .Where(x => x.User.Login == username)
                .Select(x => x.UserRole.ToString())
                .ToListAsync();
            return roles;
        }

        /// <summary>
        /// Возвращает перечень ролей, доступных пользователю с данным GUID.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<List<string>> GetUserRoles(Guid userGuid)
        {
            var roles = await database.Roles.AsNoTracking()
                .Include(x => x.User)
                .Where(x => x.User.Guid == userGuid)
                .Select(x => x.UserRole.ToString())
                .ToListAsync();
            return roles;
        }

        /// <summary>
        /// Возвращает истину, если пользователь может создать учётную запись с таким логином.
        /// </summary>
        public bool IsLoginAvailable(string login)
        {
            var loginTaken = database.Users.Any(x => x.Login == login);
            return !loginTaken;
        }

        /// <summary>
        /// Регистрирует учётную запись пользователя с указанным логиным и паролем.
        /// </summary>
        public async Task Register(string login, string password)
        {
            var passwordHash = hasher.Hash(password);
            var user = new User() { Login = login, PasswordHash = passwordHash };
            database.Users.Add(user);
            await database.SaveChangesAsync();
        }
    }
}
