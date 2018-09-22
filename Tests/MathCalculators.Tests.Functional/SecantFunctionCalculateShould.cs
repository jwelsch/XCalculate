using MathCalculators;
using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class SecantFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateSecantOfPositiveAngle()
        {
            var function = new SecantFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 60;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Sin(60), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateSecantOfNegativeAngle()
        {
            var function = new SecantFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = -54;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Sin(-54), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateSecantWithNoAngleSpecified()
        {
            var function = new SecantFunction();

            var result = function.Calculate(p =>
            {
                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Sin(0.0), TypeConverter.ToObject<double>(result.Value));
        }
    }
}
