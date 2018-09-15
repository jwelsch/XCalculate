using System;
using System.Collections.Generic;
using XCalculatorLib;

namespace MathCalculators
{
    [CalculatorFunction]
    public class AddFunction : ICalculatorFunction
    {
        public ICalculatorFunctionInfo FunctionInfo
        {
            get;
            private set;
        }

        public AddFunction()
        {
            this.FunctionInfo = new DefaultCalculatorFunctionInfo(new Version("1.0.0"), "Add", "Add numbers together.", "add");
        }

        public ICalculatorValue Calculate(PhaseHandler phaseHandler)
        {
            if (phaseHandler == null)
            {
                throw new ArgumentNullException(nameof(phaseHandler));
            }

            var values = phaseHandler(new DefaultCalculatorPhase("Specify Operands", "Specify numbers to add together.", new Int32ArrayCalculatorValue(null, new Int32ArrayCalculatorValueInfo("Operands", "Operands to add." ))));

            var sum = 0;

            foreach (var value in values)
            {
                var arrayValue = (Int32ArrayCalculatorValue)value;

                foreach (var v in arrayValue.Value)
                {
                    sum += v;
                }
            }

            return new Int32CalculatorValue(sum);
        }
    }
}
