using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rauthor.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("GUID")]
        public Guid Guid { get; set; }
        [Column("login")]
        public string Login { get; set; }
        [Column("password_hash")]
        public string PasswordHash { get; set; }
        public List<Poem> Poems { get; set; }

        public User()
        {
            Guid = Guid.NewGuid();
        }
    }
    public static partial class ISessionExtensions
    {
        /// <summary>
        /// Возвращает GUID авторизованного пользователя
        /// </summary>
        public static Guid? GetUserGuid(this ISession session)
        {
            byte[] guid_bytes = session.Get("User GUID");
            if (guid_bytes != null)
            {
                return new Guid(guid_bytes);
            }
            else
            {
                return null;
            }
        }
        public static void SetUserGuid(this ISession session, Guid userGuid)
        {
            session.Set("User GUID", userGuid.ToByteArray());
        }
    }
}
