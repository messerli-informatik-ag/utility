using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Messerli.Utility.Extension
{
    public static class FirstOrDefaultAsyncExtension
    {
        public static async Task<TSource> FirstOrDefaultAsync<TSource>(this IEnumerable<Task<TSource>> source,
            Func<Task<TSource>, Task<bool>> predicate)
        {
            foreach (var item in source)
            {
                if (await predicate(item))
                {
                    return await item;
                }
            }

            return await Task.FromResult(default(TSource));
        }

        public static async Task<TSource> FirstOrDefaultAsync<TSource>(this IEnumerable<TSource> source,
            Func<TSource, Task<bool>> predicate)
        {
            foreach (var item in source)
            {
                if (await predicate(item))
                {
                    return item;
                }
            }

            return await Task.FromResult(default(TSource));
        }
    }
}