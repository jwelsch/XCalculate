using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class TangentFunction : BaseFunction
    {
        public TangentFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Tangent", new ValueInfo("Result", "The tangent of the angle."), "Find the tangent of an angle.", "tangent", "tan", "geometry"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the tangent of.", new RadianUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var angle = (AgnosticValue)inputs[0];

            var result = Math.Tan(angle.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
