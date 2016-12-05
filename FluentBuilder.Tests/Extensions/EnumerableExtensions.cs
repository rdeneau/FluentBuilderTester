using System.Collections.Generic;

namespace FluentBuilder.Tests.Extensions
{
    public static class EnumerableExtensions
    {
        public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source)
        {
            var result = new HashSet<TSource>();
            foreach (var item in source)
            {
                result.Add(item);
            }
            return result;
        }
    }
}
