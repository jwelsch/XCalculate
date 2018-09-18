using System.Collections.Generic;
using System.Reflection;

namespace ExtensionLib
{
    public interface IExtensionAssemblyObjects
    {
        Assembly Assembly
        {
            get;
        }

        IEnumerable<IExtensionObject> ExtensionObjects
        {
            get;
        }
    }
}
