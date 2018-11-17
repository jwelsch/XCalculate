using System;
using System.Collections.Generic;
using System.Text;

namespace XCalculate.Web.App
{
    public static class Extensions
    {
        public static string ToDelimitedString<T>(this IEnumerable<T> me, string delimiter, Func<T, string> itemToString = null)
        {
            var builder = new StringBuilder();

            var first = true;

            foreach (var item in me)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    builder.Append(delimiter);
                }

                builder.Append(itemToString == null ? item.ToString() : itemToString(item));
            }

            return builder.ToString();
        }
    }
}
