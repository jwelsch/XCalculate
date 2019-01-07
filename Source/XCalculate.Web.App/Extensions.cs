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
