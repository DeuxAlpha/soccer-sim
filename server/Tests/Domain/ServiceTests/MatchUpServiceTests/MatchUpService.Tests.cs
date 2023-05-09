using System.Collections.Generic;
using System.Linq;
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
            }, 1);
            Assert.That(roundRobin, Has.Count.EqualTo(5));
        }

        [Test]
        public void CreateRoundRobin_UnEvenTeams_CreatesRoundRobin()
        {
            var roundRobin = MatchUpService.CreateRoundRobin(new List<int>
            {
                1, 2, 3, 4, 5
            }, 1).ToList();

            Assert.That(roundRobin, Has.Count.EqualTo(5));
        }

        [Test]
        public void CreateRoundRobin_EvenTeamsWithReverse_CreatesRoundRobin()
        {
            var roundRobin = MatchUpService.CreateRoundRobin(new List<int>
            {
                1, 2, 3, 4, 5, 6
            }, 2);
            Assert.That(roundRobin, Has.Count.EqualTo(10));
        }

        [Test]
        public void CreateRoundRobin_UnEvenTeamsWithReverse_CreatesRoundRobin()
        {
            var roundRobin = MatchUpService.CreateRoundRobin(new List<int>
            {
                1, 2, 3, 4, 5
            }, 2);
            Assert.That(roundRobin, Has.Count.EqualTo(10));
        }
    }
}