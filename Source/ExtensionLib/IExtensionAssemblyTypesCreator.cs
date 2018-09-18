using System;
using System.Collections.Generic;

namespace ExtensionLib
{
    internal interface IExtensionAssemblyTypesCreator
    {
        IEnumerable<Version> SupportedVersions
        {
            get;
        }

        IExtensionAssemblyObjects Create(IExtensionAssemblyTypes assemblyTypes);
    }
}
