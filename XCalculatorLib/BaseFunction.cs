using System;
using System.Collections.Generic;

namespace XCalculatorLib
{
    public abstract class BaseFunction : IFunction
    {
        public IFunctionInfo FunctionInfo
        {
            get;
            private set;
        }

        public BaseFunction(IFunctionInfo functionInfo)
        {
            this.FunctionInfo = functionInfo;
        }

        public abstract IValue Calculate(PhaseHandler phaseHandler);
    }
}
