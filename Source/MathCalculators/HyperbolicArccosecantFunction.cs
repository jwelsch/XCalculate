using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class HyperbolicArccosecantFunction : BaseFunction
    {
        public HyperbolicArccosecantFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Hyperbolic Arccosecant", new ValueInfo("Result", "The hyperbolic arccosecant of the angle."), "Find the hyperbolic arccosecant of an angle.", "hyperbolic", "arccosecant", "arccsch"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the hyperbolic arccosecant of.", new RadianUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var angle = (AgnosticValue)inputs[0];

            var result = 1.0 / Math.Acosh(angle.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
