using Seterator.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Seterator.Models
{
    public class Poem
    {
        [Key]
        public Guid Guid { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public Guid ParticipantGuid { get; set; }
        public virtual Participant Author { get; set; }

        public Poem()
        {
            Guid = Guid.NewGuid();
        }
    }
}
