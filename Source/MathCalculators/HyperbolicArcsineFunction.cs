using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicArcsineFunction : BaseFunction
    {
        public HyperbolicArcsineFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Hyperbolic Arcsine", "Find the hyperbolic arcsine of an angle.", "hyperbolic", "arcsine", "arcsinh"))
        {
        }

        public override IPhase Calculate(IPhase currentPhase = null)
        {
            return this.SingleCalculate(currentPhase,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the hyperbolic arcsine of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => Math.Asinh(GetValue<double>(v)));
        }
    }
}
