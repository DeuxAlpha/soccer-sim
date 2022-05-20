using System;
using Domain.Infer;
using NUnit.Framework;

namespace Tests.Domain.Infer
{
    [TestFixture]
    public class StrengthAssignerSpecs
    {
        [Test]
        public void TestStrengthAssigner_ValidValues_ReturnsStrengthResponse()
        {
            var strengthResponse = StrengthAssigner.AssignStrengths(new StrengthRequest
            {
                AverageStrength = 1000,
                StrengthVariance = 200,
                WinnerIds = new [] {0, 2, 4, 6},
                LoserIds = new [] {1, 3, 5, 7}
            });

            Console.WriteLine(strengthResponse);
        }
    }
}