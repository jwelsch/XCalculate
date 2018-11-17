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

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the hyperbolic arccosine of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => Math.Acosh(GetValue<double>(v)));
        }
    }
}
