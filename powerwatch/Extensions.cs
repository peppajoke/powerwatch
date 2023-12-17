using System;
using System.Collections.Generic;
using System.Linq;
public static class EnumerableExtensions
{
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
        Random random = new Random();
        return source.OrderBy(x => random.Next());
    }
}