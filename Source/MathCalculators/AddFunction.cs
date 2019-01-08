using System;
using System.Linq;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class AddFunction : BaseFunction
    {
        public AddFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Add", new ValueInfo("Sum", "Sum of the numbers"), "Add numbers.", "arithmetic", "add"),
                  new AgnosticArrayValue(new[] { 0.0, 0.0 }, new ValueInfo("Addends", "Numbers to add together"), i => i.Length <= 1 ? throw new ArgumentException("Two or more values must be specified.") : true))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var result = GetValues<double[]>(inputs[0]).Aggregate((x, y) => x + y);

            return this.CreateResults(result);
        }
    }
}
