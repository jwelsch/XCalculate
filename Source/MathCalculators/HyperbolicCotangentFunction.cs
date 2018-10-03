using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicCotangentFunction : BaseFunction
    {
        public HyperbolicCotangentFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Hyperbolic Cotangent", "Find the hyperbolic cotangent of an angle.", "hyperbolic", "cotangent", "coth"))
        {
        }

        public override IPhase Calculate(IPhase currentPhase = null)
        {
            return this.SingleCalculate(currentPhase,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the hyperbolic cotangent of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => 1.0 / Math.Tanh(GetValue<double>(v)));
        }
    }
}
