using Seterator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seterator.ViewModels.Api
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

        public List<Participant>? Participants { get; set; }

        public Competition()
        {
            JuryGuids = new List<Guid>();
            Constraints = new List<CompetitionConstraint>();
            Categories = new List<Guid>();
            ManagerSocialLinks = new List<string>();
            Participants = new List<Participant>();
        }

        public User Creator { get; set; }

        public static Competition FromEntity(Models.Competition competition)
        {
            var @new = new Competition();
            @new.Categories = competition.Categories.Select(x => x.CategoryGuid).ToList();
            @new.Constraints = competition.Constraints;
            @new.Description = competition.Description;
            @new.EndDate = competition.EndDate;
            @new.Guid = competition.Guid;
            @new.JuryGuids = competition.Jury.Select(x => x.JuryUserGuid).ToList();
            @new.Prizes = competition.Prizes;
            @new.ShortDescription = competition.ShortDescription;
            @new.StartDate = competition.StartDate;
            @new.Title = competition.Title;
            @new.Participants = competition.Participants;
            @new.Creator = competition.Creator;
            return @new;
        }
    }
}
