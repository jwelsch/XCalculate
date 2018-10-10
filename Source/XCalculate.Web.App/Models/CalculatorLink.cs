using System;

namespace XCalculate.Web.App.Models
{
    public class CalculatorLink
    {
        public string Title
        {
            get;
        }

        public string Description
        {
            get;
        }

        public string[] Tags
        {
            get;
        }

        public Uri Uri
        {
            get;
        }

        public CalculatorLink(string title, string description, string[] tags, Uri uri)
        {
            this.Title = title;
            this.Description = description;
            this.Tags = tags;
            this.Uri = uri;
        }
    }
}
