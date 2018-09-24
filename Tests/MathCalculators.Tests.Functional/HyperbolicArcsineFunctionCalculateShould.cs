using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class HyperbolicArcsineFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateHyperbolicArcsineOfPositiveAngle()
        {
            var function = new HyperbolicArcsineFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 60;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Asinh(60), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateHyperbolicArcsineOfNegativeAngle()
        {
            var function = new HyperbolicArcsineFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = -54;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Asinh(-54), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateHyperbolicArcsineWithNoAngleSpecified()
        {
            var function = new HyperbolicArcsineFunction();

            var result = function.Calculate(null);

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(Math.Asinh(0.0), TypeConverter.ToObject<double>(result.Value));
        }
    }
}
