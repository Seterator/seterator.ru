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
        public byte[] PasswordHash { get; set; }


        public List<Poem> Poems { get; set; }

        public List<Participant> Participants { get; set; }
        public User()
        {
            Guid = Guid.NewGuid();
        }
    }
}
