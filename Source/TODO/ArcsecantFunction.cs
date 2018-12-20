using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ArcsecantFunction : BaseFunction
    {
        public ArcsecantFunction()
            : base(new FunctionInfo(new Version("1.0.0"), "Arcsecant", "Find the arcsecant of an angle.", "arcsecant", "arcsec"))
        {
        }

        public override IPhase Calculate(IPhaseTransition transition = null)
        {
            return this.SingleCalculate(transition,
                new FirstPhase(
                    "Specify Argument",
                    "Specify angle to find the arcsecant of.",
                    new AgnosticValue(new ValueInfo("Angle", null, new RadianUnit()))),
                v => 1.0 / Math.Asin(GetValue<double>(v)));
        }
    }
}
