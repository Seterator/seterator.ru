using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.Models
{
    public enum Approved
    {
        True = 1,
        False = 0
    }

    [Table("сompetition_participant")]
    public class Participant
    {
        [Key]
        [Column("GUID")]
        public Guid Guid { get; set; }

        [Column("user_score")]
        public int UserScore { get; set; }

        [Column("jury_score")]
        public int JuryScore { get; set; }

        [Column("competition_GUID")]
        public Guid CompetitionGuid { get; set; }

        [Column("user_GUID")]
        public Guid UserGuid { get; set; }

        [Column("approved", TypeName = "enum('True','False')")]
        public Approved Approved { get; set; }


        [ForeignKey("CompetitionGuid")]
        public Competition Competition { get; set; }

        [ForeignKey("UserGuid")]
        public User User { get; set; }

        public Participant()
        {
            Guid = Guid.NewGuid();
        }
        
    }
}
