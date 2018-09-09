using System;
using XCalculatorLib.Interfaces;

namespace XCalculatorLib
{
    public class DefaultAuthorInfo : IAuthorInfo
    {
        public string Name
        {
            get;
            private set;
        }

        public string Email
        {
            get;
            private set;
        }

        public Uri Site
        {
            get;
            private set;
        }

        public DefaultAuthorInfo(string name = null, string email = null, Uri site = null)
        {
            this.Name = name;
            this.Email = email;
            this.Site = site;
        }
    }
}
