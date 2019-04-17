using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class SecantFunction : BaseFunction
    {
        public SecantFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Secant", new ValueInfo("Result", "The secant of the angle."), "Find the secant of an angle.", "secant", "sec", "geometry"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the secant of.", new RadianUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var angle = (AgnosticValue)inputs[0];

            var result = 1.0 / Math.Sin(angle.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
