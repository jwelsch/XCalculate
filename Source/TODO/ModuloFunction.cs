using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ModuloFunction : BaseFunction
    {
        public ModuloFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Modulo", "Find the modulo of two numbers.", "modulo", "remainder"))
        {
        }

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Operands",
                    "Specify the operands of the modulo operation.",
                    new AgnosticValue(0.0, new ValueInfo("a", "Dividend value.")),
                    new AgnosticValue(1.0, new ValueInfo("n", "Divisor value."), i => TypeConverter.ToObject<double>(i) == 0.0 ? throw new DivideByZeroException("The divisor cannot be zero.") : true)),
                v => Math.IEEERemainder(GetValue<double>(v[0]), GetValue<double>(v[1])));
        }
    }
}
