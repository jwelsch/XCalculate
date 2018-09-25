using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class LogarithmFunction : BaseFunction
    {
        public LogarithmFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Logarithm", "Find the logarithm of a number.", "logarithm"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Arguments",
                "Specify logarithm arguments.",
                new AgnosticValue(0.0, new ValueInfo("Argument", "Argument of the logarithm.")),
                new AgnosticValue(10.0, new ValueInfo("Base", "Base of the logarithm.")));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Log(GetValue<double>(values[0]), GetValue<double>(values[1]));

            return new AgnosticValue(result);
        }
    }
}
