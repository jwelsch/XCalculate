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

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the hyperbolic tangent of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => Math.Tanh(GetValue<double>(v)));
        }
    }
}
