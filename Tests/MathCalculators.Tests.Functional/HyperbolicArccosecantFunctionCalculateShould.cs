using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class HyperbolicArccosecantFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateArccosecantOfPositiveAngle()
        {
            var function = new HyperbolicArccosecantFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 60;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Acosh(60), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateArccosecantOfNegativeAngle()
        {
            var function = new HyperbolicArccosecantFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = -54;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Acosh(-54), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateArccosecantWithNoAngleSpecified()
        {
            var function = new HyperbolicArccosecantFunction();

            var result = function.Calculate(null);

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Acosh(0.0), TypeConverter.ToObject<double>(result.Value));
        }
    }
}
