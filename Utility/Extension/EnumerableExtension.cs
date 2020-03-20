using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messerli.Utility.Extension
{
    public static class EnumerableExtension
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (var item in enumeration)
            {
                action(item);
            }
        }

        public static async Task ForEachAsync<T>(this IEnumerable<T> enumeration, Func<T, Task> asyncAction)
        {
            foreach (var item in enumeration)
            {
                await asyncAction(item);
            }
        }
    }
}
