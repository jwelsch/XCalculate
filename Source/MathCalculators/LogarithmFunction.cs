using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class LogarithmFunction : BaseFunction
    {
        public LogarithmFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Logarithm", "Find the logarithm of a number.", "logarithm"))
        {
        }

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Arguments",
                    "Specify logarithm arguments.",
                    new AgnosticValue(0.0, new ValueInfo("Argument", "Argument of the logarithm.")),
                    new AgnosticValue(10.0, new ValueInfo("Base", "Base of the logarithm."))),
                v => Math.Log(GetValue<double>(v[0]), GetValue<double>(v[1])));
        }
    }
}
