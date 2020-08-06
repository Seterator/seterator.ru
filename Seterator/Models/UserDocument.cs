using System;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#pragma warning disable CS8618

namespace Seterator.Models
{
    public class UserDocument
    {
        [Key]
        public Guid Guid { get; set; }

        public Guid OwnerGuid { get; set; }

        [ForeignKey("OwnerGuid")]
        public virtual User Owner { get; set; }
        
        public string Type { get; set; }

        public ImmutableArray<byte> Data { get; set; }
    }
}
