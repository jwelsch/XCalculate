using System;
using System.Collections.Generic;
using System.Reflection;
using XCalculatorLib.Interfaces;
using XCalculatorManagerLib.Interfaces;

namespace XCalculatorManagerLib
{
    public class CalculatorModuleLoader : ICalculatorModuleLoader
    {
        public ICalculatorModule[] Load(ICalculatorAssemblyProvider assemblyProvider)
        {
            var modules = new List<ICalculatorModule>();

            foreach (var assembly in assemblyProvider)
            {
                var assemblyModules = this.LoadModules(assembly);

                modules.AddRange(assemblyModules);
            }

            return modules.ToArray();
        }

        private ICalculatorAssembly LoadModules(Assembly assembly)
        {
            var exportedTypes = assembly.GetExportedTypes();

            ICalculatorAssemblyInfo assemblyInfo = null;
            var modules = new List<ICalculatorModule>();

            foreach (var type in exportedTypes)
            {
                var assemblyInterfaces = type.FindInterfaces((m, o) => m == (Type)o, typeof(ICalculatorAssemblyInfo));

                if (assemblyInterfaces != null && assemblyInterfaces.Length > 0)
                {
                    assemblyInfo = (ICalculatorAssemblyInfo)Activator.CreateInstance(type);

                    continue;
                }

                var moduleInterfaces = type.FindInterfaces((m, o) => m == (Type) o, typeof(ICalculatorModule));

                if (moduleInterfaces != null && moduleInterfaces.Length > 0)
                {
                    var module = (ICalculatorModule)Activator.CreateInstance(type);

                    modules.Add(module);
                }
            }

            return new CalculatorAssembly(assemblyInfo, modules);
        }
    }
}
