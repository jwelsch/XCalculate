using System;
using System.Collections.Generic;
using XCalculatorLib;

namespace MathCalculators
{
    [Function]
    public class AddFunction : IFunction
    {
        public IFunctionInfo FunctionInfo
        {
            get;
            private set;
        }

        public AddFunction()
        {
            this.FunctionInfo = new DefaultFunctionInfo(new Version("1.0.0"), "Add", "Add numbers together.", "add");
        }

        public IValue Calculate(PhaseHandler phaseHandler)
        {
            if (phaseHandler == null)
            {
                throw new ArgumentNullException(nameof(phaseHandler));
            }

            var values = phaseHandler(new DefaultPhase("Specify Operands", "Specify numbers to add together.", new Int32ArrayValue(null, new Int32ArrayValueInfo("Operands", "Operands to add." ))));

            var sum = 0;

            foreach (var value in values)
            {
                var arrayValue = (Int32ArrayValue)value;

                foreach (var v in arrayValue.Value)
                {
                    sum += v;
                }
            }

            return new Int32Value(sum);
        }
    }
}
