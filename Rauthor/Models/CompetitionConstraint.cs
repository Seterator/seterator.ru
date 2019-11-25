    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.Models
{
    [Table("competition_constraints")]
    public class CompetitionConstraint
    {
        [Key]
        [Column("GUID")]
        public Guid Guid { get; set; }
        
        [Column("competition_guid")]
        public Guid CompetitionGuid { get; set; }

        [Column("checked_value")]
        public string CheckedValue { get; set; }

        [Column("min")]
        public int Min { get; set; }

        [Column("max")]
        public int Max { get; set; }
    }
}
