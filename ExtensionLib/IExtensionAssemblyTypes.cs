using System;
using System.Collections.Generic;
using System.Reflection;

namespace ExtensionLib
{
    public interface IExtensionAssemblyTypes
    {
        Assembly Assembly
        {
            get;
        }

        Type AssemblyInfo
        {
            get;
        }

        IReadOnlyList<IExtensionAssemblyType> ExportedTypes
        {
            get;
        }
    }
}
