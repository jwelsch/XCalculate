using System;
using System.Linq;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class RootFunction : BaseFunction
    {
        public RootFunction()
            : base(new DefaultFunctionInfo(new Version("1.0.0"), "Root", "Find the root of a number.", "root"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new DefaultPhase(
                "Specify Operands",
                "Specify root operation values.",
                new AgnosticValue(0.0, new ValueInfo("Radicand", "Radicand of the root.")),
                new AgnosticValue(2.0, new ValueInfo("Index", "Index of the root.")));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Pow(TypeConverter.ToObject<double>(values[0].Value), 1.0 / TypeConverter.ToObject<double>(values[1].Value));

            return new AgnosticValue(result);
        }
    }
}
