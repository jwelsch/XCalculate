using System;
using System.Collections.Generic;
using XCalculateLib;

namespace MathCalculators
{
    public class DivideFunction : IFunction
    {
        public IFunctionInfo FunctionInfo
        {
            get;
            private set;
        }

        public DivideFunction()
        {
            this.FunctionInfo = new DefaultFunctionInfo(new Version("1.0.0"), "Divide", "Divide one number into another.", "divide");
        }

        public IValue Calculate(PhaseHandler phaseHandler)
        {
            if (phaseHandler == null)
            {
                throw new ArgumentNullException(nameof(phaseHandler));
            }

            //var values = phaseHandler(new DefaultPhase("Specify Operands", "Specify the numbers in the division equation.", new IValueInfo[]
            //    {
            //        new Int32ValueInfo("First", "The first number"),
            //        new Int32ValueInfo("Second", "The second number")
            //    }));

            var quotient = 0.0;
            var first = true;

            //foreach (Int32Value value in values)
            //{
            //    if (first)
            //    {
            //        quotient = value.Value;
            //        first = false;
            //        continue;
            //    }

            //    quotient /= value.Value;
            //}

            return new DoubleValue(quotient);
        }
    }
}
