using System;
using System.Collections.Generic;
using XCalculatorLib;

namespace TestCalculators
{
    public class SubtractCalculatorFunction : ICalculatorFunction
    {
        public ICalculatorFunctionInfo FunctionInfo
        {
            get;
            private set;
        }

        public SubtractCalculatorFunction()
        {
            this.FunctionInfo = new DefaultCalculatorFunctionInfo("Subtraction", "Subtracts two operands.", "subtract");
        }

        public ICalculatorValue Calculate(Func<ICalculatorPhase, IEnumerable<ICalculatorValue>> phaseHandler)
        {
            if (phaseHandler == null)
            {
                throw new ArgumentNullException(nameof(phaseHandler));
            }

            var values = phaseHandler(new DefaultCalculatorPhase("Specify Operands", "Specify two numbers to subtract", new ICalculatorValueInfo[]
                {
                    new Int32CalculatorValueInfo("First", "The first number"),
                    new Int32CalculatorValueInfo("Second", "The second number")
                }));

            var difference = 0;
            var first = true;

            foreach (Int32CalculatorValue value in values)
            {
                if (first)
                {
                    difference = value.Value;
                    first = false;
                    continue;
                }

                difference -= value.Value;
            }

            return new Int32CalculatorValue(difference);
        }
    }
}
