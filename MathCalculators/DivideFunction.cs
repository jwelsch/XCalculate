using System;
using System.Collections.Generic;
using XCalculatorLib;

namespace MathCalculators
{
    public class DivideFunction : ICalculatorFunction
    {
        public ICalculatorFunctionInfo FunctionInfo
        {
            get;
            private set;
        }

        public DivideFunction()
        {
            this.FunctionInfo = new DefaultCalculatorFunctionInfo("Divide", "Divide one number into another.", "divide");
        }

        public ICalculatorValue Calculate(Func<ICalculatorPhase, IEnumerable<ICalculatorValue>> phaseHandler)
        {
            if (phaseHandler == null)
            {
                throw new ArgumentNullException(nameof(phaseHandler));
            }

            //var values = phaseHandler(new DefaultCalculatorPhase("Specify Operands", "Specify the numbers in the division equation.", new ICalculatorValueInfo[]
            //    {
            //        new Int32CalculatorValueInfo("First", "The first number"),
            //        new Int32CalculatorValueInfo("Second", "The second number")
            //    }));

            var quotient = 0.0;
            var first = true;

            //foreach (Int32CalculatorValue value in values)
            //{
            //    if (first)
            //    {
            //        quotient = value.Value;
            //        first = false;
            //        continue;
            //    }

            //    quotient /= value.Value;
            //}

            return new DoubleCalculatorValue(quotient);
        }
    }
}
