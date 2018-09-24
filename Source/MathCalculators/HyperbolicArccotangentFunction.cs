using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicArccotangentFunction : BaseFunction
    {
        public HyperbolicArccotangentFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Hyperbolic Arccotangent", "Find the hyperbolic arccotangent of an angle.", "hyperbolic", "arccotangent", "arccoth"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Argument",
                "Specify angle to find the hyperbolic arccotangent of.",
                new AgnosticValue(0.0, new ValueInfo("Angle", null, new RadianUnit())));

            var values = DoPhase(phaseHandler, phase);

            var result = 1.0 / Math.Atanh(GetValue<double>(values[0]));

            return new AgnosticValue(result);
        }
    }
}
