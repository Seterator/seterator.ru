using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Seterator.Models
{
    public class ParticipantAssessment
    {
        [Key]
        public Guid Guid { get; set; }
        public Guid ParticipantGuid { get; set; }
        public Guid JuryGuid { get; set; }
        
        public Assessment? Assessment { get; set; }
        
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
