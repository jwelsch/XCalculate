using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class CosineFunction : BaseFunction
    {
        public CosineFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Cosine", "Find the cosine of an angle.", "cosine", "cos"))
        {
        }

        public override IPhase Calculate(IPhase currentPhase = null)
        {
            return this.SingleCalculate(currentPhase,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the cosine of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => Math.Cos(GetValue<double>(v)));
        }
    }
}
