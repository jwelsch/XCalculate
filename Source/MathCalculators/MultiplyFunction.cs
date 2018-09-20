using System;
using XCalculateLib;

namespace MathCalculators
{
    public class MultiplyFunction : IFunction
    {
        public IFunctionInfo FunctionInfo
        {
            get;
            private set;
        }

        public MultiplyFunction()
        {
            this.FunctionInfo = new DefaultFunctionInfo(new Version("1.0.0"), "Multiply", "Multiply two numbers together.", "multiply");
        }

        public IValue Calculate(PhaseHandler phaseHandler)
        {
            if (phaseHandler == null)
            {
                throw new ArgumentNullException(nameof(phaseHandler));
            }

            //var values = phaseHandler(new DefaultPhase("Specify Operands", "Specify two numbers to multiply together.", new IValueInfo[]
            //    {
            //        new Int32ValueInfo("First", "The first number"),
            //        new Int32ValueInfo("Second", "The second number")
            //    }));

            var product = 0;

            //foreach (Int32Value value in values)
            //{
            //    product *= value.Value;
            //}

            return new Int32Value(product);
        }
    }
}
