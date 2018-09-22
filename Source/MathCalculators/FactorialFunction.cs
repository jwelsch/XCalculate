using System;
using System.Numerics;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class FactorialFunction : BaseFunction
    {
        public FactorialFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Factorial", "Apply the factorial function to a number.", "factorial"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Argument",
                "Argument for the gamma function.",
                new AgnosticValue(0.0, new ValueInfo("n", "Value to the factorial function."),
                i => TypeConverter.ToObject<double>(i) >= 0.0));

            var values = DoPhase(phaseHandler, phase);

            var n = TypeConverter.ToObject<double>(values[0].Value);

            var factorial = GammaFunction.Gamma(new Complex(n + 1.0, 0.0));

            return new AgnosticValue(factorial.Real);
        }
    }
}
