using System;

namespace XCalculate.Web.App.Models
{
    public class Link
    {
        public string Text
        {
            get;
        }

        public Uri Uri
        {
            get;
        }

        public Link(string text, Uri uri)
        {
            this.Text = text;
            this.Uri = uri;
        }

        public Link(string text, string uri)
            : this(text, new Uri(uri))
        {
        }
    }
}
