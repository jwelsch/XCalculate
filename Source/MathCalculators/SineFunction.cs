using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class SineFunction : BaseFunction
    {
        public SineFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Sine", new ValueInfo("Result", "The sine of the angle."), "Find the sine of an angle.", "sine", "sin", "geometry"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the sine of.", new RadianUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var angle = (AgnosticValue)inputs[0];

            var result = Math.Sin(angle.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
