using System.Collections.Generic;
using Domain.Services;

namespace Domain.Extensions
{
    public static class ListExtensions
    {
        public static T PopRandom<T>(this List<T> list)
        {
            var randomIndex = RandomService.GetRandomNumber(0, list.Count - 1);
            var randomItem = list[randomIndex];
            list.Remove(randomItem);
            return randomItem;
        }
    }
}