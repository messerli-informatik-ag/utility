using System.Collections.Generic;

namespace Update.Shared.Utility
{
    public static class Enumerable
    {
        public static IEnumerable<short> Range(short from, short to)
        {
            while (from < to)
            {
                yield return from++;
            }
        }

        public static IEnumerable<ushort> Range(ushort from, ushort to)
        {
            while (from < to)
            {
                yield return from++;
            }
        }

        public static IEnumerable<int> Range(int from, int to)
        {
            while (from < to)
            {
                yield return from++;
            }
        }

        public static IEnumerable<uint> Range(uint from, uint to)
        {
            while (from < to)
            {
                yield return from++;
            }
        }

        public static IEnumerable<long> Range(long from, long to)
        {
            while (from < to)
            {
                yield return from++;
            }
        }

        public static IEnumerable<ulong> Range(ulong from, ulong to)
        {
            while (from < to)
            {
                yield return from++;
            }
        }
    }
}
