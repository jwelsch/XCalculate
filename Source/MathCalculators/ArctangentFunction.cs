using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ArctangentFunction : BaseFunction
    {
        public ArctangentFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Arctangent", "Find the arctangent of an angle.", "arctangent", "arctan"))
        {
        }

        public override IPhase Calculate(IPhase currentPhase = null)
        {
            return this.SingleCalculate(currentPhase,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the arctangent of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => Math.Atan(GetValue<double>(v)));
        }
    }
}
