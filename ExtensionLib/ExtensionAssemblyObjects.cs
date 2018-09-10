using System.Collections.Generic;
using System.Reflection;

namespace ExtensionLib
{
    internal class ExtensionAssemblyObjects : IExtensionAssemblyObjects
    {
        public Assembly Assembly
        {
            get;
            set;
        }

        public List<IExtensionObject> ExtensionObjects
        {
            get;
            set;
        }

        IEnumerable<IExtensionObject> IExtensionAssemblyObjects.ExtensionObjects
        {
            get
            {
                return this.ExtensionObjects;
            }
        }

        public ExtensionAssemblyObjects()
        {
            this.ExtensionObjects = new List<IExtensionObject>();
        }
    }
}
