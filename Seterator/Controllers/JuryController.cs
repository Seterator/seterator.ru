using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Seterator.Models;
using Seterator.ViewModels;

namespace Seterator.Controllers
{
    public class JuryController : Controller
    {
        DatabaseContext database;
        public JuryController(DatabaseContext database)
        {
            this.database = database;
        }
        
        /// <param name="guid">Guid участника</param>
        [HttpGet]
        [Authorize]
        public IActionResult Assessment(Guid guid)
        {
            var participant = database.Participants
                .Include(x => x.User)
                .Include(x => x.Poems)
                .Include(x => x.Competition)
                .First(x => x.Guid == guid);
            var assesment = database.ParticipantAssessments.Where(x => x.ParticipantGuid == participant.Guid).FirstOrDefault();
            var model = new AssessmentModel()
            {
                CompetitionTitle = participant.Competition.Title,
                Participant = participant,
                AuthorName = participant.User.Login,
                Assessment = assesment
            };
            return View(model);

        }

        //[HttpGet]
        //[Authorize]
        //public IActionResult Assessment()
        //{
        //    var participant = database.Participants
        //        .Include(x => x.User)
        //        .Include(x => x.Poems)
        //        .Include(x => x.Competition)
        //        .Where(x => (database.ParticipantAssessments.FirstOrDefault(a => a.ParticipantGuid == x.Guid) == null))
        //        .First();
        //    return Redirect($"/Jury/Assessment/{participant.Guid}");

        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid">Guid участника</param>
        /// <param name="model">Оценка</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public IActionResult Assessment([FromRoute] [FromQuery] Guid guid, [FromForm] ParticipantAssessment model)
        {
            var participant = database.Participants.First(x => x.Guid == guid);
            database.ParticipantAssessments.Add(new ParticipantAssessment()
            {
                Assessment = model.Assessment,
                ParticipantGuid = guid
            });
            database.SaveChanges();
            return RedirectToAction("Assessment", new { guid = guid });
        }
    }
}
