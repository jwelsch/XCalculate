using System;
using XCalculateLib;

namespace MathCalculators
{
    public class SubtractFunction : IFunction
    {
        public IFunctionInfo FunctionInfo
        {
            get;
            private set;
        }

        public SubtractFunction()
        {
            this.FunctionInfo = new DefaultFunctionInfo(new Version("1.0.0"), "Subtract", "Subtract one number from another.", "subtract");
        }

        public IValue Calculate(PhaseHandler phaseHandler)
        {
            if (phaseHandler == null)
            {
                throw new ArgumentNullException(nameof(phaseHandler));
            }

            //var values = phaseHandler(new DefaultPhase("Specify Operands", "Specify the numbers in the subtraction equation.", new IValueInfo[]
            //    {
            //        new Int32ValueInfo("First", "The first number"),
            //        new Int32ValueInfo("Second", "The second number")
            //    }));

            var difference = 0;
            var first = true;

            //foreach (Int32Value value in values)
            //{
            //    if (first)
            //    {
            //        difference = value.Value;
            //        first = false;
            //        continue;
            //    }

            //    difference -= value.Value;
            //}

            return new Int32Value(difference);
        }
    }
}
