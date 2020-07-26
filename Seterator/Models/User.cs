using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Immutable;

#pragma warning disable CS8618

namespace Seterator.Models
{
    public class User
    {
        [Key]
        public Guid Guid { get; set; }

        [Column(TypeName="varchar(128)")]
        public string Login { get; set; }

        public ImmutableArray<byte> PasswordHash { get; set; }

        public virtual List<Participant> Participants { get; set; }

        public virtual List<Role> Roles { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string ProfilePicture { get; set; }

        public string RegisterAddress { get; set; }

        public bool Verified { get; set; }

        public string VkProfile { get; set; }
        
        public string FbProfile { get; set; }

        public string InstProfile { get; set; }

        [Column("UserUrls")]
        public string UserUrlsJson { get; set; }

        [NotMapped]
        public List<string> UserUrls => JsonConvert.DeserializeObject<List<string>>(UserUrlsJson);

        public virtual List<UserDocument> Documents { get; set; }

        public string PublicEmail { get; set; }

        public string PublicPhone { get; set; }

        public string PrivateEmail { get; set; }

        public string PrivatePhone { get; set; }

        public string INN { get; set; }

        public string SNILS { get; set; }
    }
    
    public enum UserKind
    {
        Common,
        Jury,
        Moderator
    }
}
