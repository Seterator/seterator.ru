using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Seterator.Models
{
    public class Role
    {
        [Key]
        public Guid Guid { get; set; }

        public UserRole UserRole { get; set; }

        public Guid UserGuid { get; set; }

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
