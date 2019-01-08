using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class NaturalLogarithmFunction : BaseFunction
    {
        public NaturalLogarithmFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Natural Logarithm", new ValueInfo("Natural Logarithm", "Natural logarithm of the number."), "Find the natural logarithm of a number.", "algebra", "natural", "logarithm", "e"),
                  new AgnosticValue(1.0, new ValueInfo("n"), i => TypeConverter.ToObject<double>(i) > 0.0 ? true : throw new ArgumentException("Value must be greater than zero.")))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var nInput = (AgnosticValue)inputs[0];

            var result = Math.Log(nInput.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
