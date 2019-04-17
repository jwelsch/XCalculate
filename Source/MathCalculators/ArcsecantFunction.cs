using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ArcsecantFunction : BaseFunction
    {
        public ArcsecantFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Arcsecant", new ValueInfo("Result", "The arcsecant of the angle."), "Find the arcsecant of an angle.", "arcsecant", "arcsec"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the arcsecant of.", new RadianUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var angle = (AgnosticValue)inputs[0];

            var result = Math.Cos(angle.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
