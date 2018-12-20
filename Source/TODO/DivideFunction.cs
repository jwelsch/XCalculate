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

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Operands",
                    "Specify numbers to divide.",
                    new AgnosticArrayValue(
                        new ValueInfo("Operands", "Operands to divide."),
                        i => i == null
                            || ((i.Length <= 1 ? throw new ArgumentException("Two or more values must be specified.") : true)
                            && (TypeConverter.ToArray<double[]>(i).Skip(1).Contains(0) ? throw new DivideByZeroException() : true)))),
                v => GetValues<double[]>(v).Aggregate((x, y) => x / y));
        }
    }
}
