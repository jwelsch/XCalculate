using System;
using System.Collections.Generic;
using System.Text;
using XCalculatorLib.Interfaces;

namespace XCalculatorManagerLib.Interfaces
{
    public interface ICalculatorAssembly
    {
        ICalculatorAssemblyInfo AssemblyInfo
        {
            get;
        }

        IReadOnlyList<ICalculatorModule> Modules
        {
            get;
        }
    }
}
