using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ArctangentFunction : BaseFunction
    {
        public ArctangentFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Arctangent", "Find the arctangent of an angle.", "arctangent", "arctan"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Argument",
                "Specify angle to find the arctangent of.",
                new AgnosticValue(0.0, new ValueInfo("Angle", null, new RadianUnit())));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Atan(GetValue<double>(values[0]));

            return new AgnosticValue(result);
        }
    }
}
