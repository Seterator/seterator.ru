using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Seterator.Models
{
    [Table("competition_rel_category")]
    public class CompetitionRelCategory
    {
        [Column("competition_category_guid")]
        public Guid CompetitionGuid { get; set; }
        
        [Column("competition_guid")]
        public Guid CategoryGuid { get; set; }

        [ForeignKey("CompetitionGuid")]
        public Competition Competition { get; set; }

        [ForeignKey("CategoryGuid")]
        public CompetitionCategory Category { get; set; }
    }
}
