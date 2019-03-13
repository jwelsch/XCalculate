using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class SecantFunction : BaseFunction
    {
        public SecantFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Secant", "Find the secant of an angle.", "secant", "sec"))
        {
        }

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the secant of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => 1.0 / Math.Sin(GetValue<double>(v)));
        }
    }
}
