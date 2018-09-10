using System;
using System.Collections.Generic;

namespace XCalculatorLib
{
    public interface ICalculatorModule
    {
        ICalculatorAssemblyInfo AssemblyInfo
        {
            get;
        }

        ICalculatorFunction Function
        {
            get;
        }
    }
}
