using System;
using XCalculateLib;

namespace MathCalculators
{
    public class HyperbolicCotangentFunction : BaseFunction
    {
        public HyperbolicCotangentFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Hyperbolic Cotangent", "Find the hyperbolic cotangent of an angle.", "hyperbolic", "cotangent", "coth"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Operands",
                "Specify angle to find the hyperbolic cotangent of.",
                new AgnosticValue(0.0, new ValueInfo("Angle")));

            var values = DoPhase(phaseHandler, phase);

            var result = 1.0 / Math.Tanh(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}
