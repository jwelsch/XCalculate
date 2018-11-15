using System;
using System.Linq;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class SubtractFunction : BaseFunction
    {
        public SubtractFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Subtract", "Subtract numbers.", "subtract"))
        {
        }

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Operands",
                    "Specify numbers to subtract.",
                    new AgnosticArrayValue(
                        new ValueInfo("Operands", "Operands to subtract."),
                        i => i != null && i.Length <= 1 ? throw new ArgumentException("Two or more values must be specified.") : true)),
                v => GetValues<double[]>(v).Aggregate((x, y) => x - y));
        }
    }
}
