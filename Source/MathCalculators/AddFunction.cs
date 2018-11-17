using System;
using System.Linq;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class AddFunction : BaseFunction
    {
        public AddFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Add", "Add numbers.", "add"))
        {
        }

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Operands",
                    "Specify numbers to add.",
                    new AgnosticArrayValue(
                        new ValueInfo("Operands", "Operands to add."),
                        i => i != null && i.Length <= 1 ? throw new ArgumentException("Two or more values must be specified.") : true)),
                v => GetValues<double[]>(v).Aggregate((x, y) => x + y));
        }
    }
}
