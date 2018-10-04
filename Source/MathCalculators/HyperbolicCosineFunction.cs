using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicCosineFunction : BaseFunction
    {
        public HyperbolicCosineFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Hyperbolic Cosine", "Find the hyperbolic cosine of an angle.", "hyperbolic", "cosine", "cosh"))
        {
        }

        public override IPhase Calculate(IPhase currentPhase = null)
        {
            return this.SingleCalculate(currentPhase,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the hyperbolic cosine of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => Math.Cosh(GetValue<double>(v)));
        }
    }
}
