using System;

namespace XCalculate.Web.App.Models
{
    public class CalculatorLink
    {
        public string Text
        {
            get;
        }

        public Uri Uri
        {
            get;
        }

        public CalculatorLink(string text, Uri uri)
        {
            this.Text = text;
            this.Uri = uri;
        }
    }
}
