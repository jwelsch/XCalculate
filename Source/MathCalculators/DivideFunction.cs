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
            var phase = new DefaultPhase(
                "Specify Operands",
                "Specify numbers to divide.",
                new AgnosticArrayValue(
                    null,
                    new ValueInfo("Operands", "Operands to divide."),
                    i => i != null && i.Length <= 1 ? throw new ArgumentException("Two or more values must be specified.") : true));

            var values = DoPhase(phaseHandler, phase);

            var arrayValues = ((AgnosticArrayValue)values[0]).ToArray<double[]>();

            var quotient = TypeConverter.ToObject<double>(arrayValues[0]);

            for (var i = 1; i < arrayValues.Length; i++)
            {
                var divisor = TypeConverter.ToObject<double>(arrayValues[i]);

                if (divisor == 0)
                {
                    throw new DivideByZeroException();
                }

                quotient /= divisor;
            }

            return new AgnosticValue(quotient);
        }
    }
}
