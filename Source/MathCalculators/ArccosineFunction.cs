using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ArccosineFunction : BaseFunction
    {
        public ArccosineFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Arccosine", "Find the arccosine of an angle.", "arccosine", "arccos"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Argument",
                "Specify angle to find the arccosine of.",
                new AgnosticValue(0.0, new ValueInfo("Angle", null, new RadianUnit())));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Acos(GetValue<double>(values[0]));

            return new AgnosticValue(result);
        }
    }
}
