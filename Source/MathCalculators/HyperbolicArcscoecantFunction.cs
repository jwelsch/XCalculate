using System;
using XCalculateLib;

namespace MathCalculators
{
    public class HyperbolicArccosecantFunction : BaseFunction
    {
        public HyperbolicArccosecantFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Hyperbolic Arccosecant", "Find the hyperbolic arccosecant of an angle.", "hyperbolic", "arccosecant", "arccsch"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Operands",
                "Specify angle to find the hyperbolic arccosecant of.",
                new AgnosticValue(0.0, new ValueInfo("Angle")));

            var values = DoPhase(phaseHandler, phase);

            var result = 1.0 / Math.Acosh(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}
