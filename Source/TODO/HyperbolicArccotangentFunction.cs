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

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the hyperbolic arccotangent of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => 1.0 / Math.Atanh(GetValue<double>(v)));
        }
    }
}
