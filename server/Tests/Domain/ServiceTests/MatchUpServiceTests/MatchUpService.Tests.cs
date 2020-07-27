using System.Collections.Generic;
using Domain.Services;
using NUnit.Framework;

namespace Tests.Domain.ServiceTests.MatchUpServiceTests
{
    [TestFixture]
    public class MatchUpServiceTests
    {
        [Test]
        public void CreateRoundRobin_EvenTeams_CreatesRoundRobin()
        {
            var roundRobin = MatchUpService.CreateRoundRobin(new List<int>
            {
                1, 2, 3, 4, 5, 6
            }, false);
            Assert.That(roundRobin, Has.Count.EqualTo(5));
        }

        [Test]
        public void CreateRoundRobin_UnEvenTeams_CreatesRoundRobin()
        {
            var roundRobin = MatchUpService.CreateRoundRobin(new List<int>
            {
                1, 2, 3, 4, 5
            }, false);
            Assert.That(roundRobin, Has.Count.EqualTo(5));
        }

        [Test]
        public void CreateRoundRobin_EvenTeamsWithReverse_CreatesRoundRobin()
        {
            var roundRobin = MatchUpService.CreateRoundRobin(new List<int>
            {
                1, 2, 3, 4, 5, 6
            }, true);
            Assert.That(roundRobin, Has.Count.EqualTo(10));
        }

        [Test]
        public void CreateRoundRobin_UnEvenTeamsWithReverse_CreatesRoundRobin()
        {
            var roundRobin = MatchUpService.CreateRoundRobin(new List<int>
            {
                1, 2, 3, 4, 5
            }, true);
            Assert.That(roundRobin, Has.Count.EqualTo(10));
        }
    }
}