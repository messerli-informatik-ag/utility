using Messerli.Utility.Extension;
using Xunit;

namespace Messerli.Utility.Test.Extension
{
    public class MathExtensionsTest
    {
        public static TheoryData<int, int, int> PowerExamples()
        {
            return new TheoryData<int, int, int>
            {
                { 2048, 2, 11 },
                { 1162261467, 3, 19 },
                { 2121824125, 1285, 3 },
                { 985436547, 985436547, 1 },
                { 250000, 500, 2 },
                { 0, 500, -2 },
                { 250000, -500, 2 },
                { -125000000, -500, 3 },
                // exponent 0
                { 1, 99, 0 },
                { 1, 36845, 0 },
                { 1, -36845, 0 },
            };
        }

        [Theory]
        [MemberData(nameof(PowerExamples))]

        public void CalculatesPowersWithIntParameter(int exponentiation, int baseValue, int exponent)
        {
            Assert.Equal(exponentiation, baseValue.Power(exponent));
        }

        public static TheoryData<long, long, long> LongPowerExamples()
        {
            return new TheoryData<long, long, long>
            {
                { 2048L, 2L, 11L },
                { 50031545098999707L, 3L, 35L },
                { 52645874569852L, 52645874569852L, 1L },
                // exponent 0
                { 1L, 99L, 0L },
                { 1L, 36845L, 0L },
            };
        }

        [Theory]
        [MemberData(nameof(LongPowerExamples))]
        public void CalculatesPowersWithLongParameter(long exponentiation, long baseValue, long exponent)
        {
            Assert.Equal(exponentiation, baseValue.Power(exponent));
        }
    }
}
