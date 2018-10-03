using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicArctangentFunction : BaseFunction
    {
        public HyperbolicArctangentFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Hyperbolic Arctangent", "Find the hyperbolic arctangent of an angle.", "hyperbolic", "arctangent", "arctanh"))
        {
        }

        public override IPhase Calculate(IPhase currentPhase = null)
        {
            return this.SingleCalculate(currentPhase,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the hyperbolic arctangent of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => Math.Atanh(GetValue<double>(v)));
        }
    }
}
