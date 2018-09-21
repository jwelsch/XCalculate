using System;
using XCalculateLib;

namespace MathCalculators
{
    public class CotangentFunction : BaseFunction
    {
        public CotangentFunction()
            : base(new DefaultFunctionInfo(new Version("1.0.0"), "Cotangent", "Find the cotangent of an angle.", "cotangent", "cot"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new DefaultPhase(
                "Specify Operands",
                "Specify angle to find the cotangent of.",
                new AgnosticValue(0.0, new ValueInfo("Angle")));

            var values = DoPhase(phaseHandler, phase);

            var result = 1.0 / Math.Tan(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}
