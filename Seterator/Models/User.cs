using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Seterator.Models
{
    public class User
    {
        [Key]
        public Guid Guid { get; set; }

        [Column(TypeName="varchar(128)")]
        public string Login { get; set; }

        [JsonConverter(typeof(ReadOnlyCollectionConverter<byte>))]
        public IReadOnlyCollection<byte> PasswordHash { get; set; }

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
        
        public User()
        {
            Guid = Guid.NewGuid();
        }
        private class ReadOnlyCollectionConverter<TItem> : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(IReadOnlyCollection<TItem>);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                return serializer.Deserialize<TItem[]>(reader) as IReadOnlyCollection<TItem>;
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, (value as IReadOnlyCollection<TItem>).ToArray());
            }
        }
    }
    
    public enum UserKind
    {
        Common,
        Jury,
        Moderator
    }
}
