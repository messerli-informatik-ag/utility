using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Utility.Utility.Extension
{
    public static class TypeExtension
    {
        public static bool IsEnumerable(this Type type)
        {
            return type.GetInterface(nameof(IEnumerable)) != null;
        }

        public static bool IsQueryable(this Type type)
        {
            return type.GetInterface(nameof(IQueryable)) != null;
        }

        /// <summary>
        /// Check if a type is a compiler generated anonymous type,
        /// such as 
        /// var anonymousType = new { Name = "Foo", Occupation = "Bar" };
        /// Source: https://www.jefclaes.be/2011/05/checking-for-anonymous-types.html
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
        {
            return type.IsArray
                ? type.GetElementType()
                : type.IsEnumerable()
                    ? type.GetGenericArguments().First()
                    : null;
        }

        public static object GetDefault(this Type type)
        {
            return type.GetTypeInfo().IsValueType
                ? Activator.CreateInstance(type)
                : null;
        }

        public static IEnumerable<object> GetPropertyValues(this Type type, object instance)
        {
            return type.GetProperties().Select(property => property.GetValue(instance));
        }
    }
}