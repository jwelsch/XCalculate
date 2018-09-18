using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ExtensionLib
{
    internal class AssemblyLoader
    {
        public IEnumerable<IExtensionAssemblyTypes> Load(Assembly assembly, IEnumerable<Type> classes, IEnumerable<Type> implementedInterfaces, IEnumerable<Type> classAttributes)
        {
            var extensionAssemblyTypesList = new List<IExtensionAssemblyTypes>();

            var extensionAssemblyTypes = new ExtensionAssemblyTypes()
            {
                Assembly = assembly
            };

            var assemblyExportedTypes = assembly.GetExportedTypes();

            foreach (var assemblyExportedType in assemblyExportedTypes)
            {
                var matchedType = MatchClassType(assemblyExportedType, classes);

                if (matchedType == null)
                {
                    matchedType = MatchImplementedInterfaceType(assemblyExportedType, implementedInterfaces);
                }

                if (matchedType == null)
                {
                    matchedType = MatchClassAttributeType(assemblyExportedType, implementedInterfaces);
                }

                if (matchedType == null)
                {
                    matchedType = MatchClassAttributeType(assemblyExportedType, classAttributes);
                }

                if (matchedType != null)
                {
                    extensionAssemblyTypes.ExportedTypes.Add(matchedType);
                }
            }

            if (extensionAssemblyTypes.ExportedTypes.Count > 0)
            {
                extensionAssemblyTypesList.Add(extensionAssemblyTypes);
            }

            return extensionAssemblyTypesList;
        }

        private ExtensionAssemblyType MatchClassType(Type assemblyExportedType, IEnumerable<Type> classes)
        {
            if (classes != null)
            {
                var foundType = classes.FirstOrDefault(i => i.Equals(assemblyExportedType));

                if (foundType != null)
                {
                    return new ExtensionAssemblyType()
                    {
                        ExportType = foundType,
                        MatchType = foundType
                    };
                }
            }

            return null;
        }

        private ExtensionAssemblyType MatchImplementedInterfaceType(Type assemblyExportedType, IEnumerable<Type> implementedInterfaces)
        {
            if (implementedInterfaces != null)
            {
                foreach (var implementedInterface in implementedInterfaces)
                {
                    var assemblyInterfaces = assemblyExportedType.FindInterfaces((m, o) => m == (Type)o, implementedInterface);

                    if (assemblyInterfaces != null && assemblyInterfaces.Length > 0)
                    {
                        return new ExtensionAssemblyType()
                        {
                            ExportType = assemblyExportedType,
                            MatchType = implementedInterface
                        };
                    }
                }
            }

            return null;
        }

        private ExtensionAssemblyType MatchClassAttributeType(Type assemblyExportedType, IEnumerable<Type> classAttributes)
        {
            if (classAttributes != null)
            {
                foreach (var attribute in assemblyExportedType.CustomAttributes)
                {
                    if (classAttributes.Contains(attribute.AttributeType))
                    {
                        return new ExtensionAssemblyType()
                        {
                            ExportType = assemblyExportedType,
                            MatchType = attribute.AttributeType
                        };
                    }
                }
            }

            return null;
        }
    }
}
