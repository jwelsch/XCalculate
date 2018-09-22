using System;
using XCalculateLib;

namespace MathCalculators
{
    public class HyperbolicArcsecantFunction : BaseFunction
    {
        public HyperbolicArcsecantFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Hyperbolic Arcsecant", "Find the hyperbolic arcsecant of an angle.", "hyperbolic", "arcsecant", "arcsech"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Argument",
                "Specify angle to find the hyperbolic arcsecant of.",
                new AgnosticValue(0.0, new ValueInfo("Angle", null, new RadianUnit())));

            var values = DoPhase(phaseHandler, phase);

            var result = 1.0 / Math.Asinh(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}
