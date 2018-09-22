using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class SineFunction : BaseFunction
    {
        public SineFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Sine", "Find the sine of an angle.", "sine", "sin"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Operands",
                "Specify angle to find the sine of.",
                new AgnosticValue(0.0, new ValueInfo("Angle")));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Sin(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}
