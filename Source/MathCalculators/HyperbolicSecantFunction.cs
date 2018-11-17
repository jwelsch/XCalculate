using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicSecantFunction : BaseFunction
    {
        public HyperbolicSecantFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Hyperbolic Secant", "Find the hyperbolic secant of an angle.", "hyperbolic", "secant", "sech"))
        {
        }

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the hyperbolic secant of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => 1.0 / Math.Sinh(GetValue<double>(v)));
        }
    }
}
