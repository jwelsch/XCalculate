using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class RootFunction : BaseFunction
    {
        public RootFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Root", new ValueInfo("Root", "The root of the number."), "Find the root of a number.", "algebra", "root"),
                  new AgnosticValue(0.0, new ValueInfo("Radicand")),
                  new AgnosticValue(2.0, new ValueInfo("Index")))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var radicandInput = (AgnosticValue)inputs[0];
            var indexInput = (AgnosticValue)inputs[1];

            var result = Math.Pow(radicandInput.GetValueAs<double>(), 1.0 / indexInput.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
