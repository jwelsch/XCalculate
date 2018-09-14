using System;
using System.Collections.Generic;

namespace XCalculatorLib
{
    public abstract class BaseCalculatorFunction : ICalculatorFunction
    {
        public ICalculatorFunctionInfo FunctionInfo
        {
            get;
            private set;
        }

        public BaseCalculatorFunction(ICalculatorFunctionInfo functionInfo)
        {
            this.FunctionInfo = functionInfo;
        }

        public abstract ICalculatorValue Calculate(Func<ICalculatorPhase, IEnumerable<ICalculatorValue>> phaseHandler);
    }
}
