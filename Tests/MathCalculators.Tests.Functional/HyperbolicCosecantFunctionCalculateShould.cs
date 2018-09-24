using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class HyperbolicCosecantFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateHyperbolicCosecantOfPositiveAngle()
        {
            var function = new HyperbolicCosecantFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 60;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Cosh(60), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateHyperbolicCosecantOfNegativeAngle()
        {
            var function = new HyperbolicCosecantFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = -54;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Cosh(-54), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateHyperbolicCosecantWithNoAngleSpecified()
        {
            var function = new HyperbolicCosecantFunction();

            var result = function.Calculate(null);

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Cosh(0.0), TypeConverter.ToObject<double>(result.Value));
        }
    }
}
