using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.Models
{
    [Table("participant")]
    public class Participant
    {
        [Key]
        [Column("GUID")]
        public Guid Guid { get; set; }

        [Column("competition_guid")]
        public Guid CompetitionGuid { get; set; }

        [Column("user_guid")]
        public Guid UserGuid { get; set; }

        [Column("status", TypeName = "enum('New','Approved','Rejected','Updated')")]
        [DisplayName("Состояние заявки")]
        public ParticipantStatus Status { get; set; }

        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        [Column("nickname")]
        public string Nickname { get; set; }

        [NotMapped]
        public bool Approved => Status == ParticipantStatus.Approved;

        public virtual List<Poem> Poems { get; set; }

        [ForeignKey("CompetitionGuid")]
        public virtual Competition Competition { get; set; }

        [ForeignKey("UserGuid")]
        public virtual User User { get; set; }

        public Participant()
        {
            Guid = Guid.NewGuid();
            CreateDate = DateTime.Now;
        }
    }
    public enum ParticipantStatus
    {
        New,
        Approved,
        Rejected,
        Updated
    }
}
