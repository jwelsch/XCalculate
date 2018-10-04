using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ArccosecantFunction : BaseFunction
    {
        public ArccosecantFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Arccosecant", "Find the arccosecant of an angle.", "arccosecant", "arccsc"))
        {
        }

        public override IPhase Calculate(IPhase currentPhase = null)
        {
            return this.SingleCalculate(currentPhase,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the arccosecant of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => 1.0 / Math.Acos(GetValue<double>(v)));
        }
    }
}
