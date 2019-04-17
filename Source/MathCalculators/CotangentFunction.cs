using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class CotangentFunction : BaseFunction
    {
        public CotangentFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Cosine", new ValueInfo("Result", "The cotangent of the angle."), "Find the cotangent of an angle.", "cotangent", "cot"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the cotangent of.", new RadianUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var angle = (AgnosticValue)inputs[0];

            var result = 1.0 / Math.Tan(angle.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
