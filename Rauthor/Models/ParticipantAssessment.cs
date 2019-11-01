using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.Models
{
    [Table("participant_assessment")]
    public class ParticipantAssessment
    {
        [Key]
        [Column("GUID")]
        public Guid Guid { get; set; }
        
        [Column("participant_guid")]
        public Guid ParticipantGuid { get; set; }

        [Column("jury_guid")]
        public Guid JuryGuid { get; set; }
        
        [Column("assessment", TypeName = "enum('0', '2', '3', '4', '5')")]
        public Assessment? Assessment { get; set; }
        
        [ForeignKey("ParticipantGuid")]
        public Participant Participant { get; set; }
    }
    public enum Assessment
    {
        Zero = 0,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }
}
