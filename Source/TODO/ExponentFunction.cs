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

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Operands",
                    "Specify exponential equation values.",
                    new AgnosticValue(0.0, new ValueInfo("Base")),
                    new AgnosticValue(0.0, new ValueInfo("Exponent"))),
                v => Math.Pow(GetValue<double>(v[0]), GetValue<double>(v[1])));
        }
    }
}
