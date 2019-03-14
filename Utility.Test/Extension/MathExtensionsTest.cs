using System.Collections.Generic;
using Messerli.Utility.Extension;
using Xunit;

namespace Messerli.Utility.Test.Extension
{
    public class MathExtensionsTest
    {
        public static IEnumerable<object[]> PowerExamples()
        {
            yield return new object[] { 2048, 2, 11 };
            yield return new object[] { 1162261467, 3, 19 };
            yield return new object[] { 2121824125, 1285, 3 };
            yield return new object[] { 985436547, 985436547, 1 };
            yield return new object[] { 250000, 500, 2 };
            yield return new object[] { 0, 500, -2 };
            yield return new object[] { 250000, -500, 2 };
            yield return new object[] { -125000000, -500, 3 };

            // exponent 0
            yield return new object[] { 1, 99, 0 };
            yield return new object[] { 1, 36845, 0 };
            yield return new object[] { 1, -36845, 0 };
        }

        [Theory]
        [MemberData(nameof(PowerExamples))]

        public void CalculatesPowersWithIntParameter(int exponentiation, int baseValue, int exponent)
        {
            Assert.Equal(exponentiation, baseValue.Power(exponent));
        }

        public static IEnumerable<object[]> LongPowerExamples()
        {
            yield return new object[] { 2048L, 2L, 11L };
            yield return new object[] { 50031545098999707L, 3L, 35L };
            yield return new object[] { 52645874569852L, 52645874569852L, 1L };

            // exponent 0
            yield return new object[] { 1L, 99L, 0L };
            yield return new object[] { 1L, 36845L, 0L };
        }

        [Theory]
        [MemberData(nameof(LongPowerExamples))]
        public void CalculatesPowersWithLongParameter(long exponentiation, long baseValue, long exponent)
        {
            Assert.Equal(exponentiation, baseValue.Power(exponent));
        }

    }
}
