using Xunit;

namespace Utility.Test
{
    public class EnumerableTest
    {
        [Fact]
        public void RangeTest()
        {
            foreach (long i in Enumerable.Range(50031545098999707L, 50031545098999755L))
            {
                Assert.InRange(i, 50031545098999707L, 50031545098999755L - 1);
            }
        }
    }
}
