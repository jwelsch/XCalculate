using System;
using XCalculateLib;

namespace MathCalculators
{
    public class HyperbolicCosecantFunction : BaseFunction
    {
        public HyperbolicCosecantFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Hyperbolic Cosecant", "Find the hyperbolic cosecant of an angle.", "hyperbolic", "cosecant", "csch"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Operands",
                "Specify angle to find the hyperbolic cosecant of.",
                new AgnosticValue(0.0, new ValueInfo("Angle")));

            var values = DoPhase(phaseHandler, phase);

            var result = 1.0 / Math.Cosh(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}
