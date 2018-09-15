using System;
using XCalculatorLib;

namespace MathCalculators
{
    public class SubtractFunction : ICalculatorFunction
    {
        public ICalculatorFunctionInfo FunctionInfo
        {
            get;
            private set;
        }

        public SubtractFunction()
        {
            this.FunctionInfo = new DefaultCalculatorFunctionInfo(new Version("1.0.0"), "Subtract", "Subtract one number from another.", "subtract");
        }

        public ICalculatorValue Calculate(PhaseHandler phaseHandler)
        {
            if (phaseHandler == null)
            {
                throw new ArgumentNullException(nameof(phaseHandler));
            }

            //var values = phaseHandler(new DefaultCalculatorPhase("Specify Operands", "Specify the numbers in the subtraction equation.", new ICalculatorValueInfo[]
            //    {
            //        new Int32CalculatorValueInfo("First", "The first number"),
            //        new Int32CalculatorValueInfo("Second", "The second number")
            //    }));

            var difference = 0;
            var first = true;

            //foreach (Int32CalculatorValue value in values)
            //{
            //    if (first)
            //    {
            //        difference = value.Value;
            //        first = false;
            //        continue;
            //    }

            //    difference -= value.Value;
            //}

            return new Int32CalculatorValue(difference);
        }
    }
}
