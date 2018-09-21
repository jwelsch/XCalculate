using System;
using XCalculateLib;

namespace MathCalculators
{
    public class DivideFunction : BaseFunction
    {
        public DivideFunction()
            : base(new DefaultFunctionInfo(new Version("1.0.0"), "Divide", "Divide numbers.", "divide"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            if (phaseHandler == null)
            {
                throw new ArgumentNullException(nameof(phaseHandler));
            }

            var phaseValues = phaseHandler(new DefaultPhase("Specify Operands", "Specify numbers to divide.", new AgnosticArrayValue(null, new ValueInfo("Operands", "Operands to divide."), i => i != null && i.Length <= 1 ? throw new ArgumentException("Two or more values must be specified.") : true)));

            var quotient = 0.0;
            var first = true;

            foreach (var phaseValue in phaseValues)
            {
                var arrayValue = (AgnosticArrayValue)phaseValue;

                var values = arrayValue.ToArray<double[]>();

                foreach (var value in values)
                {
                    if (first)
                    {
                        quotient = value;
                        first = false;
                        continue;
                    }
                    else
                    {
                        if (value == 0)
                        {
                            throw new DivideByZeroException();
                        }
                    }

                    quotient /= value;
                }
            }

            return new AgnosticValue(quotient);
        }
    }
}
