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
            : base(new FunctionInfo(new Version("1.0.0"), "Gamma", "Apply the gamma function to a number.", "gamma"))
        {
        }

        public override IValue Calculate(PhaseHandler phaseHandler)
        {
            var phase = new Phase(
                "Specify Argument",
                "Argument for the gamma function.",
                new AgnosticValue(0.0, new ValueInfo("z", "Value to the gamma function."),
                i => TypeConverter.ToObject<double>(i) >= 0.0));

            var values = DoPhase(phaseHandler, phase);

            var z = GetValue<double>(values[0]);

            var result = Gamma(z);

            return new AgnosticValue(result.Real);
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
