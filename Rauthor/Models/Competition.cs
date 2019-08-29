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

        [Column("event_size", TypeName = "enum('normal','large')")]
        public EventSize EventSize { get; set; }

        public virtual List<Participant> Participants { get; set; }


        public Competition()
        {
            Guid = Guid.NewGuid();
        }
    }
    public enum EventSize
    {
        Normal,
        Large
    }
}
