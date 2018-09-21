using System;
using XCalculateLib;

namespace MathCalculators
{
    public class SecantFunction : BaseFunction
    {
        public SecantFunction()
            : base(new DefaultFunctionInfo(new Version("1.0.0"), "Secant", "Find the secant of an angle.", "secant", "sec"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new DefaultPhase(
                "Specify Operands",
                "Specify angle to find the secant of.",
                new AgnosticValue(0.0, new ValueInfo("Angle")));

            var values = DoPhase(phaseHandler, phase);

            var result = 1.0 / Math.Sin(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}
