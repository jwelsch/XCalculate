using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCalculate.Web.Core.Entities
{
    public class Tag
    {
        public string Text
        {
            get;
        }

        public string DisplayText
        {
            get;
        }

        public int Count
        {
            get;
            private set;
        }

        public Tag(string text, string displayText)
        {
            this.Text = text;
            this.DisplayText = displayText;
        }

        public Tag(string text)
            : this(text, GetDefaultDisplayText(text))
        {
        }

        public void IncrementCount(int amount = 1)
        {
            this.Count += amount;
        }

        private static string GetDefaultDisplayText(string text)
        {
            var capitalize = true;
            var builder = new StringBuilder();

            for (var i = 0; i < text.Length; i++)
            {
                var c = text[i];

                if (c == ' ')
                {
                    capitalize = true;
                    continue;
                }

                if (capitalize)
                {
                    builder.Append(char.ToUpper(c));
                    capitalize = false;
                }
                else
                {
                    builder.Append(c);
                }
            }

            return builder.ToString();
        }
    }
}
