using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.Models
{
    [Table("participant")]
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

        [Column("approved", TypeName = "BIT(1)")]
        public bool Approved { get; set; }


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
