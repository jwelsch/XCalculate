
using System;

namespace ExtensionLib
{
    public interface IExtensionObject
    {
        IExtensionAssembly ExtensionAssembly
        {
            get;
        }

        object Instance
        {
            get;
        }

        IExtensionAssemblyType ExtensionAssemblyType
        {
            get;
        }

        T GetInstanceAs<T>();
    }
}
