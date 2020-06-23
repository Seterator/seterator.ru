using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Seterator.Models
{
    public class Prize
    {
        [Key]
        public Guid Guid { get; set; }

        public Guid CompetitionGuid { get; set; }

        public int BeginPlace { get; set; }
        
        public int EndPlace { get; set; }

        public string Value { get; set; }
    }
}
