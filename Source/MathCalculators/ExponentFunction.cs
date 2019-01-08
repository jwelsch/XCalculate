using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ExponentFunction : BaseFunction
    {
        public ExponentFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Exponent", new ValueInfo("Result", "The base raised to the power."), "Raise a number to a power.", "arithmetic", "exponent", "power"),
                  new AgnosticValue(0.0, new ValueInfo("Base")),
                  new AgnosticValue(0.0, new ValueInfo("Exponent")))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var baseInput = (AgnosticValue)inputs[0];
            var exponentInput = (AgnosticValue)inputs[1];

            var result = Math.Pow(baseInput.GetValueAs<double>(), exponentInput.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
