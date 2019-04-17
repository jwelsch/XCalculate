using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ArctangentFunction : BaseFunction
    {
        public ArctangentFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Arctangent", new ValueInfo("Result", "The arctangent of the angle."), "Find the arctangent of an angle.", "arctangent", "arctan"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the arctangent of.", new RadianUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var angle = (AgnosticValue)inputs[0];

            var result = Math.Atan(angle.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
