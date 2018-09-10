using System;
using System.Collections.Generic;

namespace ExtensionLib
{
    public class ExtensionObjectFactory
    {
        public IEnumerable<IExtensionObject> Create(IAssemblyEnumerator assemblyEnumerator, IEnumerable<Type> classes, IEnumerable<Type> implementedInterfaces)
        {
            var extensionObjectList = new List<IExtensionObject>();
            var loader = new AssemblyLoader();
            var instantiator = new ActivatorTypeInstantiator();
            var creator = new ExtensionAssemblyTypesCreatorV1(instantiator);

            foreach (var assembly in assemblyEnumerator)
            {
                var assemblyTypesEnumeration = loader.Load(assembly, classes, implementedInterfaces);

                foreach (var assemblyTypes in assemblyTypesEnumeration)
                {
                    var extensionObjects = creator.Create(assemblyTypes);

                    extensionObjectList.AddRange(extensionObjects);
                }
            }

            return extensionObjectList;
        }
    }
}
