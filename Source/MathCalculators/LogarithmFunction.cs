using System;
using System.Linq;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class LogarithmFunction : BaseFunction
    {
        public LogarithmFunction()
            : base(new DefaultFunctionInfo(new Version("1.0.0"), "Logarithm", "Find the logarithm of a number.", "logarithm"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            if (phaseHandler == null)
            {
                throw new ArgumentNullException(nameof(phaseHandler));
            }

            var phase = new DefaultPhase(
                "Specify Operands",
                "Specify logarithm equation values.",
                new AgnosticValue(0.0, new ValueInfo("Argument", "Argument of the logarithm.")),
                new AgnosticValue(10.0, new ValueInfo("Base", "Base of the logarithm.")));

            var phaseValues = phaseHandler(phase);

            var values = phaseValues.ToArray();

            var result = Math.Log(TypeConverter.ToObject<double>(values[0].Value), TypeConverter.ToObject<double>(values[1].Value));

            return new AgnosticValue(result);
        }
    }
}
