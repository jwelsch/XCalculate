using System;
using System.Linq;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class DivideFunction : BaseFunction
    {
        public DivideFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Divide", "Divide numbers.", "divide"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Operands",
                "Specify numbers to divide.",
                new AgnosticArrayValue(
                    null,
                    new ValueInfo("Operands", "Operands to divide."),
                    i => i == null
                        || ((i.Length <= 1 ? throw new ArgumentException("Two or more values must be specified.") : true)
                        && (TypeConverter.ToArray<double[]>(i).Skip(1).Contains(0) ? throw new DivideByZeroException() : true))));

            var values = DoPhase(phaseHandler, phase);

            var arrayValues = GetValues<double[]>(values[0]);

            var quotient = arrayValues.Aggregate((x, y) => x / y);

            return new AgnosticValue(quotient);
        }
    }
}
