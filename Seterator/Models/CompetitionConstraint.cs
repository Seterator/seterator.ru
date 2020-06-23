    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Seterator.Models
{
    public class CompetitionConstraint
    {
        [Key]
        public Guid Guid { get; set; }
        
        public Guid CompetitionGuid { get; set; }

        public string CheckedValue { get; set; }

        public int Min { get; set; }

        public int Max { get; set; }
    }
}
