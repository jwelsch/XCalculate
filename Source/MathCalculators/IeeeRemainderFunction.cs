using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class IeeeRemainderFunction : BaseFunction
    {
        public IeeeRemainderFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "IEEE Remainder", new ValueInfo("Remainder", "The IEEE 754 conformant remainder."), "Find the IEEE 754 conformant remainder of two numbers.", "algebra", "remainder"),
                  new AgnosticValue(0.0, new ValueInfo("Dividend")),
                  new AgnosticValue(1.0, new ValueInfo("Divisor"), i => TypeConverter.ToObject<double>(i) == 0.0 ? throw new DivideByZeroException() : true))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var dividendInput = (AgnosticValue)inputs[0];
            var divisorInput = (AgnosticValue)inputs[1];

            var result = Math.IEEERemainder(GetValue<double>(dividendInput), GetValue<double>(divisorInput));

            return this.CreateResults(result);
        }
    }
}
