using System;
using XCalculateLib;

namespace MathCalculators
{
    public class ModuloFunction : BaseFunction
    {
        public ModuloFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Modulo", "Find the modulo of two numbers.", "modulo", "remainder"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Operands",
                "Specify the operands of the modulo operation.",
                new AgnosticValue(0.0, new ValueInfo("a", "Dividend value.")),
                new AgnosticValue(1.0, new ValueInfo("n", "Divisor value."), i => TypeConverter.ToObject<double>(i) == 0.0 ? throw new DivideByZeroException("The divisor cannot be zero.") : true));

            var values = DoPhase(phaseHandler, phase);

            var a = TypeConverter.ToObject<double>(values[0].Value);
            var n = TypeConverter.ToObject<double>(values[1].Value);

            var remainder = Math.IEEERemainder(a, n);

            return new AgnosticValue(remainder);
        }
    }
}
