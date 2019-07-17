using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.Models
{
    [Table("competition")]
    public class Competition
    {
        [Key] [Column("GUID")] public Guid Guid { get; set; }

        [Column("title")] public string Titile { get; set; }

        [Column("start_date")] public DateTime StartDate { get; set; }

        [Column("end_date")] public DateTime EndDate { get; set; }

        public List<Participant> Participants { get; /*set;*/ }

        public Competition()
        {
            Guid = Guid.NewGuid();
        }
    }
}
