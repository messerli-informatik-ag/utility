using System.Collections.Generic;
using Xunit;

namespace Messerli.Utility.Test
{
    public class MathTest
    {
        public static TheoryData<int, int, int> DifferenceExamples()
        {
            return new TheoryData<int, int, int>
            {
                { 334, 1000, 666 },
                { 254332385, 254873654, 541269 },
                { -100, 200, 300 },
                { -78862, 789654, 868516 },
            };
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
