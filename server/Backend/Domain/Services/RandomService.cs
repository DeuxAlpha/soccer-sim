using System;

namespace Domain.Services
{
    public static class RandomService
    {
        private static readonly Random Random = new Random();

        public static int GetRandomNumber(int start, int end, bool inclusive = true)
        {
            return Random.Next(start, inclusive ? end + 1 : end);
        }

        public static double GetRandomBetweenOneAndZero()
        {
            return Random.NextDouble();
        }
    }
}