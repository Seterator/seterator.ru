using Microsoft.EntityFrameworkCore;
using Rauthor.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.ViewModels
{
    public class ProfileModel
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public int Rating { get; set; }
        public bool Verificated { get; set; }
        public string Status { get; set; }
        public string About { get; set; }
        /// <summary>
        /// Все заявки пользователя. Poems не загружены.
        /// </summary>
        public IEnumerable<Participant> Participants { get; }
        public IEnumerable<Competition> ParticipatedCompetitions { get; }

        public int ParticipantCount { get; set; }
        public int WinCount { get; set; }

        /// <summary>
        /// Заявки на конкурсы, которые ещё не прошли
        /// </summary>
        public IEnumerable<Participant> ActiveParticipants { get; set; }

        public IEnumerable<Participant> PastParticipants { get; set; }

        public ProfileModel(
            string login,
            int rating,
            bool verificated,
            string name=null,
            string status=null,
            string about=null,
            IEnumerable<Participant> participants=null,
            IEnumerable<Competition> participatedCompetitions=null)
        {
            Login = login;
            Rating = rating;
            Verificated = verificated;
            Name = name;
            Status = status;
            About = about;
            Participants = participants;
            ParticipatedCompetitions = participatedCompetitions;
        }
        public static ProfileModel ReadFromDatabase(Guid userGuid, DatabaseContext database)
        {
            Contract.Assert(database != null);
            var user = database.Users.FirstOrDefault(u => u.Guid == userGuid);
            database.Participants.Include(x => x.Votes).Where(p => p.UserGuid == userGuid).Load();
            
            if (user.Participants != null)
                database.Competitions.Where(c => user.Participants
                    .DefaultIfEmpty()
                    .Select(p => p.CompetitionGuid)
                    .Contains(c.Guid)).Load();
            var profile = new ProfileModel(
                user.Login,
                rating: user.Participants?.Sum(p => p.UserScore) ?? 0,
                verificated: false,
                participants: user.Participants?.Where(p => !p.Approved) ?? new List<Participant>(),
                participatedCompetitions: database.Participants
                                              .Include(x => x.Poems)
                                              .Where(p => p.Approved && p.UserGuid == userGuid)
                                              .Select(p => p.Competition))
            {
                ActiveParticipants = database.Participants
                    .Include(x => x.Poems)
                    .Include(x => x.Competition)
                    .Where(x => x.UserGuid == user.Guid)
                    .Where(x => x.Competition.EndDate > DateTime.Now)
                    .OrderBy(x => x.CreateDate),
                PastParticipants = database.Participants
                    .Include(x => x.Poems)
                    .Include(x => x.Competition)
                    .Where(x => x.UserGuid == user.Guid)
                    .Where(x => x.Competition.EndDate <= DateTime.Now)
                    .OrderBy(x => x.CreateDate),
            }; ;
            profile.WinCount = 0;
            profile.ParticipantCount = profile.Participants.Count();
            return profile;
        }
    }
}
