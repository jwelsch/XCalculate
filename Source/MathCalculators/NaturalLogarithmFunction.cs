using System;
using XCalculateLib;

namespace MathCalculators
{
    public class NaturalLogarithmFunction : BaseFunction
    {
        public NaturalLogarithmFunction()
            : base(new DefaultFunctionInfo(new Version("1.0.0"), "Natural Logarithm", "Find the natural logarithm of a number.", "natural", "logarithm", "e"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new DefaultPhase(
                "Specify Argument",
                "Specify natural logarithm argument.",
                new AgnosticValue(1.0, new ValueInfo("Argument", "Argument of the natural logarithm."), i => TypeConverter.ToObject<double>(i) > 0.0));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Log(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}
