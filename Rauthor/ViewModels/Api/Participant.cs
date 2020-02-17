using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.ViewModels.Api
{
    public class ParticipantPost
    {
        /// <summary>
        /// Guid соревнования, в котором собирается участвовать пользователь.
        /// </summary>
        public Guid Guid { get; set; }
        /// <summary>
        /// Название произведения.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Псевдоним пользователя.
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// Текст произведения.
        /// </summary>
        public string Poem { get; set; }
    }

    public class ParticipantPostResult
    {
        /// <summary>
        /// Guid созданной заявки на участие в конкурсе.
        /// </summary>
        public Guid CreatedParticipantGuid { get; set; }
        /// <summary>
        /// Guid-ы произведений, связанных с этой заявкой.
        /// </summary>
        public List<Guid> PoemGuids { get; set; }
    }
}
