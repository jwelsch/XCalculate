using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicArcsineFunction : BaseFunction
    {
        public HyperbolicArcsineFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Hyperbolic Arcsine", "Find the hyperbolic arcsine of an angle.", "hyperbolic", "arcsine", "arcsinh"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Argument",
                "Specify angle to find the hyperbolic arcsine of.",
                new AgnosticValue(0.0, new ValueInfo("Angle", null, new RadianUnit())));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Asinh(GetValue<double>(values[0]));

            return new AgnosticValue(result);
        }
    }
}
