using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Seterator.Models
{
    public class CompetitionRelCategory
    {
        public Guid CompetitionGuid { get; set; }
        
        public Guid CategoryGuid { get; set; }

        public Competition Competition { get; set; }

        public CompetitionCategory Category { get; set; }
    }
}
