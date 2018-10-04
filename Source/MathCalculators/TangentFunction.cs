using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class TangentFunction : BaseFunction
    {
        public TangentFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Tangent", "Find the tangent of an angle.", "tangent", "tan"))
        {
        }

        public override IPhase Calculate(IPhase currentPhase = null)
        {
            return this.SingleCalculate(currentPhase,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the tangent of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => Math.Tan(GetValue<double>(v)));
        }
    }
}
