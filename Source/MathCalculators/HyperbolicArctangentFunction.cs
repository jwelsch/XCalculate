using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicArctangentFunction : BaseFunction
    {
        public HyperbolicArctangentFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Hyperbolic Arctangent", new ValueInfo("Result", "The hyperbolic arctangent of the angle."), "Find the hyperbolic arctangent of an angle.", "hyperbolic", "arctangent", "arctanh"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the hyperbolic arctangent of.", new RadianUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var angle = (AgnosticValue)inputs[0];

            var result = Math.Atanh(angle.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
