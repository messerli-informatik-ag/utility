using System.Linq;
using System.Threading.Tasks;
using Messerli.Utility.Extension;
using Xunit;

namespace Messerli.Utility.Test.Extension
{
    public sealed class EnumerableExtensionTest
    {
        [Fact]
        public void ForEachExecutesAction()
        {
            var elements = System.Linq.Enumerable.Repeat(new ForEachExecutor(), 17);

            // ReSharper disable once PossibleMultipleEnumeration
            elements.ForEach(element => element.Execute());

            // ReSharper disable once PossibleMultipleEnumeration
            Assert.True(elements.All(element => element.SideEffect));
        }

        [Fact]
        public async Task ForEachExecutesActionAsync()
        {
            var elements = System.Linq.Enumerable.Repeat(new ForEachExecutor(), 17);

            // ReSharper disable once PossibleMultipleEnumeration
            await elements.ForEachAsync(element => element.ExecuteAsync());

            // ReSharper disable once PossibleMultipleEnumeration
            Assert.True(elements.All(element => element.SideEffect));
        }

        private class ForEachExecutor
        {
            public bool SideEffect { get; private set; }

            public void Execute()
                => SideEffect = true;

            public Task ExecuteAsync()
                => Task.Run(Execute);
        }
    }
}
