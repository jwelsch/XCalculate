using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ExtensionLib
{
    internal class AssemblyLoader
    {
        private readonly static Type ExtensionAssemblyInfoInterface = typeof(IExtensionAssemblyInfo);

        public IEnumerable<IExtensionAssemblyTypes> Load(Assembly assembly, IEnumerable<Type> classes, IEnumerable<Type> implementedInterfaces)
        {
            var extensionAssemblyTypesList = new List<IExtensionAssemblyTypes>();

            var extensionAssemblyTypes = new ExtensionAssemblyTypes()
            {
                Assembly = assembly
            };

            var assemblyExportedTypes = assembly.GetExportedTypes();

            var foundAssemblyInfo = false;

            foreach (var assemblyExportedType in assemblyExportedTypes)
            {
                if (classes != null)
                {
                    var foundType = classes.FirstOrDefault(i => i.Equals(assemblyExportedType));

                    if (foundType != null)
                    {
                        extensionAssemblyTypes.ExportedTypes.Add(foundType);
                        continue;
                    }
                }

                if (implementedInterfaces != null)
                {
                    foreach (var implementedInterface in implementedInterfaces)
                    {
                        var assemblyInterfaces = assemblyExportedType.FindInterfaces((m, o) => m == (Type)o, implementedInterface);

                        if (assemblyInterfaces != null && assemblyInterfaces.Length > 0)
                        {
                            extensionAssemblyTypes.ExportedTypes.Add(assemblyExportedType);
                            continue;
                        }
                    }
                }

                if (!foundAssemblyInfo && ExtensionAssemblyInfoInterface.Equals(assemblyExportedType))
                {
                    extensionAssemblyTypes.AssemblyInfo = assemblyExportedType;
                    foundAssemblyInfo = true;
                }
            }

            if (extensionAssemblyTypes.ExportedTypes.Count > 0 || extensionAssemblyTypes.AssemblyInfo != null)
            {
                extensionAssemblyTypesList.Add(extensionAssemblyTypes);
            }

            return extensionAssemblyTypesList;
        }
    }
}
