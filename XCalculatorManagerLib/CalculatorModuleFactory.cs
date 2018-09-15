using ExtensionLib;
using System;
using System.Collections.Generic;
using XCalculatorLib;

namespace XCalculatorManagerLib
{
    public class CalculatorModuleFactory : ICalculatorModuleFactory
    {
        public IEnumerable<ICalculatorModule> CreateFromDirectories(params string[] directoryPaths)
        {
            var assemblyEnumerator = new DirectoryAssemblyEnumerator(directoryPaths);

            return this.CreateFromAssemblies(assemblyEnumerator);
        }

        public IEnumerable<ICalculatorModule> CreateFromFiles(params string[] filePaths)
        {
            var assemblyEnumerator = new FileAssemblyEnumerator(filePaths);

            return this.CreateFromAssemblies(assemblyEnumerator);
        }

        private IEnumerable<ICalculatorModule> CreateFromAssemblies(IAssemblyEnumerator assemblyEnumerator)
        {
            //var implementedInterfaces = new Type[] { typeof(ICalculatorFunction), typeof(ICalculatorAssemblyInfo) };
            var classAttributes = new Type[] { typeof(CalculatorFunctionAttribute) };

            var extensionObjectFactory = new ExtensionObjectFactory();

            var assemblyExtensionObjectsEnumeration = extensionObjectFactory.Create(assemblyEnumerator, null, null, classAttributes);

            var moduleList = new List<ICalculatorModule>();

            foreach (var assemblyExtensionObjects in assemblyExtensionObjectsEnumeration)
            {
                var (assemblyInfo, calculatorFunctions) = this.SeparateObjects(assemblyExtensionObjects);

                foreach (var functionObject in calculatorFunctions)
                {
                    var module = new DefaultCalculatorModule()
                    {
                        Function = functionObject,
                        AssemblyInfo = assemblyInfo,
                        Assembly = assemblyExtensionObjects.Assembly
                    };

                    moduleList.Add(module);
                }
            }

            return moduleList;
        }

        private (ICalculatorAssemblyInfo AssemblyInfo, IEnumerable<ICalculatorFunction> CalculatorFunctions) SeparateObjects(IExtensionAssemblyObjects assemblyObjects)
        {
            var result = (AssemblyInfo: (ICalculatorAssemblyInfo)null, CalculatorFunctions: new List<ICalculatorFunction>());

            foreach (var extensionObject in assemblyObjects.ExtensionObjects)
            {
                if (extensionObject.ExtensionAssemblyType.MatchType == typeof(ICalculatorAssemblyInfo))
                {
                    if (result.AssemblyInfo != null)
                    {
                        throw new InvalidOperationException($"More than one {typeof(ICalculatorAssemblyInfo)} found in assembly {assemblyObjects.Assembly.FullName}.");
                    }

                    result.AssemblyInfo = extensionObject.GetInstanceAs<ICalculatorAssemblyInfo>();
                    continue;
                }

                result.CalculatorFunctions.Add(extensionObject.GetInstanceAs<ICalculatorFunction>());
            }

            if (result.AssemblyInfo == null)
            {
                throw new InvalidOperationException($"No {typeof(ICalculatorAssemblyInfo)} type found in assembly {assemblyObjects.Assembly.FullName}.");
            }

            return result;
        }
    }
}
