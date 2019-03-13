using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utility.Extension;
using Xunit;

namespace Utility.Test.Extension
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
            Assert.Equal(default(int), await source.FirstOrDefaultAsync(async value => await value > compare));
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
            Assert.Equal(default(int), await source.FirstOrDefaultAsync(async value => await GreaterThan(value, compare)));
        }

        public static IEnumerable<object[]> GetTaskList()
        {
            yield return new object[] { new[] { Task.FromResult(1), Task.FromResult(2), Task.FromResult(3), Task.FromResult(4), Task.FromResult(5) }, 2, 3 };
            yield return new object[] { new[] { Task.FromResult(3), Task.FromResult(4), Task.FromResult(5) }, 2, 3 };
            yield return new object[] { new[] { Task.FromResult(1), Task.FromResult(2), Task.FromResult(3) }, 2, 3 };
            yield return new object[] { new[] { Task.FromResult(3) }, 2, 3 };
        }

        public static IEnumerable<object[]> GetTaskListResultingDefault()
        {
            yield return new object[] { new[] { Task.FromResult(1), Task.FromResult(2), Task.FromResult(3), Task.FromResult(4), Task.FromResult(5) }, 10 };
            yield return new object[] { new[] { Task.FromResult(3), Task.FromResult(4), Task.FromResult(5) }, 10 };
            yield return new object[] { new[] { Task.FromResult(1), Task.FromResult(2), Task.FromResult(3) }, 10 };
            yield return new object[] { new[] { Task.FromResult(3) }, 10 };
            yield return new object[] { new Task<int>[0], 10 };
        }

        public static IEnumerable<object[]> GetList()
        {
            yield return new object[] { new[] { 1, 2, 3, 4, 5 }, 2, 3 };
            yield return new object[] { new[] { 3, 4, 5 }, 2, 3 };
            yield return new object[] { new[] { 1, 2, 3 }, 2, 3 };
            yield return new object[] { new[] { 3 }, 2, 3 };
        }

        public static IEnumerable<object[]> GetListResultingDefault()
        {
            yield return new object[] { new[] { 1, 2, 3, 4, 5 }, 10 };
            yield return new object[] { new[] { 3, 4, 5 }, 10 };
            yield return new object[] { new[] { 1, 2, 3 }, 10 };
            yield return new object[] { new[] { 3 }, 10 };
            yield return new object[] { new int[0], 10 };
        }

        private static async Task<bool> GreaterThan<T>(IComparable<T> v1, T v2)
        {
            return await Task.FromResult(v1.CompareTo(v2) > 0);
        }
    }
}
