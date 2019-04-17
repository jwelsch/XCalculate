using System;
using System.Collections.Generic;
using System.Text;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class PythagoreanSideFunction : BaseFunction
    {
        public PythagoreanSideFunction()
            : base(
                  new FunctionInfo(new Version("1.0.0"), "Pythagorean Equation (Side)", new ValueInfo("Side", "Length of a side"), "Calculates the length of a side (not the hypotenuse) of a right triangle.", "geometry", "pythagorean"),
                  new AgnosticValue(0.0, new ValueInfo("Hypotenuse", "Length of the hypotenuse.")),
                  new AgnosticValue(0.0, new ValueInfo("Side", "Length of a side.")))
        {
        }

        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var hypotenuse = GetValue<double>(inputs[0]);
            var side = GetValue<double>(inputs[1]);

            //
            // h^2 - a^2 = b^2
            //
            var result = Math.Sqrt(Math.Pow(hypotenuse, 2) - Math.Pow(side, 2));

            return this.CreateResults(result);
        }
    }
}
