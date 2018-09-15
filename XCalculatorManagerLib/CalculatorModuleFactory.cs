using ExtensionLib;
using System;
using System.Collections.Generic;
using XCalculatorLib;

namespace XCalculatorManagerLib
{
    public class CalculatorModuleFactory : ICalculatorModuleFactory
    {
        public IEnumerable<IModule> CreateFromDirectories(params string[] directoryPaths)
        {
            var assemblyEnumerator = new DirectoryAssemblyEnumerator(directoryPaths);

            return this.CreateFromAssemblies(assemblyEnumerator);
        }

        public IEnumerable<IModule> CreateFromFiles(params string[] filePaths)
        {
            var assemblyEnumerator = new FileAssemblyEnumerator(filePaths);

            return this.CreateFromAssemblies(assemblyEnumerator);
        }

        private IEnumerable<IModule> CreateFromAssemblies(IAssemblyEnumerator assemblyEnumerator)
        {
            //var implementedInterfaces = new Type[] { typeof(ICalculatorFunction), typeof(ICalculatorAssemblyInfo) };
            var classAttributes = new Type[] { typeof(FunctionAttribute) };

            var extensionObjectFactory = new ExtensionObjectFactory();

            var assemblyExtensionObjectsEnumeration = extensionObjectFactory.Create(assemblyEnumerator, null, null, classAttributes);

            var moduleList = new List<IModule>();

            foreach (var assemblyExtensionObjects in assemblyExtensionObjectsEnumeration)
            {
                var (assemblyInfo, calculatorFunctions) = this.SeparateObjects(assemblyExtensionObjects);

                foreach (var functionObject in calculatorFunctions)
                {
                    var module = new DefaultModule()
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

        private (IAssemblyInfo AssemblyInfo, IEnumerable<IFunction> CalculatorFunctions) SeparateObjects(IExtensionAssemblyObjects assemblyObjects)
        {
            var result = (AssemblyInfo: (IAssemblyInfo)null, CalculatorFunctions: new List<IFunction>());

            foreach (var extensionObject in assemblyObjects.ExtensionObjects)
            {
                if (extensionObject.ExtensionAssemblyType.MatchType == typeof(IAssemblyInfo))
                {
                    if (result.AssemblyInfo != null)
                    {
                        throw new InvalidOperationException($"More than one {typeof(IAssemblyInfo)} found in assembly {assemblyObjects.Assembly.FullName}.");
                    }

                    result.AssemblyInfo = extensionObject.GetInstanceAs<IAssemblyInfo>();
                    continue;
                }

                result.CalculatorFunctions.Add(extensionObject.GetInstanceAs<IFunction>());
            }

            if (result.AssemblyInfo == null)
            {
                throw new InvalidOperationException($"No {typeof(IAssemblyInfo)} type found in assembly {assemblyObjects.Assembly.FullName}.");
            }

            return result;
        }
    }
}
