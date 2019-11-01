using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.Models
{
    public class Role
    {
        [Key]
        public Guid Guid { get; set; }

        [Column("role", TypeName = "Enum( 'moderator', 'jury', 'user', 'manager' )")]
        public UserRole UserRole { get; set; }

        public Guid UserGuid { get; set; }

        [ForeignKey("UserGuid")]
        public User User { get; set; }
    }

    public enum UserRole
    {
        Moderator,
        Jury,
        User,
        Manager
    }
}
