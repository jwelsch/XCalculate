using System;
using System.Linq;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ExponentFunction : BaseFunction
    {
        public ExponentFunction()
            : base(new DefaultFunctionInfo(new Version("1.0.0"), "Exponent", "Raise a number to a power.", "exponent", "power"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {

            var phase = new DefaultPhase(
                "Specify Operands",
                "Specify exponential equation.",
                new AgnosticValue(0.0, new ValueInfo("Base")),
                new AgnosticValue(0.0, new ValueInfo("Exponent")));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Pow(TypeConverter.ToObject<double>(values[0].Value), TypeConverter.ToObject<double>(values[1].Value));

            return new AgnosticValue(result);
        }
    }
}
