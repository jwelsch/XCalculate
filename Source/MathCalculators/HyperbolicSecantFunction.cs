using System;
using XCalculateLib;

namespace MathCalculators
{
    public class HyperbolicSecantFunction : BaseFunction
    {
        public HyperbolicSecantFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Hyperbolic Secant", "Find the hyperbolic secant of an angle.", "hyperbolic", "secant", "sech"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Argument",
                "Specify angle to find the hyperbolic secant of.",
                new AgnosticValue(0.0, new ValueInfo("Angle", null, new RadianUnit())));

            var values = DoPhase(phaseHandler, phase);

            var result = 1.0 / Math.Sinh(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}
