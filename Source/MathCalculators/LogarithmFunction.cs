using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class LogarithmFunction : BaseFunction
    {
        public LogarithmFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Logarithm", new ValueInfo("Result", "Logarithm of the number."), "Find the logarithm of a number.", "algebra", "logarithm"),
                  new AgnosticValue(0.0, new ValueInfo("Argument", "Argument of the logarithm.")),
                  new AgnosticValue(10.0, new ValueInfo("Base", "Base of the logarithm.")))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var argumentInput = (AgnosticValue)inputs[0];
            var baseInput = (AgnosticValue)inputs[1];

            var result = Math.Log(argumentInput.GetValueAs<double>(), baseInput.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
