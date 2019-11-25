using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.Models
{
    [Table("competition_categories")]
    public class CompetitionCategory
    {
        [Key]
        [Column("GUID")]
        public Guid Guid { get; set; }

        /// <summary>
        /// Название категории
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        public List<CompetitionRelCategory> Competitions { get; set; }
        public CompetitionCategory()
        {
            Competitions = new List<CompetitionRelCategory>();
        }
    }
}
