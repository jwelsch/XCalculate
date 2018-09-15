using System;
using System.Collections.Generic;

namespace ExtensionLib
{
    public class ExtensionObjectFactory
    {
        public IEnumerable<IExtensionAssemblyObjects> Create(IAssemblyEnumerator assemblyEnumerator, IEnumerable<Type> classes, IEnumerable<Type> implementedInterfaces, IEnumerable<Type> classAttributes)
        {
            var extensionAssemblyObjectsList = new List<IExtensionAssemblyObjects>();
            var loader = new AssemblyLoader();
            var instantiator = new ActivatorTypeInstantiator();
            var creator = new ExtensionAssemblyTypesCreatorV1(instantiator);

            foreach (var assembly in assemblyEnumerator)
            {
                var assemblyTypesEnumeration = loader.Load(assembly, classes, implementedInterfaces, classAttributes);

                foreach (var assemblyTypes in assemblyTypesEnumeration)
                {
                    var extensionObjects = creator.Create(assemblyTypes);

                    extensionAssemblyObjectsList.Add(extensionObjects);
                }
            }

            return extensionAssemblyObjectsList;
        }
    }
}
