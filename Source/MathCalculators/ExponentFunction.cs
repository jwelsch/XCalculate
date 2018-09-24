using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ExponentFunction : BaseFunction
    {
        public ExponentFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Exponent", "Raise a number to a power.", "exponent", "power"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {

            var phase = new Phase(
                "Specify Operands",
                "Specify exponential equation.",
                new AgnosticValue(0.0, new ValueInfo("Base")),
                new AgnosticValue(0.0, new ValueInfo("Exponent")));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Pow(GetValue<double>(values[0]), GetValue<double>(values[1]));

            return new AgnosticValue(result);
        }
    }
}
