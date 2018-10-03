using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicArccosecantFunction : BaseFunction
    {
        public HyperbolicArccosecantFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Hyperbolic Arccosecant", "Find the hyperbolic arccosecant of an angle.", "hyperbolic", "arccosecant", "arccsch"))
        {
        }

        public override IPhase Calculate(IPhase currentPhase = null)
        {
            return this.SingleCalculate(currentPhase,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the hyperbolic arccosecant of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => 1.0 / Math.Acosh(GetValue<double>(v)));
        }
    }
}
