using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class CosineFunction : BaseFunction
    {
        public CosineFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Cosine", new ValueInfo("Result", "The cosine of the angle."), "Find the cosine of an angle.", "cosine", "cos"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the cosine of.", new RadianUnit())))
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
