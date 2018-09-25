using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class RootFunction : BaseFunction
    {
        public RootFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Root", "Find the root of a number.", "root"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Operands",
                "Specify root operation values.",
                new AgnosticValue(0.0, new ValueInfo("Radicand", "Radicand of the root.")),
                new AgnosticValue(2.0, new ValueInfo("Index", "Index of the root.")));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Pow(GetValue<double>(values[0]), 1.0 / GetValue<double>(values[1]));

            return new AgnosticValue(result);
        }
    }
}
