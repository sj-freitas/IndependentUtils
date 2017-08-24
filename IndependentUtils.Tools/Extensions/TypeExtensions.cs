using System;
using System.Linq;

namespace IndependentUtils.Tools.Extensions
{
    public static class TypeExtensions
    {
        public static string GetFullName(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (type.IsInterface && type.IsGenericType)
            {
                var baseFullName = type.FullName
                    .Remove(type.FullName.IndexOf('`'));
                var genericTypesWithComma = string.Join(",", type
                    .GetGenericArguments()
                    .Select(t => t.GetFullName()));

                return $"{baseFullName}<{genericTypesWithComma}>";
            }
            return type.FullName;
        }

        public static string MakeGenericFullName(this Type type,
            params string[] typeFullName)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (!type.IsGenericType)
            {
                throw new InvalidOperationException($"Type {type.Name} is not generic type");
            }

            var baseFullName = type.FullName.Remove(type.FullName.IndexOf('`'));
            return $"{baseFullName}<{string.Join(", ", typeFullName)}>";
        }
    }
}
