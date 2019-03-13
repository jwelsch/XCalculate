using System;
using System.Linq;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class SubtractFunction : BaseFunction
    {
        public SubtractFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Subtract", new ValueInfo("Difference", "Difference of the numbers"), "Subtract numbers.", "algebra", "subtract", "difference"),
                  new AgnosticArrayValue(new[] { 0.0, 0.0 }, new ValueInfo("Operands", "Numbers to subtract"), i => i.Length <= 1 ? throw new ArgumentException("Two or more values must be specified.") : true))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var result = GetValues<double[]>(inputs[0]).Aggregate((x, y) => x - y);

            return this.CreateResults(result);
        }
    }
}
