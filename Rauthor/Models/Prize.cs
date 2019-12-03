using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.Models
{
    [Table("prizes")]
    public class Prize
    {
        [Key]
        [Column("GUID")]
        public Guid Guid { get; set; }

        [Column("competition_guid")]
        public Guid CompetitionGuid { get; set; }

        [Column("begin_place")]
        public int BeginPlace { get; set; }
        
        [Column("end_place")]
        public int EndPlace { get; set; }

        [Column("value")]
        public string Value { get; set; }
    }
}
