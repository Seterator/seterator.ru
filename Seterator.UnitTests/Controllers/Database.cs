using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Seterator.Models;
using System.Linq;
using System.Collections.Immutable;

namespace Seterator.UnitTests.Controllers
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

        public static ImmutableArray<byte> ByteArray()
        {
            return ImmutableArray.CreateRange(
                Enumerable
                    .Repeat(0, 10)
                    .Select(_ => (byte)random.Next(0, 128)));
        }

        public static int Int32()
        {
            return random.Next(-100_000, +100_000);
        }
    }

    public static class Database
    {
        /// <summary>
        /// Настраивает набор данных и возвращает Guid, по которому можно обратиться к нему.
        /// Можно явно указать Guid, тогда набор данных будет доступен именно по нему.
        /// </summary>
        /// <param name="datasetGuid"></param>
        /// <returns></returns>
        public static Guid Setup(Guid? datasetGuid = null)
        {
            datasetGuid = datasetGuid ?? Guid.NewGuid();
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: (datasetGuid).ToString())
                .Options;
            using (var db = new DatabaseContext(options))
            {
                FillData(db);
            }
            return datasetGuid.Value;
        }
        
        /// <summary>
        /// Возвращает соответствующий экземпляр <see cref="DatabaseContext"/>. 
        /// Не забудьте вызвать для него Dispose(), после окончания работы.
        /// </summary>
        /// <param name="datasetGuid">Guid набора данных.</param>
        /// <returns></returns>
        public static DatabaseContext Use(Guid datasetGuid)
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: (datasetGuid).ToString())
                .Options;
            return new DatabaseContext(options);
        }

        private static void FillData(DatabaseContext db)
        {
            var @guid = new Primitive<Guid>(PrimitiveFuncs.Guid);
            var @string = new Primitive<string>(PrimitiveFuncs.String);
            var @byte = new Primitive<ImmutableArray<byte>>(PrimitiveFuncs.ByteArray);
            var @int = new Primitive<int>(PrimitiveFuncs.Int32);

            db.Users.Add(new User() { Guid = guid[0], Login = @string[0], PasswordHash = @byte[0] });
            db.Users.Add(new User() { Guid = guid[1], Login = @string[1], PasswordHash = @byte[1] });
            db.Users.Add(new User() { Guid = guid[2], Login = @string[2], PasswordHash = @byte[2] });

                
            db.Roles.Add(new Role() { Guid = guid[3], UserGuid = guid[0], UserRole = Models.UserRole.User });
            db.Roles.Add(new Role() { Guid = guid[4], UserGuid = guid[1], UserRole = Models.UserRole.User });
            db.Roles.Add(new Role() { Guid = guid[5], UserGuid = guid[2], UserRole = Models.UserRole.User });
            db.Roles.Add(new Role() { Guid = guid[6], UserGuid = guid[2], UserRole = Models.UserRole.Admin });
            db.Roles.Add(new Role() { Guid = guid[7], UserGuid = guid[2], UserRole = Models.UserRole.Jury });
            db.Roles.Add(new Role() { Guid = guid[14], UserGuid = guid[1], UserRole = Models.UserRole.Manager });

            db.Profiles.Add(new UserProfile() { RoleGuid = guid[3], Data = "null", ShortLink = "" });
            db.Profiles.Add(new UserProfile() { RoleGuid = guid[4], Data = "null", ShortLink = "" });
            db.Profiles.Add(new UserProfile() { RoleGuid = guid[5], Data = "null", ShortLink = "" });
            db.Profiles.Add(new UserProfile() { RoleGuid = guid[6], Data = "null", ShortLink = @string[3] });
            db.Profiles.Add(new UserProfile() { RoleGuid = guid[7], Data = "null", ShortLink = $"jury_{@string[3]}" });

                
            db.CompetitionCategories.Add(new CompetitionCategory() 
            { 
                Guid = guid[8], 
                Name = @string[4],
            });

            db.Competitions.Add(new Competition()
            {
                Guid = guid[9],
                Description = "Description sample",
                EndDate = new DateTime(2020, 5, 15),
                StartDate = new DateTime(2020, 3, 15),
                Title = "Title sample",
                ShortDescription = "Short description sample",
            });

            db.CompetitionConstraints.Add(new CompetitionConstraint()
            {
                Guid = guid[10],
                CompetitionGuid = guid[9],
                CheckedValue = @string[5],
                Min = @int[0],
                Max = @int[0] + @int[1]
            });

            db.CompetitionRelCategories.Add(new CompetitionRelCategory()
            {
                CategoryGuid = guid[8],
                CompetitionGuid = guid[9]
            });

            db.Prizes.Add(new Prize() { Guid = guid[11], BeginPlace = 1, EndPlace = 1, CompetitionGuid = guid[9], Value = @string[6] });
            db.Prizes.Add(new Prize() { Guid = guid[12], BeginPlace = @int[2], EndPlace = @int[2]+1, CompetitionGuid = guid[9], Value = @string[7] });
            db.Prizes.Add(new Prize() { Guid = guid[13], BeginPlace = @int[3], EndPlace = @int[3]+@int[4], CompetitionGuid = guid[9], Value = @string[8] });

            db.SaveChanges();
        }
    
        private static void RemoveAll(DatabaseContext db)
        {
            
            db.Users.RemoveRange(db.Users);
            db.Roles.RemoveRange(db.Roles);
            db.Profiles.RemoveRange(db.Profiles);
            db.CompetitionCategories.RemoveRange(db.CompetitionCategories);
            db.CompetitionRelCategories.RemoveRange(db.CompetitionRelCategories);
            db.CompetitionRelJuries.RemoveRange(db.CompetitionRelJuries);
            db.Participants.RemoveRange(db.Participants);
            db.Poems.RemoveRange(db.Poems);
            db.Competitions.RemoveRange(db.Competitions);
            db.CompetitionConstraints.RemoveRange(db.CompetitionConstraints);
            db.SaveChanges();
        }
    }
}
