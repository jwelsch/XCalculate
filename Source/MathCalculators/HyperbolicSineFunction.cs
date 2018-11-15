using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicSineFunction : BaseFunction
    {
        public HyperbolicSineFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Hyperbolic Sine", "Find the hyperbolic sine of an angle.", "hyperbolic", "sine", "sinh"))
        {
        }

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the hyperbolic sine of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => Math.Sinh(GetValue<double>(v)));
        }
    }
}
