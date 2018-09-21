using System;
using XCalculateLib;

namespace MathCalculators
{
    public class HyperbolicTangentFunction : BaseFunction
    {
        public HyperbolicTangentFunction()
            : base(new DefaultFunctionInfo(new Version("1.0.0"), "Hyperbolic Tangent", "Find the hyperbolic tangent of an angle.", "tanh", "hyperbolic"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new DefaultPhase(
                "Specify Operands",
                "Specify angle to find the hyperbolic tangent of.",
                new AgnosticValue(0.0, new ValueInfo("Angle")));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Tanh(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}
