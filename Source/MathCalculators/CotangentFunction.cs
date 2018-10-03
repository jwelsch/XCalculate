using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class CotangentFunction : BaseFunction
    {
        public CotangentFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Cotangent", "Find the cotangent of an angle.", "cotangent", "cot"))
        {
        }

        public override IPhase Calculate(IPhase currentPhase = null)
        {
            return this.SingleCalculate(currentPhase,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the cotangent of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => 1.0 / Math.Tan(GetValue<double>(v)));
        }
    }
}
