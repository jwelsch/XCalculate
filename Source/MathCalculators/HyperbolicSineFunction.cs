using System;
using XCalculateLib;

namespace MathCalculators
{
    public class HyperbolicSineFunction : BaseFunction
    {
        public HyperbolicSineFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Hyperbolic Sine", "Find the hyperbolic sine of an angle.", "hyperbolic", "sine", "sinh"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Argument",
                "Specify angle to find the hyperbolic sine of.",
                new AgnosticValue(0.0, new ValueInfo("Angle", null, new RadianUnit())));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Sinh(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}
