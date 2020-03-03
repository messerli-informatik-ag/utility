using System;
using System.Threading.Tasks;
using Messerli.Utility.Extension;
using Xunit;

namespace Messerli.Utility.Test.Extension
{
    public class FirstOrDefaultAsyncTest
    {
        [Theory]
        [MemberData(nameof(GetTaskList))]
        public async void ReturnsFirstMatchingTask(Task<int>[] source, int compare, int result)
        {
            Assert.Equal(result, await source.FirstOrDefaultAsync(async value => await value > compare));
        }

        [Theory]
        [MemberData(nameof(GetTaskListResultingDefault))]
        public async void ReturnsDefaultTask(Task<int>[] source, int compare)
        {
            Assert.Equal(default, await source.FirstOrDefaultAsync(async value => await value > compare));
        }

        [Theory]
        [MemberData(nameof(GetList))]
        public async void ReturnsFirstMatching(int[] source, int compare, int result)
        {
            Assert.Equal(result, await source.FirstOrDefaultAsync(async value => await GreaterThan(value, compare)));
        }

        [Theory]
        [MemberData(nameof(GetListResultingDefault))]
        public async void ReturnsDefault(int[] source, int compare)
        {
            Assert.Equal(default, await source.FirstOrDefaultAsync(async value => await GreaterThan(value, compare)));
        }

        public static TheoryData<Task<int>[], int, int> GetTaskList()
            => new TheoryData<Task<int>[], int, int>
            {
                { new[] { Task.FromResult(1), Task.FromResult(2), Task.FromResult(3), Task.FromResult(4), Task.FromResult(5) }, 2, 3 },
                { new[] { Task.FromResult(3), Task.FromResult(4), Task.FromResult(5) }, 2, 3 },
                { new[] { Task.FromResult(1), Task.FromResult(2), Task.FromResult(3) }, 2, 3 },
                { new[] { Task.FromResult(3) }, 2, 3 },
            };

        public static TheoryData<Task<int>[], int> GetTaskListResultingDefault()
            => new TheoryData<Task<int>[], int>
            {
                { new[] { Task.FromResult(1), Task.FromResult(2), Task.FromResult(3), Task.FromResult(4), Task.FromResult(5) }, 10 },
                { new[] { Task.FromResult(3), Task.FromResult(4), Task.FromResult(5) }, 10 },
                { new[] { Task.FromResult(1), Task.FromResult(2), Task.FromResult(3) }, 10 },
                { new[] { Task.FromResult(3) }, 10 },
                { new Task<int>[0], 10 },
            };

        public static TheoryData<int[], int, int> GetList()
            => new TheoryData<int[], int, int>
            {
                { new[] { 1, 2, 3, 4, 5 }, 2, 3 },
                { new[] { 3, 4, 5 }, 2, 3 },
                { new[] { 1, 2, 3 }, 2, 3 },
                { new[] { 3 }, 2, 3 },
            };

        public static TheoryData<int[], int> GetListResultingDefault()
            => new TheoryData<int[], int>
            {
                { new[] { 1, 2, 3, 4, 5 }, 10 },
                { new[] { 3, 4, 5 }, 10 },
                { new[] { 1, 2, 3 }, 10 },
                { new[] { 3 }, 10 },
                { new int[0], 10 },
            };

        private static Task<bool> GreaterThan<T>(IComparable<T> v1, T v2)
            => Task.FromResult(v1.CompareTo(v2) > 0);
    }
}
