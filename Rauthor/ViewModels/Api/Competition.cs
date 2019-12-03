using Rauthor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.ViewModels.Api
{
    /// <summary>
    /// Модель используемая api-контроллером соревнований.
    /// </summary>
    public class Competition
    {
        /// <summary>
        /// Guid конкурса
        /// </summary>
        public Guid? Guid { get; set; }

        /// <summary>
        /// Номер телефона организатора
        /// </summary>
        public string ManagerPhoneNumber { get; set; }

        /// <summary>
        /// Электронная почта организатора
        /// </summary>
        public string ManagerEmail { get; set; }
        
        /// <summary>
        /// Социальные сети организатора
        /// </summary>
        public List<string> ManagerSocialLinks { get; set; }

        /// <summary>
        /// Категория конкурса
        /// </summary>
        public List<Guid> Categories { get; set; }

        /// <summary>
        /// НАзвание конкурса
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Короткое описание конкурса
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// Полное описание конкурса
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Условия конкурса
        /// </summary>
        public List<CompetitionConstraint> Constraints { get; set; }

        /// <summary>
        /// Призовые места
        /// </summary>
        public List<Prize> Prizes { get; set; }

        /// <summary>
        /// Guid'ы жюри конкурса
        /// </summary>
        public List<Guid> JuryGuids { get; set; }

        /// <summary>
        /// Дата публикации конкурса
        /// </summary>
        public DateTime PublicationDate { get; set; }

        /// <summary>
        /// Дата начала приёма заявок
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата окончания приёма заявок
        /// </summary>
        public DateTime EndDate { get; set; }

        public Competition()
        {
            JuryGuids = new List<Guid>();
            Constraints = new List<CompetitionConstraint>();
            Categories = new List<Guid>();
            ManagerSocialLinks = new List<string>();
        }
    }
}
