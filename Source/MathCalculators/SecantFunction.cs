using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class SecantFunction : BaseFunction
    {
        public SecantFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Secant", "Find the secant of an angle.", "secant", "sec"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Argument",
                "Specify angle to find the secant of.",
                new AgnosticValue(0.0, new ValueInfo("Angle", null, new RadianUnit())));

            var values = DoPhase(phaseHandler, phase);

            var result = 1.0 / Math.Sin(GetValue<double>(values[0]));

            return new AgnosticValue(result);
        }
    }
}
