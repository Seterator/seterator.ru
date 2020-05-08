using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Seterator.Models
{
    public class CompetitionCategory
    {
        [Key]
        public Guid Guid { get; set; }

        /// <summary>
        /// Название категории
        /// </summary>
        public string Name { get; set; }

        public List<CompetitionRelCategory> Competitions { get; set; }
        public CompetitionCategory()
        {
            Competitions = new List<CompetitionRelCategory>();
        }
    }
}
