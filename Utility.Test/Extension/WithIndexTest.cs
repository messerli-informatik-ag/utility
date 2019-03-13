using System.Linq;
using Utility.Extension;
using Xunit;

namespace Utility.Test.Extension
{
    public class WithIndexTest
    {
        [Fact]
        public void IsEmptyWhenCalledOnEmptyEnumerable()
        {
            var withIndex = new int[0].WithIndex();
            Assert.Empty(withIndex);
        }

        [Fact]
        public void HasCorrectCount()
        {
            var withIndex = new[] { "a", "b" }.WithIndex();
            Assert.Equal(2, withIndex.Count());
        }

        [Fact]
        public void HasCorrectTuple()
        {
            var withIndexElements = new[] { "a", "b", "c" }.WithIndex().ToArray();

            var (firstElement, firstIndex) = withIndexElements[0];
            Assert.Equal("a", firstElement);
            Assert.Equal(0, firstIndex);

            var (secondElement, secondIndex) = withIndexElements[1];
            Assert.Equal("b", secondElement);
            Assert.Equal(1, secondIndex);

            var (thirdElement, thirdIndex) = withIndexElements[2];
            Assert.Equal("c", thirdElement);
            Assert.Equal(2, thirdIndex);

        }
    }
}
