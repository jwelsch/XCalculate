using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class ArcsecantFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateArcsecantOfPositiveAngle()
        {
            var function = new ArcsecantFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 60;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Asin(60), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateArcsecantOfNegativeAngle()
        {
            var function = new ArcsecantFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = -54;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Asin(-54), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateArcsecantWithNoAngleSpecified()
        {
            var function = new ArcsecantFunction();

            var result = function.Calculate(null);

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Asin(0.0), TypeConverter.ToObject<double>(result.Value));
        }
    }
}
