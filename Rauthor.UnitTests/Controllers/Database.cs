using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rauthor.UnitTests.Controllers
{

    /// <summary>
    /// Нужно для того, чтобы не придумывать новые примитивы.
    /// </summary>
    internal class Primitive<T>
    {
        Dictionary<int, T> table = new Dictionary<int, T>();
        private Func<T> newPrimitive;
        public Primitive(Func<T> newPrimitiveFunc)
        {
            newPrimitive = newPrimitiveFunc;
        }
        public T this[int index]
        {
            get
            {
                if (!table.ContainsKey(index))
                {
                    table[index] = newPrimitive();
                }
                return table[index];
            }
        }
    }

    internal class PrimitiveFuncs
    {
        private static Random random = new Random();
        public static Guid Guid() => System.Guid.NewGuid();
        public static string String()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                sb.Append((char) random.Next(65, 122));
            }
            return sb.ToString();
        }

        public static IReadOnlyCollection<byte> Byte()
        {
            var bytes = new byte[10];
            for (int i = 0; i < 10; i++)
            {
                bytes[i] = (byte) random.Next(0, 128);
            }
            return bytes;
        }
    }

    /// <summary>
    /// Представляет объект базы данных с предопределёнными значениями (для тестов).
    /// </summary>
    public static class Database
    {
        private static DbContextOptions<DatabaseContext> options;
        public static DatabaseContext Instance => new DatabaseContext(options);
        
        /// <summary>
        /// Выполняет настройку базы InMemory-данных и вносит в неё рандомизированный тестовый набор данных.
        /// </summary>
        public static void ConfigureInstanceAndData()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "rauthor")
                .Options;
            Database.options = options;
            FillData();
        }
        private static void FillData()
        {
            var @guid = new Primitive<Guid>(PrimitiveFuncs.Guid);
            var @string = new Primitive<string>(PrimitiveFuncs.String);
            var @byte = new Primitive<IReadOnlyCollection<byte>>(PrimitiveFuncs.Byte);
            using (var db = Instance)
            {
                db.Users.Add(new Models.User() { Guid = guid[0], Login = @string[0], PasswordHash = @byte[0] });
                db.Users.Add(new Models.User() { Guid = guid[1], Login = @string[1], PasswordHash = @byte[1] });
                db.Users.Add(new Models.User() { Guid = guid[2], Login = @string[2], PasswordHash = @byte[2] });

                db.Roles.Add(new Models.Role() { Guid = guid[3], UserGuid = guid[0], UserRole = Models.UserRole.User });
                db.Roles.Add(new Models.Role() { Guid = guid[4], UserGuid = guid[1], UserRole = Models.UserRole.User });
                db.Roles.Add(new Models.Role() { Guid = guid[5], UserGuid = guid[2], UserRole = Models.UserRole.User });
                db.Roles.Add(new Models.Role() { Guid = guid[6], UserGuid = guid[2], UserRole = Models.UserRole.Admin });

                db.Profiles.Add(new Models.UserProfile() { RoleGuid = guid[3], Data = "null", ShortLink = "" });
                db.Profiles.Add(new Models.UserProfile() { RoleGuid = guid[4], Data = "null", ShortLink = "" });
                db.Profiles.Add(new Models.UserProfile() { RoleGuid = guid[5], Data = "null", ShortLink = "" });
                db.Profiles.Add(new Models.UserProfile() { RoleGuid = guid[6], Data = "null", ShortLink = @string[3] });

                db.SaveChanges();
            }
        }
    }
}
