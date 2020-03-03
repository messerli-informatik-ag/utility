using Xunit;

namespace Messerli.Utility.Test
{
    public sealed class EnumerableTest
    {
        [Fact]
        public void RangeTest()
        {
            foreach (var i in Enumerable.Range(50031545098999707L, 50031545098999755L))
            {
                Assert.InRange(i, 50031545098999707L, 50031545098999755L - 1);
            }
        }
    }
}
