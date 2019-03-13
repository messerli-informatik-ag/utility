using System.Collections.Generic;
using Xunit;

namespace Utility.Utility.Test
{
    public class MathTest
    {
        public static IEnumerable<object[]> DifferenceExamples()
        {
            yield return new object[] { 334, 1000, 666 };
            yield return new object[] { 254332385, 254873654, 541269 };
            yield return new object[] { -100, 200, 300 };
            yield return new object[] { -78862, 789654, 868516 };
        }

        [Theory]
        [MemberData(nameof(DifferenceExamples))]
        public void CalculateDifferenceWithIntParameters(int difference, int minuend, int subtrahend)
        {
            Assert.Equal(difference, Math.Δ(minuend, subtrahend));
        }

        [Theory]
        [MemberData(nameof(DifferenceExamples))]
        public void CalculateDifferenceWithLongParameters(long difference, long minuend, long subtrahend)
        {
            Assert.Equal(difference, Math.Δ(minuend, subtrahend));
        }
    }
}
