using System;

namespace XCalculatorLib
{
    public class DefaultCalculatorAssemblyInfo : ICalculatorAssemblyInfo
    {
        public Version Version
        {
            get;
            private set;
        }

        public IAuthorInfo AuthorInfo
        {
            get;
            private set;
        }

        public DefaultCalculatorAssemblyInfo(Version version, IAuthorInfo authorInfo = null)
        {
            this.Version = version;
            this.AuthorInfo = authorInfo;
        }
    }
}
