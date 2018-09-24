using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class HyperbolicCotangentFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateHyperbolicCotangentOfPositiveAngle()
        {
            var function = new HyperbolicCotangentFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 60;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Tanh(60), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateHyperbolicCotangentOfNegativeAngle()
        {
            var function = new HyperbolicCotangentFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = -54;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Tanh(-54), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateHyperbolicCotangentWithNoAngleSpecified()
        {
            var function = new HyperbolicCotangentFunction();

            var result = function.Calculate(null);

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Tanh(0.0), TypeConverter.ToObject<double>(result.Value));
        }
    }
}
