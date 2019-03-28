using System;
using XCalculateLib;

namespace FinancialCalculators
{
    [Function]
    public class CompoundInterestFunction : BaseFunction
    {
        public CompoundInterestFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Compound Interest", new ValueInfo("Amount", "Value at the end of the time period."), "Calculate the amount at the end of a time period using compound interest.", "financial", "interest"),
                  new AgnosticValue(0.0, new ValueInfo("Principle", "Starting amount.")),
                  new AgnosticValue(0.0, new ValueInfo("Interest rate", "Interest rate as decimal.")),
                  new AgnosticValue(1.0, new ValueInfo("Number of compounds", "Number of times the interest is compounded per unit of time.")),
                  new AgnosticValue(0.0, new ValueInfo("Time", "Length of time.")))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            //
            // A = P * (1 + r/n)^(n * t)
            //

            var p = TypeConverter.ToObject<double>(inputs[0].Value);
            var r = TypeConverter.ToObject<double>(inputs[1].Value);
            var n = TypeConverter.ToObject<double>(inputs[2].Value);
            var t = TypeConverter.ToObject<double>(inputs[3].Value);

            var a = p * Math.Pow(1 + (r / n), n * t);

            return this.CreateResults(a);
        }
    }
}
