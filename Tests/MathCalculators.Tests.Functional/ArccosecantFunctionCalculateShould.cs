using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class ArccosecantFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateArccosecantOfPositiveAngle()
        {
            var function = new ArccosecantFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 60;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Acos(60), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateArccosecantOfNegativeAngle()
        {
            var function = new ArccosecantFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = -54;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Acos(-54), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateArccosecantWithNoAngleSpecified()
        {
            var function = new ArccosecantFunction();

            var result = function.Calculate(null);

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Acos(0.0), TypeConverter.ToObject<double>(result.Value));
        }
    }
}
