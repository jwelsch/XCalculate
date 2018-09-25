using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class SineFunction : BaseFunction
    {
        public SineFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Sine", "Find the sine of an angle.", "sine", "sin"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Argument",
                "Specify angle to find the sine of.",
                new AgnosticValue(0.0, new ValueInfo("Angle", null, new RadianUnit())));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Sin(GetValue<double>(values[0]));

            return new AgnosticValue(result);
        }
    }
}
