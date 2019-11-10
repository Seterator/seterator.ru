using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.Models
{
    /// <summary>
    /// Представляет профиль пользователя для конкретной роли.
    /// </summary>
    public class UserProfile
    {
        [Key]
        public Guid RoleGuid { get; set; }
        [Column("data")]
        public string Data { get; set; }
    }
}
