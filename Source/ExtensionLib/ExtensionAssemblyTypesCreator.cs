using System;
using System.Collections.Generic;

namespace ExtensionLib
{
    internal abstract class ExtensionAssemblyTypesCreator : IExtensionAssemblyTypesCreator
    {
        private readonly ITypeInstantiator instantiator;

        public IEnumerable<Version> SupportedVersions
        {
            get;
            set;
        }

        protected ExtensionAssemblyTypesCreator(ITypeInstantiator instantiator, IEnumerable<Version> supportedVersions)
        {
            this.instantiator = instantiator;
            this.SupportedVersions = new List<Version>(supportedVersions);
        }

        public IExtensionAssemblyObjects Create(IExtensionAssemblyTypes extensionAssembly)
        {
            var extensionAssemblyObjects = new ExtensionAssemblyObjects()
            {
                Assembly = extensionAssembly.Assembly
            };

            foreach (var exportedType in extensionAssembly.ExportedTypes)
            {
                var extensionObject = new ExtensionObject()
                {
                    ExtensionAssemblyType = exportedType
                };

                extensionObject.ExtensionAssembly = new ExtensionAssembly()
                {
                    Assembly = extensionAssembly.Assembly,
                };

                extensionObject.Instance = this.instantiator.Create(exportedType.ExportType);

                extensionAssemblyObjects.ExtensionObjects.Add(extensionObject);
            }

            return extensionAssemblyObjects;
        }
    }
}
