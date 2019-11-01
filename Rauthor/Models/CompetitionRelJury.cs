using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.Models
{
    public class CompetitionRelJury
    {
        public Guid CompetitionGuid { get; set; }
        public Guid JuryUserGuid { get; set; }

        public User Jury { get; set; }

        public Competition Competition { get; set; }
    }
}
