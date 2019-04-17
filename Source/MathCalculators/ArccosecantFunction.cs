using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ArccosecantFunction : BaseFunction
    {
        public ArccosecantFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Arccosecant", new ValueInfo("Result", "The arccosecant of the angle."), "Find the arccosecant of an angle.", "arccosecant", "arccsc"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the arccosecant of.", new RadianUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var angle = (AgnosticValue)inputs[0];

            var result = 1.0 / Math.Acos(angle.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
