using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicArcsecantFunction : BaseFunction
    {
        public HyperbolicArcsecantFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Hyperbolic Arcsecant", new ValueInfo("Result", "The hyperbolic arcsecant of the angle."), "Find the hyperbolic arcsecant of an angle.", "hyperbolic", "arcsecant", "arcsech"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the hyperbolic arcsecant of.", new RadianUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var angle = (AgnosticValue)inputs[0];

            var result = 1.0 / Math.Asinh(angle.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
