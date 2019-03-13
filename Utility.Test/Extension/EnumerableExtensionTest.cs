using System.Linq;
using Update.Shared.Utility.Extension;
using Xunit;

namespace Update.Shared.Utility.Test.Extension
{
    public class EnumerableExtensionTest
    {
        private class ForEachExecutor
        {
            public bool SideEffect { get; private set; }

            public void Execute()
            {
                SideEffect = true;
            }
        }

        [Fact]
        public void ForEachExecutesAction()
        {
            var elements = System.Linq.Enumerable.Repeat(new ForEachExecutor(), 17);

            // ReSharper disable once PossibleMultipleEnumeration
            elements.ForEach(element => element.Execute());

            // ReSharper disable once PossibleMultipleEnumeration
            Assert.True(elements.All(element => element.SideEffect));
        }
    }
}
