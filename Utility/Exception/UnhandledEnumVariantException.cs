using System;

namespace Messerli.Utility.Exception
{
    public class UnhandledEnumVariantException : System.Exception
    {
        public UnhandledEnumVariantException(Type enumType, object instance)
        {
            EnumType = enumType;
            Instance = instance;
        }

        public Type EnumType { get; }

        public object Instance { get; }

        public override string Message => EnumType switch
        {
            _ when EnumType.IsEnum => $"Variant '{Instance.ToString()}' of '{EnumType.Name}' is unhandled.",
            _ when EnumType.IsAbstract || EnumType.IsInterface => $"Variant '{Instance.GetType().Name}' of '{EnumType.Name}' is unhandled.",
            _ => $"The variant '{EnumType.Name}' is unhandled.",
        };
    }

    public class UnhandledEnumVariantException<T> : UnhandledEnumVariantException
        where T : notnull
    {
        public UnhandledEnumVariantException(T value)
            : base(typeof(T), value)
        {
        }
    }
}
