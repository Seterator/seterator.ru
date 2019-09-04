using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.Models
{
    [Table("votes_of_users")]
    public class VoteOfUser
    {
        [Column("user_guid")]
        public Guid UserGuid { get; set; }

        [Column("participant_guid")]
        public Guid ParticipantGuid { get; set; }

        [Column("vote_state", TypeName = "enum('Up', 'None')")]
        public VoteState VoteState { get; set; }

        [ForeignKey("UserGuid")]
        public User User { get; set; }

        [ForeignKey("ParticipantGuid")]
        public Participant Participant { get; set; }
    }
    public enum VoteState
    {
        Up,
        None
    }
}
