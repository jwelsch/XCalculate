using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicTangentFunction : BaseFunction
    {
        public HyperbolicTangentFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Hyperbolic Tangent", "Find the hyperbolic tangent of an angle.", "hyperbolic", "tangent", "tanh"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Argument",
                "Specify angle to find the hyperbolic tangent of.",
                new AgnosticValue(0.0, new ValueInfo("Angle", null, new RadianUnit())));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Tanh(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}
