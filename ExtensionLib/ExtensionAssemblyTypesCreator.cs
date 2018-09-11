using System;
using System.Collections.Generic;
using System.Linq;

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

            //if (extensionAssembly.AssemblyInfo == null)
            //{
            //    throw new InvalidOperationException($"Extension version not found.{Environment.NewLine}  Assembly: {extensionAssembly.Assembly.FullName}");
            //}

            //var assemblyInfo = (IExtensionAssemblyInfo)this.instantiator.Create(extensionAssembly.AssemblyInfo);

            //var version = this.SupportedVersions.FirstOrDefault(i => i.Major == assemblyInfo.Version.Major);

            //if (version == null)
            //{
            //    throw new InvalidOperationException($"Unsupported extension version.{Environment.NewLine}  Assembly: {extensionAssembly.Assembly.FullName}{Environment.NewLine}  Assembly Extension Version: {assemblyInfo.Version}{Environment.NewLine}  Supported Extension Versions: {this.SupportedVersions.ToDelimitedString(", ")}");
            //}

            foreach (var exportedType in extensionAssembly.ExportedTypes)
            {
                var extensionObject = new ExtensionObject()
                {
                    ExtensionAssemblyType = exportedType
                };

                extensionObject.ExtensionAssembly = new ExtensionAssembly()
                {
                    //AssemblyInfo = assemblyInfo,
                    Assembly = extensionAssembly.Assembly,
                };

                extensionObject.Instance = this.instantiator.Create(exportedType.ExportType);

                extensionAssemblyObjects.ExtensionObjects.Add(extensionObject);
            }

            return extensionAssemblyObjects;
        }
    }
}
