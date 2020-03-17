using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Messerli.Utility.Extension;
using Xunit;

namespace Messerli.Utility.Test.Extension
{
    public sealed class TypeExtensionTest
    {
        [Theory]
        [InlineData(typeof(IQueryable))]
        [InlineData(typeof(IQueryable<>))]
        [InlineData(typeof(IQueryable<object>))]
        [InlineData(typeof(IQueryable<int>))]
        [InlineData(typeof(IQueryable<Type>))]
        public void QueryableIsQueryable(Type type)
        {
            Assert.True(type.IsQueryable());
        }

        [Theory]
        [InlineData(typeof(IEnumerable))]
        [InlineData(typeof(IEnumerable<>))]
        [InlineData(typeof(IEnumerable<object>))]
        [InlineData(typeof(IEnumerable<int>))]
        [InlineData(typeof(IEnumerable<Type>))]
        public void EnumerableIsEnumerable(Type type)
        {
            Assert.True(type.IsEnumerable());
        }
    }
}
