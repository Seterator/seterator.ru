using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.Models
{
    public class CompetitionRelCategory
    {
        public Guid CompetitionGuid { get; set; }
        public Guid CategoryGuid { get; set; }

        [ForeignKey("CompetitionGuid")]
        public Competition Competition { get; set; }

        [ForeignKey("CategoryGuid")]
        public CompetitionCategory Category { get; set; }
    }
}
