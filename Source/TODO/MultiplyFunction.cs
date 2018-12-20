using System;
using System.Linq;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class MultiplyFunction : BaseFunction
    {
        public MultiplyFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Multiply", "Multiply numbers.", "multiply"))
        {
        }

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Operands",
                    "Specify numbers to multiply.",
                    new AgnosticArrayValue(
                        new ValueInfo("Operands", "Operands to multiply."),
                        i => i != null && i.Length <= 1 ? throw new ArgumentException("Two or more values must be specified.") : true)),
                v => GetValues<double[]>(v).Aggregate((x, y) => x * y));
        }
    }
}
