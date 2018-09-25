using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicArctangentFunction : BaseFunction
    {
        public HyperbolicArctangentFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Hyperbolic Arctangent", "Find the hyperbolic arctangent of an angle.", "hyperbolic", "arctangent", "arctanh"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Argument",
                "Specify angle to find the hyperbolic arctangent of.",
                new AgnosticValue(0.0, new ValueInfo("Angle", null, new RadianUnit())));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Atanh(GetValue<double>(values[0]));

            return new AgnosticValue(result);
        }
    }
}
