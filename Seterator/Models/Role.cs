using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Seterator.Models
{
    [Table("roles")]
    public class Role
    {
        [Key]
        [Column("GUID")]
        public Guid Guid { get; set; }

        [Column("role", TypeName = "Enum( 'moderator', 'jury', 'user', 'manager', 'admin' )")]
        public UserRole UserRole { get; set; }

        [Column("user_guid")]
        public Guid UserGuid { get; set; }

        [ForeignKey("UserGuid")]
        public User User { get; set; }
    }

    public enum UserRole
    {
        Moderator,
        Jury,
        User,
        Manager,
        Admin
    }
}
