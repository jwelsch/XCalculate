using MathCalculators;
using System;
using XCalculateLib;
using Xunit;

namespace MathCaculators.Functional
{
    public class HyperbolicCosineFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateHyperbolicCosineOfPositiveAngle()
        {
            var function = new HyperbolicCosineFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 60;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Cosh(60), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateHyperbolicCosineOfNegativeAngle()
        {
            var function = new HyperbolicCosineFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = -54;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Cosh(-54), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateHyperbolicCosineWithNoAngleSpecified()
        {
            var function = new HyperbolicCosineFunction();

            var result = function.Calculate(p =>
            {
                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Cosh(0.0), TypeConverter.ToObject<double>(result.Value));
        }
    }
}
