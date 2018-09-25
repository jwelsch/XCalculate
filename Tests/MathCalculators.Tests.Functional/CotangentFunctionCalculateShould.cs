using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class CotangentFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateCotangentOfPositiveAngle()
        {
            var function = new CotangentFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 60;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Tan(60), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateCotangentOfNegativeAngle()
        {
            var function = new CotangentFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = -54;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Tan(-54), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateCotangentWithNoAngleSpecified()
        {
            var function = new CotangentFunction();

            var result = function.Calculate(null);

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Tan(0.0), TypeConverter.ToObject<double>(result.Value));
        }
    }
}
