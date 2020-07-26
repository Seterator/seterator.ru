using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] Data { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays
    }
}
