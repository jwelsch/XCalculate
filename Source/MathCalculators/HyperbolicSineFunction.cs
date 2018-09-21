using System;
using XCalculateLib;

namespace MathCalculators
{
    public class HyperbolicSineFunction : BaseFunction
    {
        public HyperbolicSineFunction()
            : base(new DefaultFunctionInfo(new Version("1.0.0"), "Hyperbolic Sine", "Find the hyperbolic sine of an angle.", "sinh", "hyperbolic"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new DefaultPhase(
                "Specify Operands",
                "Specify angle to find the hyperbolic sine of.",
                new AgnosticValue(0.0, new ValueInfo("Angle")));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Sinh(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}
