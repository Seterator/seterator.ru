using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Seterator.Models;

namespace Seterator.ViewModels
{
    
    public class AssessmentModel
    {
        public string CompetitionTitle { get; set; }
        public Participant Participant { get; set; }
        public string AuthorName { get; set; }
        public ParticipantAssessment Assessment { get; set; }
    }
}
