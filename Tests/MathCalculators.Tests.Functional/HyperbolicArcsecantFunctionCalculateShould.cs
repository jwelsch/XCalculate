using MathCalculators;
using System;
using XCalculateLib;
using Xunit;

namespace MathCalculators.Tests.Functional
{
    public class HyperbolicArcsecantFunctionCalculateShould
    {
        [Fact]
        public void SuccessfullyCalculateArcsecantOfPositiveAngle()
        {
            var function = new HyperbolicArcsecantFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = 60;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Asinh(60), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateArcsecantOfNegativeAngle()
        {
            var function = new HyperbolicArcsecantFunction();

            var result = function.Calculate(p =>
            {
                p.Inputs[0].Value = -54;

                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Asinh(-54), TypeConverter.ToObject<double>(result.Value));
        }

        [Fact]
        public void SuccessfullyCalculateArcsecantWithNoAngleSpecified()
        {
            var function = new HyperbolicArcsecantFunction();

            var result = function.Calculate(p =>
            {
                return p.Inputs;
            });

            Assert.Equal(typeof(double), result.ValueType);
            Assert.Equal(1.0 / Math.Asinh(0.0), TypeConverter.ToObject<double>(result.Value));
        }
    }
}
