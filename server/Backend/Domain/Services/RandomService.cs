using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public static class RandomService
    {
        private static readonly Random Random = new Random();

        public static int GetRandomNumber(int start, int end, bool inclusive = true)
        {
            return Random.Next(start, inclusive ? end + 1 : end);
        }

        public static double GetRandomNumber(double start, double end, bool inclusive = true)
        {
            return Random.Next((int) start, inclusive ? (int) end + 1 : (int) end);
        }

        public static double GetRandomBetweenOneAndZero()
        {
            return Random.NextDouble();
        }
    }
}