using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class MultiplyFunction : BaseFunction
    {
        public MultiplyFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Multiply", "Multiply numbers.", "multiply"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Operands",
                "Specify numbers to multiply.",
                new AgnosticArrayValue(
                    null,
                    new ValueInfo("Operands", "Operands to multiply."),
                    i => i != null && i.Length <= 1 ? throw new ArgumentException("Two or more values must be specified.") : true));

            var values = DoPhase(phaseHandler, phase);

            var arrayValues = ((AgnosticArrayValue)values[0]).ToArray<double[]>();

            var product = TypeConverter.ToObject<double>(arrayValues[0]);

            for (var i = 1; i < arrayValues.Length; i++)
            {
                product *= TypeConverter.ToObject<double>(arrayValues[i]);
            }

            return new AgnosticValue(product);
        }
    }
}
