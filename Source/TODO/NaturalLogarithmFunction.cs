using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class NaturalLogarithmFunction : BaseFunction
    {
        public NaturalLogarithmFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Natural Logarithm", "Find the natural logarithm of a number.", "natural", "logarithm", "e"))
        {
        }

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Arguments",
                    "Specify natural logarithm argument.",
                    new AgnosticValue(1.0, new ValueInfo("Argument", "Argument to the natural logarithm."), i => TypeConverter.ToObject<double>(i) > 0.0)),
                v => Math.Log(GetValue<double>(v[0])));
        }
    }
}
