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
    public class UserProfile
    {
        [Key]
        public Guid RoleGuid { get; set; }
        public string Data { get; set; }
        public string? ShortLink { get; set; }
    }
}
