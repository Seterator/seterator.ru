using Rauthor.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rauthor.Models
{
    [Table("poem")]
    public class Poem
    {
        bool filter = true;
        private string text;

        [Key]
        [Column("GUID")]
        public Guid Guid { get; set; }

        [Column("Text")]
        public string Text 
        { 
            get {
                if (filter)
                {
                    return ShitService.Mask(text);
                }
                else
                {
                    return text;
                }
            }
            set => text = value; 
        }

        [Column("title")]
        public string Title { get; set; }

        [Column("author_GUID")]
        public Guid ParticipantGuid { get; set; }



        [ForeignKey("ParticipantGuid")]
        public virtual Participant Author { get; set; }

        public Poem()
        {
            Guid = Guid.NewGuid();
        }
    }
}
