using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicCosecantFunction : BaseFunction
    {
        public HyperbolicCosecantFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Hyperbolic Cosecant", "Find the hyperbolic cosecant of an angle.", "hyperbolic", "cosecant", "csch"))
        {
        }

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the hyperbolic cosecant of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => 1.0 / Math.Cosh(GetValue<double>(v)));
        }
    }
}
