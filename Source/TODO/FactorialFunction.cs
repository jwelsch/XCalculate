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

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Argument",
                    "Argument for the factorial function.",
                    new AgnosticValue(new ValueInfo("n", "Value to the factorial function."), i => TypeConverter.ToObject<double>(i) >= 0.0)),
                v => GammaFunction.Gamma(new Complex(GetValue<double>(v[0]) + 1.0, 0.0)).Real);
        }
    }
}
