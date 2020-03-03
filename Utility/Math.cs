namespace Messerli.Utility
{
    public static class Math
    {
        public static int Difference(int minuend, int subtrahend)
            => Δ(minuend, subtrahend);

        public static long Difference(long minuend, long subtrahend)
            => Δ(minuend, subtrahend);

        public static int Δ(int minuend, int subtrahend)
            => minuend - subtrahend;

        public static long Δ(long minuend, long subtrahend)
            => minuend - subtrahend;
    }
}
