using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ArccotangentFunction : BaseFunction
    {
        public ArccotangentFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Arccotangent", new ValueInfo("Result", "The arccotangent of the angle."), "Find the arccotangent of an angle.", "arccotangent", "arcot"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the arccotangent of.", new RadianUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var angle = (AgnosticValue)inputs[0];

            var result = 1.0 / Math.Atan(angle.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
