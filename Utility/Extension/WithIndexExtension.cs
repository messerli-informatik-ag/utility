using System.Collections.Generic;
using System.Linq;

namespace Messerli.Utility.Extension
{
    public static class WithIndexExtension
    {
        public static IEnumerable<(T Value, int Index)> WithIndex<T>(this IEnumerable<T> collection)
            => collection.Select((t, index) => (t, index));
    }
}
