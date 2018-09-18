using ExtensionLib;
using System;
using System.Collections.Generic;
using XCalculateLib;

namespace XCalculateManagerLib
{
    public class CalculatorModuleFactory : ICalculatorModuleFactory
    {
        public IEnumerable<IModule> CreateFromDirectories(params string[] directoryPaths)
        {
            if (directoryPaths == null)
            {
                throw new ArgumentNullException(nameof(directoryPaths));
            }

            if (directoryPaths.Length == 0)
            {
                throw new ArgumentException(nameof(directoryPaths));
            }

            var assemblyEnumerator = new DirectoryAssemblyEnumerator(directoryPaths);

            return this.CreateFromAssemblies(assemblyEnumerator);
        }

        public IEnumerable<IModule> CreateFromFiles(params string[] filePaths)
        {
            if (filePaths == null)
            {
                throw new ArgumentNullException(nameof(filePaths));
            }

            if (filePaths.Length == 0)
            {
                throw new ArgumentException(nameof(filePaths));
            }

            var assemblyEnumerator = new FileAssemblyEnumerator(filePaths);

            return this.CreateFromAssemblies(assemblyEnumerator);
        }

        private IEnumerable<IModule> CreateFromAssemblies(IAssemblyEnumerator assemblyEnumerator)
        {
            //var implementedInterfaces = new Type[] { typeof(ICalculatorFunction), typeof(ICalculatorAssemblyInfo) };
            var classAttributes = new Type[] { typeof(FunctionAttribute), typeof(AssemblyInfoAttribute) };

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
                if (extensionObject.ExtensionAssemblyType.MatchType == typeof(AssemblyInfoAttribute))
                {
                    if (result.AssemblyInfo != null)
                    {
                        throw new InvalidOperationException($"More than one {typeof(AssemblyInfoAttribute)} found in assembly {assemblyObjects.Assembly.FullName}.");
                    }

                    try
                    {
                        result.AssemblyInfo = extensionObject.GetInstanceAs<IAssemblyInfo>();
                    }
                    catch (Exception ex)
                    {
                        throw new InvalidOperationException($"{extensionObject.ExtensionAssemblyType.ExportType} is decorated with {typeof(AssemblyInfoAttribute)}, but does not implement interface {typeof(IAssemblyInfo)}.", ex);
                    }

                    continue;
                }

                try
                {
                    result.CalculatorFunctions.Add(extensionObject.GetInstanceAs<IFunction>());
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"{extensionObject.ExtensionAssemblyType.ExportType} is decorated with {typeof(FunctionAttribute)}, but does not implement interface {typeof(IFunction)}.", ex);
                }
            }

            if (result.AssemblyInfo == null)
            {
                throw new InvalidOperationException($"No {typeof(AssemblyInfoAttribute)} type found in assembly {assemblyObjects.Assembly.FullName}.");
            }

            return result;
        }
    }
}
