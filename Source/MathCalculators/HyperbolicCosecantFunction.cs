using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicCosecantFunction : BaseFunction
    {
        public HyperbolicCosecantFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Hyperbolic Cosecant", new ValueInfo("Result", "The hyperbolic cosecant of the angle."), "Find the hyperbolic cosecant of an angle.", "hyperbolic", "cosecant", "csch"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the hyperbolic cosecant of.", new RadianUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var angle = (AgnosticValue)inputs[0];

            var result = Math.Cosh(angle.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
