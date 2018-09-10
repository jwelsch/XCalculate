using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionLib
{
    internal static class ClassExtensions
    {
        public static string ToDelimitedString<T>(this IEnumerable<T> enumerable, string delimiter)
        {
            if (delimiter == null)
            {
                throw new ArgumentNullException(nameof(delimiter));
            }

            if (delimiter.Length == 0)
            {
                throw new ArgumentException(nameof(delimiter));
            }

            var builder = new StringBuilder();
            var first = true;

            foreach (var item in enumerable)
            {
                if (first)
                {
                    builder.Append($"{item}");
                    first = false;

                    continue;
                }

                builder.Append($"{delimiter}{item}");
            }

            return builder.ToString();
        }
    }
}
