using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ModuloFunction : BaseFunction
    {
        public ModuloFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Modulo", new ValueInfo("Remainder", "The C# standard remainder of two numbers."), "Find the C# standard remainder of two numbers.", "algebra", "modulo", "remainder"),
                  new AgnosticValue(0.0, new ValueInfo("Dividend")),
                  new AgnosticValue(1.0, new ValueInfo("Divisor"), i => TypeConverter.ToObject<double>(i) == 0.0 ? throw new DivideByZeroException() : true))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var dividendInput = (AgnosticValue)inputs[0];
            var divisorInput = (AgnosticValue)inputs[1];

            var result = dividendInput.GetValueAs<double>() % divisorInput.GetValueAs<double>();

            return this.CreateResults(result);
        }
    }
}
