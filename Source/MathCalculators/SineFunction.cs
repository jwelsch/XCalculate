using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class SineFunction : BaseFunction
    {
        public SineFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Sine", "Find the sine of an angle.", "sine", "sin"))
        {
        }

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the sine of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => Math.Sin(GetValue<double>(v)));
        }
    }
}
