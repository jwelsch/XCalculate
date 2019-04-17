using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class ArccosineFunction : BaseFunction
    {
        public ArccosineFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Arccosine", new ValueInfo("Result", "The arccosine of the angle."), "Find the arccosine of an angle.", "arccosine", "arccos"),
                  new AgnosticValue(0.0, new ValueInfo("Angle", "Angle to find the arccosine of.", new RadianUnit())))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var angle = (AgnosticValue)inputs[0];

            var result = Math.Acos(angle.GetValueAs<double>());

            return this.CreateResults(result);
        }
    }
}
