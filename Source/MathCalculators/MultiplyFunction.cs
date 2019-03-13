using System;
using System.Linq;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class MultiplyFunction : BaseFunction
    {
        public MultiplyFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Multiply", new ValueInfo("Product", "Product of the numbers"), "Multiply numbers.", "algebra", "multiply"),
                  new AgnosticArrayValue(new[] { 0.0, 0.0 }, new ValueInfo("Factors", "Numbers to multiply together"), i => i.Length <= 1 ? throw new ArgumentException("Two or more values must be specified.") : true))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var result = GetValues<double[]>(inputs[0]).Aggregate((x, y) => x * y);

            return this.CreateResults(result);
        }
    }
}
