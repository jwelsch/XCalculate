using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class CosecantFunction : BaseFunction
    {
        public CosecantFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Cosecant", "Find the cosecant of an angle.", "cosecant", "csc"))
        {
        }

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the cosecant of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => 1.0 / Math.Cos(GetValue<double>(v)));
        }
    }
}
