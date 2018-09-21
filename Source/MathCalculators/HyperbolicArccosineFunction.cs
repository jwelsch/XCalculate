using System;
using XCalculateLib;

namespace MathCalculators
{
    public class HyperbolicArccosineFunction : BaseFunction
    {
        public HyperbolicArccosineFunction()
            : base(new DefaultFunctionInfo(new Version("1.0.0"), "Hyperbolic Arccosine", "Find the hyperbolic arccosine of an angle.", "hyperbolic", "arccosine", "arccosh"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new DefaultPhase(
                "Specify Operands",
                "Specify angle to find the hyperbolic arccosine of.",
                new AgnosticValue(0.0, new ValueInfo("Angle")));

            var values = DoPhase(phaseHandler, phase);

            var result = Math.Acosh(TypeConverter.ToObject<double>(values[0].Value));

            return new AgnosticValue(result);
        }
    }
}
