using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Seterator.Models
{
    /// <summary>
    /// Представляет профиль пользователя для конкретной роли.
    /// </summary>
    [Table("profiles")]
    public class UserProfile
    {
        [Key]
        [Column("user_role_guid")]
        public Guid RoleGuid { get; set; }
        [Column("data")]
        public string Data { get; set; }
        [Column("short_link")]
        public string? ShortLink { get; set; }
    }
}
