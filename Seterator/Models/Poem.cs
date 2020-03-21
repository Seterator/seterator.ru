using Seterator.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seterator.Models
{
    [Table("poem")]
    public class Poem
    {
        [Key]
        [Column("GUID")]
        public Guid Guid { get; set; }

        [Column("text")]
        public string Text { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("author_participant_guid")]
        public Guid ParticipantGuid { get; set; }

        [ForeignKey("ParticipantGuid")]
        public virtual Participant Author { get; set; }

        public Poem()
        {
            Guid = Guid.NewGuid();
        }
    }
}
