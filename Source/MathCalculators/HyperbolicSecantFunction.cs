using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicSecantFunction : BaseFunction
    {
        public HyperbolicSecantFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Hyperbolic Secant", new ValueInfo("Result", "The hyperbolic secant of the angle."), "Find the hyperbolic secant of an angle.", "hyperbolic", "secant", "sech"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the hyperbolic secant of.", new RadianUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var angle = (AgnosticValue)inputs[0];

            var result = 1.0 / Math.Sinh(angle.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
