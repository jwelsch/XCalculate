using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class ArccotangentFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateArccotangentOfPositiveAngle()
        {
            var function = new ArccotangentFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 60;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Atan(60), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateArccotangentOfNegativeAngle()
        {
            var function = new ArccotangentFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = -54;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Atan(-54), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateArccotangentWithNoAngleSpecified()
        {
            var function = new ArccotangentFunction();

            var result = function.Calculate(null);

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Atan(0.0), TypeConverter.ToObject<double>(result.Value));
        }
    }
}
