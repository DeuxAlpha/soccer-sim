using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)
        {
            return list.OrderBy(item => Guid.NewGuid());
        }
    }
}