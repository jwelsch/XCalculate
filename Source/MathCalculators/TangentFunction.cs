using System;
using XCalculateLib;

namespace MathCalculators
{
    public class TangentFunction : BaseFunction
    {
        public TangentFunction()
            : base(new DefaultFunctionInfo(new Version("1.0.0"), "Tangent", "Find the tangent of an angle.", "tangent", "tan"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new DefaultPhase(
                "Specify Operands",
                "Specify angle to find the tangent of.",
                new AgnosticValue(0.0, new ValueInfo("Angle")));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Tan(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}
