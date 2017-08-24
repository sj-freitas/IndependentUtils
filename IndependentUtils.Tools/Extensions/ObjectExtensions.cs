using System;
using System.Collections.Generic;
using System.Globalization;

namespace IndependentUtils.Tools.Extensions
{
    public static class ObjectExtensions
    {
        public const string Null = "null";

        public static IEnumerable<T> ToEnumerable<T>(this T value)
        {
            yield return value;
        }

        /// <summary>
        /// Converts any type to a text string. For example, if the value
        /// is a string, the value shown will be within quotation marks,
        /// otherwise the value will be the literal. If the value is a reference
        /// type and it's null, then null is shown.
        /// </summary>
        /// <typeparam name="T">The type to convert.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <returns>A text value string.</returns>
        public static string ToValueString<T>(this T value)
        {
            var tType = typeof(T);
            if (!tType.IsValueType && value == null)
            {
                return Null;
            }

            var boolValue = value as bool?;
            if (boolValue != null)
            {
                return boolValue.Value ? "true" : "false";
            }

            var doubleValue = value as double?;
            if (doubleValue != null)
            {
                return doubleValue.Value.ToString(CultureInfo.InvariantCulture);
            }

            return value.ToString();
        }
    }
}
