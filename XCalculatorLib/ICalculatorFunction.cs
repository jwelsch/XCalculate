using System;
using System.Collections.Generic;

namespace XCalculatorLib
{
    public interface ICalculatorFunction
    {
        ICalculatorFunctionInfo FunctionInfo
        {
            get;
        }

        ICalculatorValue Calculate(PhaseHandler phaseHandler);
    }
}
