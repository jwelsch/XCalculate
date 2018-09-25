using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class ArcsineFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateArcsineOfPositiveAngle()
        {
            var function = new ArcsineFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 60;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Asin(60), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateArcsineOfNegativeAngle()
        {
            var function = new ArcsineFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = -54;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Asin(-54), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateArcsineWithNoAngleSpecified()
        {
            var function = new ArcsineFunction();

            var result = function.Calculate(null);

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Asin(0.0), TypeConverter.ToObject<double>(result.Value));
        }
    }
}
