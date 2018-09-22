using System;
using XCalculateLib;

namespace MathCalculators
{
    public class ArccosineFunction : BaseFunction
    {
        public ArccosineFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Arccosine", "Find the arccosine of an angle.", "arccosine", "arccos"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Operands",
                "Specify angle to find the arccosine of.",
                new AgnosticValue(0.0, new ValueInfo("Angle")));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Acos(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}
