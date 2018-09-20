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

        IEnumerable<IExtensionAssemblyType> ExportedTypes
        {
            get;
        }
    }
}
