using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class MultiplyFunction : BaseFunction
    {
        public MultiplyFunction()
            : base(new DefaultFunctionInfo(new Version("1.0.0"), "Multiply", "Multiply numbers.", "multiply"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            if (phaseHandler == null)
            {
                throw new ArgumentNullException(nameof(phaseHandler));
            }

            var phaseValues = phaseHandler(new DefaultPhase("Specify Operands", "Specify numbers to multiply.", new AgnosticArrayValue(null, new ValueInfo("Operands", "Operands to multiply."), i => i != null && i.Length <= 1 ? throw new ArgumentException("Two or more values must be specified.") : true)));

            var product = 0.0;
            var first = true;

            foreach (var phaseValue in phaseValues)
            {
                var arrayValue = (AgnosticArrayValue)phaseValue;

                var values = arrayValue.ToArray<double[]>();

                foreach (var value in values)
                {
                    if (first)
                    {
                        product = value;
                        first = false;
                        continue;
                    }

                    product *= value;
                }
            }

            return new AgnosticValue(product);
        }
    }
}
