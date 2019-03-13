using System.Collections.Generic;
using System.Linq;

namespace Update.Shared.Utility.Extension
{
    public static class WithIndexExtension
    {
        public static IEnumerable<(T, int)> WithIndex<T>(this IEnumerable<T> collection)
        {
            return collection.Select((t, index) => (t, index));
        }
    }
}
