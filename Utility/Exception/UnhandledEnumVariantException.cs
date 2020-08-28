using System;

namespace Messerli.Utility.Exception
{
    public class UnhandledEnumVariantException : System.Exception
    {
        public UnhandledEnumVariantException(Type type, string value)
        {
            Type = type;
            Value = value;
        }

        public Type Type { get; }

        public string Value { get; }

        public override string Message => $"Variant {Value} of {Type.Name} is unhandled.";
    }

    public class UnhandledEnumVariantException<T> : UnhandledEnumVariantException
    {
        public UnhandledEnumVariantException(string value)
            : base(typeof(T), value)
        {
        }
    }
}
