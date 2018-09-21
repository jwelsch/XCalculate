using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class SubtractFunction : BaseFunction
    {
        public SubtractFunction()
            : base(new DefaultFunctionInfo(new Version("1.0.0"), "Subtract", "Subtract one number from another.", "subtract"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            if (phaseHandler == null)
            {
                throw new ArgumentNullException(nameof(phaseHandler));
            }

            var phaseValues = phaseHandler(new DefaultPhase("Specify Operands", "Specify the numbers in the subtraction equation.", new AgnosticArrayValue(null, new ValueInfo("Operands", "Operands to subtract."), i => i != null && i.Length <= 1 ? throw new ArgumentException("Two or more values must be specified.") : true)));

            var difference = 0.0;
            var first = true;

            foreach (var phaseValue in phaseValues)
            {
                var arrayValue = (AgnosticArrayValue)phaseValue;

                var values = arrayValue.ToArray<double[]>();

                foreach (var value in values)
                {
                    if (first)
                    {
                        difference = value;
                        first = false;
                        continue;
                    }

                    difference -= value;
                }
            }

            return new AgnosticValue(difference);
        }
    }
}
