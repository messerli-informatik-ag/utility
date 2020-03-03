namespace Messerli.Utility.Extension
{
    public static class MathExtension
    {
        public static int Power(this int value, int exponent)
        {
            return Π(value, exponent);
        }

        public static long Power(this long value, long exponent)
        {
            return Π(value, exponent);
        }

        public static int Π(this int value, int exponent)
        {
            return (int)Π((long)value, exponent);
        }

        public static long Π(this long value, long exponent)
        {
            if (exponent < 0)
            {
                return 0;
            }

            if (exponent == 0)
            {
                return 1;
            }

            var m = Π(value, exponent / 2);

            if (exponent % 2 == 0)
            {
                return m * m;
            }

            return value * m * m;
        }
    }
}
