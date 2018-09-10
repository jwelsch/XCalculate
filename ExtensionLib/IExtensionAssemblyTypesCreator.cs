using System;
using System.Collections.Generic;

namespace ExtensionLib
{
    public interface IExtensionAssemblyTypesCreator
    {
        IEnumerable<Version> SupportedVersions
        {
            get;
        }

        IEnumerable<IExtensionObject> Create(IExtensionAssemblyTypes assemblyTypes);
    }
}
