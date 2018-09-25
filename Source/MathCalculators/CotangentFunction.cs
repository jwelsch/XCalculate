using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class CotangentFunction : BaseFunction
    {
        public CotangentFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Cotangent", "Find the cotangent of an angle.", "cotangent", "cot"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Argument",
                "Specify angle to find the cotangent of.",
                new AgnosticValue(0.0, new ValueInfo("Angle", null, new RadianUnit())));

            var values = DoPhase(phaseHandler, phase);

            var result = 1.0 / Math.Tan(GetValue<double>(values[0]));

            return new AgnosticValue(result);
        }
    }
}
