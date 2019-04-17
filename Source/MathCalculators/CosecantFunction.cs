using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class CosecantFunction : BaseFunction
    {
        public CosecantFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Cosecant", new ValueInfo("Result", "The cosecant of the angle."), "Find the cosecant of an angle.", "cosecant", "csc"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the cosecant of.", new RadianUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var angle = (AgnosticValue)inputs[0];

            var result = 1.0 / Math.Cos(angle.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
