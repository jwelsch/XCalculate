using System;
using System.Numerics;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class FactorialFunction : BaseFunction
    {
        public FactorialFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Factorial", new ValueInfo("Factorial", "Factorial of the number."), "Apply the factorial function to a number.", "algebra", "factorial"),
                  new AgnosticValue(0.0, new ValueInfo("n"), i => TypeConverter.ToObject<double>(i) >= 0.0 ? true : throw new ArgumentException("Value must be greater than or equal to zero.")))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var nInput = (AgnosticValue)inputs[0];

            var result = GammaFunction.Gamma(new Complex(GetValue<double>(nInput) + 1.0, 0.0));

            return this.CreateResults(result.Real);
        }
    }
}
