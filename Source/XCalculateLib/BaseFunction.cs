using System;
using System.Linq;

namespace XCalculateLib
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

        protected static IValue[] DoPhase(PhaseHandler phaseHandler, IPhase phase)
        {
            if (phaseHandler == null)
            {
                throw new ArgumentNullException(nameof(phaseHandler));
            }

            var phaseValues = phaseHandler(phase);

            return phaseValues.ToArray();
        }
    }
}
