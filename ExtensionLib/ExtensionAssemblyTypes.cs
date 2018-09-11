using System;
using System.Collections.Generic;
using System.Reflection;

namespace ExtensionLib
{
    internal class ExtensionAssemblyTypes : IExtensionAssemblyTypes
    {
        public Assembly Assembly
        {
            get;
            set;
        }

        public Type AssemblyInfo
        {
            get;
            set;
        }

        public List<IExtensionAssemblyType> ExportedTypes
        {
            get;
            set;
        }

        IReadOnlyList<IExtensionAssemblyType> IExtensionAssemblyTypes.ExportedTypes
        {
            get
            {
                return this.ExportedTypes;
            }
        }

        public ExtensionAssemblyTypes()
        {
            this.ExportedTypes = new List<IExtensionAssemblyType>();
        }
    }
}
