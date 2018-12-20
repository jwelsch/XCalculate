using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class RootFunction : BaseFunction
    {
        public RootFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Root", "Find the root of a number.", "root"))
        {
        }

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Operands",
                    "Specify root operation values.",
                    new AgnosticValue(0.0, new ValueInfo("Radicand")),
                    new AgnosticValue(2.0, new ValueInfo("Index"))),
                v => Math.Pow(GetValue<double>(v[0]), 1.0 / GetValue<double>(v[1])));
        }
    }
}
