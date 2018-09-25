using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicArccosineFunction : BaseFunction
    {
        public HyperbolicArccosineFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Hyperbolic Arccosine", "Find the hyperbolic arccosine of an angle.", "hyperbolic", "arccosine", "arccosh"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Argument",
                "Specify angle to find the hyperbolic arccosine of.",
                new AgnosticValue(0.0, new ValueInfo("Angle", null, new RadianUnit())));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Acosh(GetValue<double>(values[0]));

            return new AgnosticValue(result);
        }
    }
}
