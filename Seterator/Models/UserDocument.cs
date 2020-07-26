using System;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable CS8618

namespace Seterator.Models
{
    [Table("Documents")]
    public class UserDocument
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("OwnerGuid")]
        public Guid OwnerGuid { get; set; }

        [ForeignKey("OwnerGuid")]
        public virtual User Owner{ get; set; }
        
        [Column("type")]
        public string Type { get; set; }

        [Column("data")]
        public ImmutableArray<byte> Data { get; set; }
    }
}
