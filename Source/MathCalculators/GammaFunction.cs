using System;
using System.Numerics;
using XCalculateLib;

namespace MathCalculators
{
    [Function]
    public class GammaFunction : BaseFunction
    {
        private readonly static int g = 7;
        private readonly static double[] p = { 0.99999999999980993, 676.5203681218851, -1259.1392167224028, 771.32342877765313, -176.61502916214059, 12.507343278686905, -0.13857109526572012, 9.9843695780195716e-6, 1.5056327351493116e-7 };

        public GammaFunction()
            //: base(new FunctionInfo(new Version("1.0.0"), "Gamma", "Apply the gamma function to a number.", "gamma"))
            : base(new FunctionInfo(new Version("1.0.0"), "Gamma", new ValueInfo("Factorial", "Gamma of the number."), "Apply the gamma function to a number.", "algebra", "gamma"),
                  new AgnosticValue(0.0, new ValueInfo("z"), i => TypeConverter.ToObject<double>(i) >= 0.0 ? true : throw new ArgumentException("Value must be greater that or equal to zero.")))
        {
        }

        //public override IPhase Calculate(IPhaseTransition transition = null)
        //{
        //    return this.SingleCalculate(transition,
        //        new FirstPhase(
        //            "Specify Argument",
        //            "Argument for the gamma function.",
        //            new AgnosticValue(new ValueInfo("z", "Value to the gamma function."), i => TypeConverter.ToObject<double>(i) >= 0.0)),
        //        v => Gamma(GetValue<double>(v)).Real);
        //}
        public override IValue[] Calculate(IValue[] inputs)
        {
            this.CheckInputs(inputs);

            var zInput = (AgnosticValue)inputs[0];

            var result = Gamma(GetValue<double>(zInput));

            return this.CreateResults(result.Real);
        }

        public static Complex Gamma(Complex z)
        {
            //
            // From: https://rosettacode.org/wiki/Gamma_function#C.23
            //

            // Reflection formula
            if (z.Real < 0.5)
            {
                return Math.PI / (Complex.Sin(Math.PI * z) * Gamma(1 - z));
            }
            else
            {
                z -= 1;

                var x = (Complex)p[0];

                for (var i = 1; i < g + 2; i++)
                {
                    x += p[i] / (z + i);
                }

                var t = z + g + 0.5;

                return Complex.Sqrt(2 * Math.PI) * (Complex.Pow(t, z + 0.5)) * Complex.Exp(-t) * x;
            }
        }
    }
}
