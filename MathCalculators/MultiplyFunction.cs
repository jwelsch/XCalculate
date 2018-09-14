using System;
using System.Collections.Generic;
using XCalculatorLib;

namespace MathCalculators
{
    public class MultiplyFunction : ICalculatorFunction
    {
        public ICalculatorFunctionInfo FunctionInfo
        {
            get;
            private set;
        }

        public MultiplyFunction()
        {
            this.FunctionInfo = new DefaultCalculatorFunctionInfo("Multiply", "Multiply two numbers together.", "multiply");
        }

        public ICalculatorValue Calculate(Func<ICalculatorPhase, IEnumerable<ICalculatorValue>> phaseHandler)
        {
            if (phaseHandler == null)
            {
                throw new ArgumentNullException(nameof(phaseHandler));
            }

            //var values = phaseHandler(new DefaultCalculatorPhase("Specify Operands", "Specify two numbers to multiply together.", new ICalculatorValueInfo[]
            //    {
            //        new Int32CalculatorValueInfo("First", "The first number"),
            //        new Int32CalculatorValueInfo("Second", "The second number")
            //    }));

            var product = 0;

            //foreach (Int32CalculatorValue value in values)
            //{
            //    product *= value.Value;
            //}

            return new Int32CalculatorValue(product);
        }
    }
}
