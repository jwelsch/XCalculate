using System;

namespace XCalculateLib
{
    public class AssemblyInfo : IAssemblyInfo
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

        public AssemblyInfo(string name = null, string email = null, Uri site = null)
        {
            this.Name = name;
            this.Email = email;
            this.Site = site;
        }
    }
}
