using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ArcsecantFunction : BaseFunction
    {
        public ArcsecantFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Arcsecant", "Find the arcsecant of an angle.", "arcsecant", "arcsec"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Argument",
                "Specify angle to find the arcsecant of.",
                new AgnosticValue(0.0, new ValueInfo("Angle", null, new RadianUnit())));

            var values = DoPhase(phaseHandler, phase);

            var result = 1.0 / Math.Asin(GetValue<double>(values[0]));

            return new AgnosticValue(result);
        }
    }
}
