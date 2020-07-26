using Domain.Models;
using Domain.Services;
using NUnit.Framework;

namespace Tests.Domain.ServiceTests.GameServiceTests
{
    [TestFixture]
    public class GameServiceTests
    {
        [Test]
        [TestCase(1000, 1200)]
        [TestCase(0, 0)]
        [TestCase(-50, 100)]
        [TestCase(200000, -200000)]
        public void ExecuteSimulation_ValidParameters_DoesNotCrash(int homeStrength, int awayStrength)
        {
            GameService.CalculateGame_v1(new TeamLineUp
            {
                Strength = homeStrength
            }, new TeamLineUp
            {
                Strength = awayStrength
            });
            Assert.Pass("Simulation did not fail.");
        }
    }
}