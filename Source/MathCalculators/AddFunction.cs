using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class AddFunction : BaseFunction
    {
        public AddFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Add", new ValueInfo("Sum", "Sum of the numbers"), "Add numbers.", "add"),
                  new AgnosticArrayValue(new ValueInfo("Addends", "Numbers to add together"), i => i == null ? true : i.Length > 1))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var arrayInput = (AgnosticArrayValue)inputs[0];

            var result = 0.0;

            foreach (var input in arrayInput.Value)
            {
                result += TypeConverter.ToObject<double>(input);
            }

            return this.CreateResults(result);
        }
    }
}
