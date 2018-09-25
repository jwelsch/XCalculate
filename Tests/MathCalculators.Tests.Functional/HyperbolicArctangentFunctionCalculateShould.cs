using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class HyperbolicArctangentFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateHyperbolicArctangentOfPositiveAngle()
        {
            var function = new HyperbolicArctangentFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 60;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Atanh(60), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateHyperbolicArctangentOfNegativeAngle()
        {
            var function = new HyperbolicArctangentFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = -54;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Atanh(-54), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateHyperbolicArctangentWithNoAngleSpecified()
        {
            var function = new HyperbolicArctangentFunction();

            var result = function.Calculate(null);

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Atanh(0.0), TypeConverter.ToObject<double>(result.Value));
        }
    }
}
