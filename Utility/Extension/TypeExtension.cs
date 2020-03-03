using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Messerli.Utility.Extension
{
    public static class TypeExtension
    {
        public static bool IsEnumerable(this Type type)
            => type == typeof(IEnumerable) || type.GetInterface(nameof(IEnumerable)) != null;

        public static bool IsQueryable(this Type type)
            => type == typeof(IQueryable) || type.GetInterface(nameof(IQueryable)) != null;

        /// <summary>
        /// Check if a type is a compiler generated anonymous type,
        /// such as:
        /// <code>
        /// var anonymousType = new { Name = "Foo", Occupation = "Bar" };
        /// </code>
        /// <see href="https://www.jefclaes.be/2011/05/checking-for-anonymous-types.html">Source</see>.
        /// </summary>
        public static bool IsAnonymous(this Type type)
        {
            Debug.Assert(type != null, "Type should not be null");

            // HACK: The only way to detect anonymous types right now.
            return Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), false)
                   && type.IsGenericType && type.Name.Contains("AnonymousType")
                   && (type.Name.StartsWith("<>", StringComparison.OrdinalIgnoreCase) ||
                       type.Name.StartsWith("VB$", StringComparison.OrdinalIgnoreCase))
                   && (type.Attributes & TypeAttributes.NotPublic) == TypeAttributes.NotPublic;
        }

        public static Type GetInnerType(this Type type)
            => type.IsArray
                ? type.GetElementType()
                : type.IsEnumerable()
                    ? type.GetGenericArguments().First()
                    : null;

        public static object GetDefault(this Type type)
            => type.GetTypeInfo().IsValueType
                ? Activator.CreateInstance(type)
                : null;

        public static IEnumerable<object> GetPropertyValues(this Type type, object instance)
            => type.GetProperties().Select(property => property.GetValue(instance));
    }
}
