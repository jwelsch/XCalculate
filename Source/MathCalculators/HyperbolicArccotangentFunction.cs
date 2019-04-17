using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicArccotangentFunction : BaseFunction
    {
        public HyperbolicArccotangentFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Hyperbolic Arccotangent", new ValueInfo("Result", "The hyperbolic arccotangent of the angle."), "Find the hyperbolic arccotangent of an angle.", "hyperbolic", "arccotangent", "arccoth"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the hyperbolic arccotangent of.", new RadianUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var angle = (AgnosticValue)inputs[0];

            var result = 1.0 / Math.Atanh(angle.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
