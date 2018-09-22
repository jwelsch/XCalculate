using System;
using XCalculateLib;

namespace MathCalculators
{
    public class ArcsecantFunction : BaseFunction
    {
        public ArcsecantFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Arcsecant", "Find the arcsecant of an angle.", "arcsecant", "arcsec"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Operands",
                "Specify angle to find the arcsecant of.",
                new AgnosticValue(0.0, new ValueInfo("Angle")));

            var values = DoPhase(phaseHandler, phase);

            var result = 1.0 / Math.Asin(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}
