using System;

namespace ExtensionLib
{
    internal class ExtensionAssemblyTypesCreatorV1 : ExtensionAssemblyTypesCreator
    {
        public ExtensionAssemblyTypesCreatorV1(ITypeInstantiator instantiator)
            : base(instantiator, new Version[] { new Version("1.0.0") })
        {
        }
    }
}
