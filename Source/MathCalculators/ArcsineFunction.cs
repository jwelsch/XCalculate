using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ArcsineFunction : BaseFunction
    {
        public ArcsineFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Arcsine", new ValueInfo("Result", "The arcsine of the angle."), "Find the arcsine of an angle.", "arcsine", "arcsin", "geometry"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the arcsine of.", new RadianUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var angle = (AgnosticValue)inputs[0];

            var result = Math.Asin(angle.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
