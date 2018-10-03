using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicArcsecantFunction : BaseFunction
    {
        public HyperbolicArcsecantFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Hyperbolic Arcsecant", "Find the hyperbolic arcsecant of an angle.", "hyperbolic", "arcsecant", "arcsech"))
        {
        }

        public override IPhase Calculate(IPhase currentPhase = null)
        {
            return this.SingleCalculate(currentPhase,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the hyperbolic arcsecant of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => 1.0 / Math.Asinh(GetValue<double>(v)));
        }
    }
}
