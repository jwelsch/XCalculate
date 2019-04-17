using System;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class PythagoreanHypotenuseFunction : BaseFunction
    {
        public PythagoreanHypotenuseFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Pythagorean Equation (Hypotenuse)", new ValueInfo("Hypotenuse", "Length of the hypotenuse"), "Calculates the length of the hypotenuse of a right triangle.", "geometry", "pythagorean", "hypotenuse"),
                  new AgnosticValue(0.0, new ValueInfo("Side A", "Length of side A.")),
                  new AgnosticValue(0.0, new ValueInfo("Side B", "Length of side B.")))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var sideA = GetValue<double>(inputs[0]);
            var sideB = GetValue<double>(inputs[1]);

            var result = Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));

            return this.CreateResults(result);
        }
    }
}
