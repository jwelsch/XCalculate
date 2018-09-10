using System;

namespace ExtensionLib
{
    public interface IExtensionAssemblyInfo
    {
        Version Version
        {
            get;
        }

        IExtensionAuthorInfo AuthorInfo
        {
            get;
        }
    }
}
