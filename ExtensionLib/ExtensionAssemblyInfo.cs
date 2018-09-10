using System;

namespace ExtensionLib
{
    internal class ExtensionAssemblyInfo : IExtensionAssemblyInfo
    {
        public Version Version
        {
            get;
            set;
        }

        public IExtensionAuthorInfo AuthorInfo
        {
            get;
            set;
        }
    }
}
