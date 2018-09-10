using ExtensionLib;
using System;
using System.Collections.Generic;
using System.Linq;
using XCalculatorLib;

namespace XCalculatorManagerLib
{
    public class CalculatorModuleFactory : ICalculatorModuleFactory
    {
        public IEnumerable<ICalculatorModule> Create(params string[] directoryPaths)
        {
            var extensionObjectFactory = new ExtensionObjectFactory();

            var assemblyEnumerator = new DirectoryAssemblyEnumerator(directoryPaths);
            var implementedInterfaces = new Type[] { typeof(ICalculatorFunction), typeof(ICalculatorAssemblyInfo) };

            var calculatorExtensionObjects = extensionObjectFactory.Create(assemblyEnumerator, null, implementedInterfaces);

            ICalculatorAssemblyInfo assemblyInfo = null;
            var moduleList = new List<ICalculatorModule>();

            foreach (var extensionObject in calculatorExtensionObjects)
            {
                if (extensionObject.Instance.GetType() == typeof(ICalculatorAssemblyInfo))
                {
                    assemblyInfo = (ICalculatorAssemblyInfo) extensionObject.Instance;
                }
            }

            var calculatorModules = calculatorExtensionObjects.Select(i => (ICalculatorModule)i);

            return calculatorModules;
        }
    }
}
