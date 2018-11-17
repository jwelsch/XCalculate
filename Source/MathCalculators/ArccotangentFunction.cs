using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ArccotangentFunction : BaseFunction
    {
        public ArccotangentFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Arccotangent", "Find the arccotangent of an angle.", "arccotangent", "arccot"))
        {
        }

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the arccotangent of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => 1.0 / Math.Atan(GetValue<double>(v)));
        }
    }
}
