using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicCosineFunction : BaseFunction
    {
        public HyperbolicCosineFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Hyperbolic Cosine", new ValueInfo("Result", "The hyperbolic cosine of the angle."), "Find the hyperbolic cosine of an angle.", "hyperbolic", "cosine", "cosh"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the hyperbolic cosine of.", new RadianUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var angle = (AgnosticValue)inputs[0];

            var result = Math.Cosh(angle.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
