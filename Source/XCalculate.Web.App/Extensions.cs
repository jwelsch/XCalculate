using System;
using System.Collections.Generic;
using System.Text;

namespace XCalculate.Web.App
{
    /// <summary>
    /// Extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Converts an IEnumerable into a delimited string.
        /// </summary>
        /// <typeparam name="T">Type of items in the IEnumerable.</typeparam>
        /// <param name="me">Object to which the extension is applied.</param>
        /// <param name="delimiter">Delimiter to place in between items in the returned string.</param>
        /// <param name="itemToString">Optional argument that is called to convert an item to a string.</param>
        /// <returns>String containing the delimited items.</returns>
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

        /// <summary>
        /// Finds the index of a string inside a StringBuilder.
        /// </summary>
        /// <param name="me">Object to which the extension is applied.</param>
        /// <param name="value">String to find.</param>
        /// <param name="start">Index to start searching in the StringBuilder.</param>
        /// <param name="count">Number of places from start to search.  Pass -1 to search all places.</param>
        /// <param name="ignoreCase">True to ignore case when searching, false otherwise.</param>
        /// <returns>Zero-based index where the match starts.</returns>
        public static int IndexOf(this StringBuilder me, string value, int start = 0, int count = -1, bool ignoreCase = false)
        {
            const int none = -1;

            var end = count <= none ? me.Length : start + count;

            if (end > me.Length)
            {
                end = me.Length;
            }

            var matchIndex = 0;
            var matchStart = none;
            var matchEnd = none;

            for (var i = start; i < me.Length && i < end; i++)
            {
                if ((!ignoreCase && me[i] == value[matchIndex]) || (ignoreCase && char.ToUpper(me[i]) == char.ToUpper(value[matchIndex])))
                {
                    matchIndex++;

                    if (matchStart <= none)
                    {
                        matchStart = i;
                    }

                    if (matchIndex > value.Length)
                    {
                        matchEnd = i;
                        break;
                    }
                }
                else if (matchStart > none)
                {
                    matchIndex = 0;
                    matchStart = none;
                }
            }

            return matchEnd > none ? matchStart : none;
        }

        /// <summary>
        /// Finds the closing bracket in a string, given the index of the opening bracket.
        /// </summary>
        /// <param name="me">Object to which the extension is applied.</param>
        /// <param name="start">Index of the opening bracket.</param>
        /// <param name="count">Number of places from start to search.</param>
        /// <returns>Zero-based index of the closing bracket or -1 if no matching closing bracket could be found.</returns>
        public static int IndexOfMatchingBracket(this string me, int start = 0, int count = -1)
        {
            const int none = -1;

            if (count == none)
            {
                count = me.Length - start;
            }

            if (me.Length == 0)
            {
                return none;
            }

            var startBracket = me[start];
            var endBracket = default(char);

            if (startBracket == '(')
            {
                endBracket = ')';
            }
            else if (startBracket == '[')
            {
                endBracket = ']';
            }
            else if (startBracket == '{')
            {
                endBracket = '}';
            }
            else if (startBracket == '<')
            {
                endBracket = '>';
            }
            else
            {
                throw new ArgumentException("Start index must resolve to an opening bracket: '(', '[', '{', or '<'.", nameof(start));
            }

            var brackets = 0;
            var startIndex = none;
            var endIndex = none;

            for (var i = start; i < me.Length && i - start < count; i++)
            {
                if (me[i] == startBracket)
                {
                    if (startIndex == none)
                    {
                        startIndex = i;
                    }

                    brackets++;
                }
                else if (me[i] == endBracket)
                {
                    brackets--;
                }

                if (brackets == 0)
                {
                    endIndex = i;
                    break;
                }
            }

            return endIndex;
        }
    }
}
