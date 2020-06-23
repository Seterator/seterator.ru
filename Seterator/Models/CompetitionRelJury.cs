using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Seterator.Models
{
    public class CompetitionRelJury
    {
        public Guid CompetitionGuid { get; set; }
        
        public Guid JuryUserGuid { get; set; }

        public User Jury { get; set; }

        public Competition Competition { get; set; }
    }
}
