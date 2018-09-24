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

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Argument",
                "Specify angle to find the hyperbolic arccosecant of.",
                new AgnosticValue(0.0, new ValueInfo("Angle", null, new RadianUnit())));

            var values = DoPhase(phaseHandler, phase);

            var result = 1.0 / Math.Acosh(GetValue<double>(values[0]));

            return new AgnosticValue(result);
        }
    }
}
