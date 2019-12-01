using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;
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
        public string Title { get; set; }

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

        /// <summary>
        /// Короткое описание соревнования
        /// </summary>
        [Column("short_description")]
        public string ShortDesctiption { get; set; }

        [ForeignKey("CompetitionGuid")]
        public List<Prize> Prizes { get; set; }

        public virtual List<Participant> Participants { get; set; }

        public virtual List<CompetitionRelCategory> Categories { get; set; }

        public virtual List<CompetitionConstraint> Constraints { get; set; }

        public virtual List<CompetitionRelJury> Jury { get; set; }

        public Competition()
        {
            Participants = new List<Participant>();
            Categories = new List<CompetitionRelCategory>();
            Jury = new List<CompetitionRelJury>();
            Constraints = new List<CompetitionConstraint>();
        }

        /// <summary>
        /// Возвращает экземпляр Competition с заполненными полями и навигационными свойствами, на основе
        /// модели представления.
        /// </summary>
        public static Competition FromApiViewModel(ViewModels.Api.Competition viewModel)
        {
            var competition = new Competition()
            {
                Guid = viewModel.Guid ?? default,
                Constraints = viewModel.Constraints,
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
                Description = viewModel.Description,
                ShortDesctiption = viewModel.ShortDescription,
                Prizes = viewModel.Prizes.ToString(),
                Title = viewModel.Title,
            };
            var juryRefernces = viewModel.JuryGuids.Select(juryGuid => new CompetitionRelJury()
            {
                CompetitionGuid = competition.Guid,
                JuryUserGuid = juryGuid
            });
            var categoryReferences = viewModel.Categories.Select(categoryGuid => new CompetitionRelCategory()
            {
                CompetitionGuid = competition.Guid,
                CategoryGuid = categoryGuid
            });
            competition.Jury = juryRefernces.ToList();
            competition.Categories = categoryReferences.ToList();
            return competition;
        }
    }
}
