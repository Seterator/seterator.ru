using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rauthor.Models
{
    [Table("competition")]
    public class Competition
    {
        private string json;
        [Key]
        [Column("GUID")]
        public Guid Guid { get; set; }

        [Column("title")]
        public string Titile { get; set; }

        /// <summary>
        /// Дата окончания приёма заявок
        /// </summary>
        [Column("start_date")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата публикации результата
        /// </summary>
        [Column("end_date")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Описание соревнования
        /// </summary>
        [Column("description")]
        public string Description { get; set; }

        public virtual List<Participant> Participants { get; set; }


        [NotMapped]
        public JsonDocument Conditions
        {
            get => JsonDocument.Parse(json);
        }
        public Competition()
        {
            Guid = Guid.NewGuid();
        }
    }
}
