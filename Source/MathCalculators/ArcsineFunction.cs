using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ArcsineFunction : BaseFunction
    {
        public ArcsineFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Arcsine", "Find the arcsine of an angle.", "arcsine", "arcsin"))
        {
        }

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the arcsine of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => Math.Asin(GetValue<double>(v)));
        }
    }
}
