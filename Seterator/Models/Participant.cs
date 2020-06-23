using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Seterator.Models
{
    public class Participant
    {
        [Key]
        public Guid Guid { get; set; }

        public Guid CompetitionGuid { get; set; }

        public Guid UserGuid { get; set; }

        [DisplayName("Состояние заявки")]
        public ParticipantStatus Status { get; set; }

        public DateTime CreateDate { get; set; }

        public string Nickname { get; set; }

        [NotMapped]
        public bool Approved => Status == ParticipantStatus.Approved;

        public virtual List<Poem> Poems { get; set; }

        public virtual Competition Competition { get; set; }

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
