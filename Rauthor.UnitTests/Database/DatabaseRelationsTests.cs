using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Xunit;

namespace Rauthor.UnitTests.Database
{
    public class RelationsWorking : DatabaseTest
    {
        protected void AssertMany<T>(IEnumerable<T> references)
        {
            Assert.NotNull(references);
        }
        
        protected void AssertOne<T>(T reference)
        {
            Assert.NotNull(reference);
        }
        
        [Fact]
        public void CompetitionRelationsWorking()
        {
            var entity = Database.Competitions
                .Include(x => x.Categories)
                .Include(x => x.Constraints)
                .Include(x => x.Participants);
            Assert.All(entity, item =>
            {
                AssertMany(item.Categories);
                AssertMany(item.Constraints);
                AssertMany(item.Participants);
            });
        }

        [Fact]
        public void ParticipantRelationsWorking()
        {
            var entity = Database.Participants
                .Include(x => x.Poems)
                .Include(x => x.Competition)
                .Include(x => x.User);
            Assert.All(entity, item =>
            {
                AssertMany(item.Poems);
                AssertOne(item.Competition);
                AssertOne(item.User);
            });
        }

        [Fact]
        public void ParticipantAssessmentRelationsWorking()
        {
            var entity = Database.ParticipantAssessments
                .Include(x => x.Participant);
            Assert.All(entity, item =>
            {
                AssertOne(item.Participant);
            });
        }

        [Fact]
        public void PoemRelationsWorking()
        {
            var entity = Database.Poems
                .Include(x => x.Author);
            Assert.All(entity, item =>
            {
                AssertOne(item.Author);
            });
        }

        [Fact]
        public void RoleRelationsWorking()
        {
            var entity = Database.Roles
                .Include(x => x.User);
            Assert.All(entity, item =>
            {
                AssertOne(item.User);
            });
        }

        [Fact]
        public void UserRelationsWorking()
        {
            var entity = Database.Users
                .Include(x => x.Participants)
                .Include(x => x.Roles);
            Assert.All(entity, item =>
            {
                AssertMany(item.Roles);
                AssertMany(item.Participants);
            });
        }
    }
}
