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
            var roundRobin = MatchUpService.CreateRoundRobin(6, false);
            Assert.That(roundRobin, Has.Count.EqualTo(5));
        }

        [Test]
        public void CreateRoundRobin_UnEvenTeams_CreatesRoundRobin()
        {
            var roundRobin = MatchUpService.CreateRoundRobin(5, false);
            Assert.That(roundRobin, Has.Count.EqualTo(5));
        }

        [Test]
        public void CreateRoundRobin_EvenTeamsWithReverse_CreatesRoundRobin()
        {
            var roundRobin = MatchUpService.CreateRoundRobin(6, true);
            Assert.That(roundRobin, Has.Count.EqualTo(10));
        }

        [Test]
        public void CreateRoundRobin_UnEvenTeamsWithReverse_CreatesRoundRobin()
        {
            var roundRobin = MatchUpService.CreateRoundRobin(5, true);
            Assert.That(roundRobin, Has.Count.EqualTo(10));
        }
    }
}