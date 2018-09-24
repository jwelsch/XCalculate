using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class HyperbolicSineFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateHyperbolicSineOfPositiveAngle()
        {
            var function = new HyperbolicSineFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 60;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Sinh(60), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateHyperbolicSineOfNegativeAngle()
        {
            var function = new HyperbolicSineFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = -54;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Sinh(-54), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateHyperbolicSineWithNoAngleSpecified()
        {
            var function = new HyperbolicSineFunction();

            var result = function.Calculate(null);

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Sinh(0.0), TypeConverter.ToObject<double>(result.Value));
        }
    }
}
