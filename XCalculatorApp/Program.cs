using System;
using XCalculatorManagerLib;

namespace XCalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var moduleLoader = new CalculatorModuleLoader();
            var assemblyProvider = new DirectoryCalculatorAssemblyProvider(Environment.CurrentDirectory);

            var modules = moduleLoader.Load(assemblyProvider);
        }
    }
}
