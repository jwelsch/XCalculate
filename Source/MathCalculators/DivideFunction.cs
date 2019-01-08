using System;
using System.Linq;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class DivideFunction : BaseFunction
    {
        public DivideFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Divide", new[] { new ValueInfo("Decimal quotient", "The decimal quotient of the division."), new ValueInfo("Whole quotient", "The whole number quotient of the division."), new ValueInfo("Whole remainder", "The whole number reminder of the division.") }, "Divide numbers.", "algebra", "divide"),
                  new AgnosticArrayValue(
                        new [] { 0.0, 1.0 },
                        new ValueInfo("Operands", "Operands to divide."),
                        i => ((i.Length <= 1 ? throw new ArgumentException("Two or more values must be specified.") : true)
                            && (TypeConverter.ToArray<double[]>(i).Skip(1).Contains(0) ? throw new DivideByZeroException() : true))))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var values = GetValues<double[]>(inputs[0]);

            var result = values[0];
            var saved = 0.0;

            for (var i = 1; i < values.Length; i++)
            {
                saved = result;

                result /= values[i];
            }

            var quotient = (int)result;
            var remainder = (int)(saved % values[values.Length - 1]);

            return this.CreateResults(result, quotient, remainder);
        }
    }
}
