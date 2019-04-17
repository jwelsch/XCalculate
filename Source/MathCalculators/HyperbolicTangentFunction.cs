using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicTangentFunction : BaseFunction
    {
        public HyperbolicTangentFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Hyperbolic Tangent", new ValueInfo("Result", "The hyperbolic tangent of the angle."), "Find the hyperbolic tangent of an angle.", "hyperbolic", "tangent", "tanh"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the hyperbolic tangent of.", new RadianUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var angle = (AgnosticValue)inputs[0];

            var result = Math.Tanh(angle.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
