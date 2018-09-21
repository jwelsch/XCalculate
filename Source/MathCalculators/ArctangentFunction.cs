using System;
using XCalculateLib;

namespace MathCalculators
{
    public class ArctangentFunction : BaseFunction
    {
        public ArctangentFunction()
            : base(new DefaultFunctionInfo(new Version("1.0.0"), "Arctangent", "Find the arctangent of an angle.", "arctangent", "arctan"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new DefaultPhase(
                "Specify Operands",
                "Specify angle to find the arctangent of.",
                new AgnosticValue(0.0, new ValueInfo("Angle")));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Atan(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}
