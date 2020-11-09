using System;
using Messerli.Utility.Exception;
using Xunit;

namespace Messerli.Utility.Test.Exception
{
    public class UnhandledEnumVariantExceptionTest
    {
        private enum TestEnum
        {
            One = 0,
        }

        private interface ITestInterface
        {
        }

        [Theory]
        [MemberData(nameof(GetEnumVariantExamples))]
        public void MessageMatches(Type enumType, object instance, string expected)
        {
            var exception = new UnhandledEnumValueException(enumType, instance);
            Assert.Equal(expected, exception.Message);
        }

        public static TheoryData<Type, object, string> GetEnumVariantExamples()
            => new TheoryData<Type, object, string>
            {
                { typeof(TestEnum), TestEnum.One, "Variant 'One' of 'TestEnum' is unhandled." },
                { typeof(ITestInterface), new TestInstance(),  "Variant 'TestInstance' of 'ITestInterface' is unhandled." },
                { typeof(TestInstance), new TestInstance(), "The variant 'TestInstance' is unhandled." },
            };

        [Fact]
        public void GenericClassMatchesNonGeneric()
        {
            var genericException = new UnhandledEnumValueException<ITestInterface>(new TestInstance());
            var exception = new UnhandledEnumValueException(typeof(ITestInterface), new TestInstance());

            Assert.Equal(exception.Message, genericException.Message);
        }

        private class TestInstance : ITestInterface
        {
        }
    }
}
