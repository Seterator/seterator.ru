using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.Models
{
    public class Profile
    {
        [Key]
        public Guid RoleGuid { get; set; }
        [Column("data")]
        public string Data { get; set; }
    }
}
