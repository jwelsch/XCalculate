using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicArcsineFunction : BaseFunction
    {
        public HyperbolicArcsineFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Hyperbolic Arcsine", new ValueInfo("Result", "The hyperbolic arcsine of the angle."), "Find the hyperbolic arcsine of an angle.", "hyperbolic", "arcsine", "arcsin"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the hyperbolic arcsine of.", new RadianUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var angle = (AgnosticValue)inputs[0];

            var result = Math.Asinh(angle.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
