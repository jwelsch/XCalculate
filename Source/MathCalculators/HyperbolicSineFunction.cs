using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicSineFunction : BaseFunction
    {
        public HyperbolicSineFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Hyperbolic Sine", new ValueInfo("Result", "The hyperbolic sine of the angle."), "Find the hyperbolic sine of an angle.", "hyperbolic", "sine", "sinh"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the hyperbolic sine of.", new RadianUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var angle = (AgnosticValue)inputs[0];

            var result = Math.Sinh(angle.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
