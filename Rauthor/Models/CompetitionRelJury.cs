using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.Models
{
    [Table("competition_rel_jury")]
    public class CompetitionRelJury
    {
        [Column("competition_guid")]
        public Guid CompetitionGuid { get; set; }
        
        [Column("jury_user_guid")]
        public Guid JuryUserGuid { get; set; }

        [ForeignKey("JuryUserGuid")]
        public User Jury { get; set; }

        [ForeignKey("CompetitionGuid")]
        public Competition Competition { get; set; }
    }
}
