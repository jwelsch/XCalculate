using System;

namespace XCalculatorLib
{
    public class DefaultCalculatorAssemblyInfo : ICalculatorAssemblyInfo
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

        public DefaultCalculatorAssemblyInfo(string name = null, string email = null, Uri site = null)
        {
            this.Name = name;
            this.Email = email;
            this.Site = site;
        }
    }
}
