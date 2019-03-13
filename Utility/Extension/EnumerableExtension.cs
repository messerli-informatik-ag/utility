using System;
using System.Collections.Generic;

namespace Update.Shared.Utility.Extension
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
    }
}
