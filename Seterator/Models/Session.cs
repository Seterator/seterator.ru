using System;
using System.ComponentModel.DataAnnotations;

namespace Seterator.Models
{
    public class Session
    {
        [Key]
        public string Id { get; set; }
        public Guid? UserGuid { get; set; }
        public bool Authenticated { get; set; }

        public User? User { get; set; }
    }
}
