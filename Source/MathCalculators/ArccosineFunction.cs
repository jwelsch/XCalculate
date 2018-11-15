using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ArccosineFunction : BaseFunction
    {
        public ArccosineFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Arccosine", "Find the arccosine of an angle.", "arccosine", "arccos"))
        {
        }

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the arccosine of.",
                    new AgnosticValue(0.0, new ValueInfo("Angle", null, new RadianUnit()))),
                v => Math.Acos(GetValue<double>(v)));
        }
    }
}
