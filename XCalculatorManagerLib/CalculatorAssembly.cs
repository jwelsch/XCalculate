using System.Collections.Generic;
using XCalculatorLib.Interfaces;
using XCalculatorManagerLib.Interfaces;

namespace XCalculatorManagerLib
{
    internal class CalculatorAssembly : ICalculatorAssembly
    {
        public ICalculatorAssemblyInfo AssemblyInfo
        {
            get;
            private set;
        }

        public IReadOnlyList<ICalculatorModule> Modules
        {
            get;
            private set;
        }

        public CalculatorAssembly(ICalculatorAssemblyInfo assemblyInfo, IReadOnlyList<ICalculatorModule> modules)
        {
            this.AssemblyInfo = assemblyInfo;
            this.Modules = modules;
        }
    }
}
